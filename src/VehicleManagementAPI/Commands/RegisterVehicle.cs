using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Messaging;

namespace VehicleManagementAPI.Commands
{
    public class RegisterVehicle : Command
    {
        public int CustomerId { get; set; }
        public string VIN { get; set; }
        public bool IsDone { get; set; }

        public RegisterVehicle(Guid messageId, string vin, bool isDone, int customerId) : 
            base(messageId)
        {
            VIN = vin;
            IsDone = isDone;
            CustomerId = customerId;
        }
    }
}