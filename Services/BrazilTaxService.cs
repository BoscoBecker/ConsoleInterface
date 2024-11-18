using ConsoleInterface.Services.Interfaces;

namespace ConsoleInterface.Services;

public class BrazilTaxService: ITaxService{
    public double Tax(double amount) {
        if (amount <= 100)
            return amount * 0.2;
        return amount * 0.15;
    }
}