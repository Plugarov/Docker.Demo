using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;  
using RabbitMQ.Client.Events;

namespace WorkshopManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkshopController : ControllerBase
    {
        private readonly ILogger<WorkshopController> _logger;

        public WorkshopController(ILogger<WorkshopController> logger)
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
                using(var channel = connection.CreateModel())
                {
                    bool noAck = false;
                    BasicGetResult res = channel.BasicGet("testQueue", noAck);

                    if (res != null) 
                    {
                        IBasicProperties props = res.BasicProperties;
                        byte[] body = res.Body;
                        var message = Encoding.UTF8.GetString(body);

                        channel.BasicAck(res.DeliveryTag, false);

                        return message;
                    } else
                    {
                        return "No messages";
                    }
                }
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
