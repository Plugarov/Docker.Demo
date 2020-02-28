using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using RabbitMQ.Client;
using VehicleManagementAPI.DataAccess;
using VehicleManagementAPI.Model;

namespace VehicleManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleManagementDBContext dbContext;

        public VehicleController(VehicleManagementDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public string Get()
        {
            try
            {
                dbContext.Vehicle.Add(new Vehicle(){ CustomerId = 1, VIN = "JWQ34J23" });
                dbContext.SaveChanges();

                var all = dbContext.Vehicle.ToList();

                var factory = new ConnectionFactory
                {
                    HostName = "172.17.0.1",
                    Port = 5672,
                    UserName = "root",
                    Password = "root",
                };

                using (var connection = factory.CreateConnection())
                using (var model = connection.CreateModel())
                {
                    model.QueueDeclare("testQueue",
                                       durable: false,
                                       exclusive: false,
                                       autoDelete: false,
                                       arguments: null);

                    var message = "Message, my message.";
                    var body = Encoding.UTF8.GetBytes(message);

                    model.BasicPublish(exchange: string.Empty,
                                       routingKey: "testQueue",
                                       basicProperties: null,
                                       body: body);
                }

                return "Done1";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
