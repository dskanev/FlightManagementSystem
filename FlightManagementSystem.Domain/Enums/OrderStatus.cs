namespace FlightManagementSystem.Domain.Enums
{
    public enum OrderStatus
    {
        New,
        Processing,
        ReadyToShip,
        ShippedToCustomer,
        Delivered,
        ShippedForReturn,
        Returned
    }
}
