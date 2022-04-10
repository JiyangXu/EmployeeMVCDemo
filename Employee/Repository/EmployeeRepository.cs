using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Employee.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string connectionString = "";
        private readonly IHubContext<SignalServer> _context;
        public EmployeeRepository(IConfiguration configuration,IHubContext<SignalServer> context)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            _context = context;
        }

        public List<Models.Employee> GetAllEmployees()
        {
            var employees = new List<Models.Employee>();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDependency.Start(connectionString);
                var commandText = "select Id, Name, Age from dbo.Employee";
                SqlCommand cmd = new SqlCommand(commandText,conn);
                SqlDependency dependency = new SqlDependency(cmd);
                dependency.OnChange += new OnChangeEventHandler(dbChangeNotification);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var employee = new Models.Employee
                    {
                        //Id = new Guid((string)reader["Id"]);
                        Id = (Guid)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Age = Convert.ToInt32(reader["Age"])
                    };
                    employees.Add(employee);
                }
            }

            return employees;
        }

        private void dbChangeNotification(object sender, SqlNotificationEventArgs e)
        {
            var notification = e.ToString();
            _context.Clients.All.SendAsync("refreshEmployees");
        }
    }
}
