namespace ConsoleInterface.Entities;

public class CarRental(DateTime start, DateTime finish, Vehicle vehicle)
{
    public DateTime Start { get; set; } = start;
    public DateTime Finish { get; set; } = finish;
    public Vehicle Vehicle { get; set; } = vehicle;
    public Invoice Invoice { get; set; } = null!;
}