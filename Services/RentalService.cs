using ConsoleInterface.Entities;
using ConsoleInterface.Services.Interfaces;

namespace ConsoleInterface.Services;

public class RentalService(double pricePerHour, double priceByDay,ITaxService iTaxService) {
    private double PricePerHour { get; set; } = pricePerHour;
    private double PriceByDay { get; set; } = priceByDay;

    public void ProcessInvoice(CarRental carRental)
    {
        var duration = carRental.Finish.Subtract(carRental.Start);
        double basicPayment;
        if (duration.TotalHours <= 12.0)
            basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
        else
            basicPayment = PriceByDay * Math.Ceiling(duration.TotalDays);

        var tax = iTaxService.Tax(basicPayment);
        carRental.Invoice  = new Invoice(basicPayment, tax);
    }
}