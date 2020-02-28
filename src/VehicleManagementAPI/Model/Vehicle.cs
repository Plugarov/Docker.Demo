namespace VehicleManagementAPI.Model
{
    public class Vehicle
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string VIN { get; set; }

        public bool IsDone { get; set; }
    }
}