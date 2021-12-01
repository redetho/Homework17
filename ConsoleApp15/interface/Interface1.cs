using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp15.Fatura
{
   interface ITaxService
{

    double Tax(double amount);
}

class BrazilTaxService : ITaxService
{
        //calcula impostos
    public double Tax(double amount)
    {
        if (amount <= 100.00)
        {
            return amount * 0.2;
        }
        else
        {
            return amount * 0.15;
        }
    }
}

class RentalService
{
        //construtores e variáveis
    public double PricePerHour { get; private set; }
    public double PricePerDay { get; private set; }
    private ITaxService _taxService;
    public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
    {
        PricePerHour = pricePerHour;
        PricePerDay = pricePerDay;
        _taxService = taxService;
    }
    
        //calcula o preço em horas ou em dias.
    public void ProcessInvoice(CarRental carRental)
    {
        TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
        double basicPayment = 0.0;
        if (duration.TotalHours <= 12.0)
        {
            basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
        }
        else
        {
            basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
        }
        double tax = _taxService.Tax(basicPayment);
        carRental.Invoice = new Invoice(basicPayment, tax);
    }
}
}

