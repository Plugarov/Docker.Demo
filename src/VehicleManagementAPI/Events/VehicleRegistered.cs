using System;
using System.Collections.Generic;
using System.Text;
using VehicleManagementAPI.Commands;
using Infrastructure.Messaging;

namespace VehicleManagementAPI.Events
{
    public class VehicleRegistered : Event
    {
        public int CustomerId { get; set; }
        public string VIN { get; set; }
        public bool IsDone { get; set; }

        public VehicleRegistered(Guid messageId, string vin, bool isDone, int customerId) :
            base(messageId)
        {
            VIN = vin;
            IsDone = isDone;
            CustomerId = customerId;
        }

        public static VehicleRegistered FromCommand(RegisterVehicle command)
        {
            return new VehicleRegistered(
                Guid.NewGuid(),
                command.VIN,
                command.IsDone,
                command.CustomerId
            );
        }
    }
}