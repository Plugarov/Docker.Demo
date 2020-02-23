using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;  

namespace VehicleManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;

        public VehicleController(ILogger<VehicleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            try
            {
                var factory = new ConnectionFactory{
                    HostName = "172.17.0.1",
                    Port = 5672,
                    UserName = "root",
                    Password = "root",
                }; 
    
                using(var connection = factory.CreateConnection())
                using(var model = connection.CreateModel()){
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

                return "Done";
            }
            catch (Exception ex) 
            {
                return ex.ToString();
            }
        }
    }
}
