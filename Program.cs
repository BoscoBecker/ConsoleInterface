using System.Globalization;
using ConsoleInterface.Entities;
using ConsoleInterface.Services;

namespace ConsoleInterface {
    internal abstract class Program {
        private static void Main() {
            try {
                Console.WriteLine("Enter rental data ");
                Console.Write("Car Model: ");
                var model = Console.ReadLine();
                Console.Write("Enter pickup (dd/mm/yyyy hh:mm) : ");
                var start = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                Console.Write("Return (dd/mm/yyyy hh:mm) : ");
                var finish = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                Console.Write("Enter price per hour: ");
                var perHour = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                Console.Write("Enter price per day: ");
                var perDay = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

                var carRental = new CarRental(start, finish, new Vehicle(model));
                RentalService rentalService = new(perHour, perDay,new BrazilTaxService());
                rentalService.ProcessInvoice(carRental);
                Console.WriteLine(carRental.Invoice);
            }
            catch (InvalidDataException dex){
                Console.WriteLine($"Date invalid found, message: {dex} ");
            }
            catch (Exception e){
                Console.WriteLine($"Errors found, message: {e} ");
            }
        }
    }
}