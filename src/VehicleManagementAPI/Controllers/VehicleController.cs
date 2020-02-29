using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using Infrastructure.Messaging;
using VehicleManagementAPI.Commands;
using VehicleManagementAPI.DataAccess;
using VehicleManagementAPI.Model;
using VehicleManagementAPI.Events;

namespace VehicleManagementAPI.Controllers
{
    [Route("/api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly VehicleManagementDBContext _dbContext;
        // private readonly IMessagePublisher _messagePublisher;

        public VehicleController(VehicleManagementDBContext dbContext)
        {
            _dbContext = dbContext;
            // _messagePublisher = messagePublisher;
        }

        [HttpGet]
        public string Get()
        {
            try
            {
                _dbContext.Vehicle.Add(new Vehicle() { CustomerId = 1, VIN = "JWQ34J23" });
                _dbContext.SaveChanges();

                var all = _dbContext.Vehicle.ToList();


                var command = new RegisterVehicle(Guid.NewGuid(), "asd", true, 4);

                var easd =  new Infrastructure.Messaging.Event();


                var e = VehicleRegistered.FromCommand(command);
                // await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");

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

                return "Done";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
