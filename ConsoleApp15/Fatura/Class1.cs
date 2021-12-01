using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ConsoleApp15.Fatura
{
    class Invoice
    {
        //construtores e variáveis.
        public double BasicPayment { get; set; }
        public double Tax { get; set; }
        public Invoice(double rental, double tax)
        {
            BasicPayment = rental;
            Tax = tax;
        }
       
        public double TotalPayment
        {
            get { return BasicPayment + Tax; }
        }
        
        //override
        public override string ToString()
        {
            return "Basic payment: "
            + BasicPayment.ToString("F2", CultureInfo.InvariantCulture)
            + "\nTax: "
            + Tax.ToString("F2", CultureInfo.InvariantCulture)
            + "\nTotal payment: "
            + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
    //salva o modelo do veículo
    class Vehicle
    {
        public string Model { get; set; }
        public Vehicle(string model)
        {
            Model = model;
        }
    }
    
    //armazena os dados do processo.
    class CarRental
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Vehicle Vehicle { get; private set; }
        public Invoice Invoice { get; set; }
        public CarRental(DateTime start, DateTime finish, Vehicle vehicle)
        {
            Start = start;
            Finish = finish;
            Vehicle = vehicle;
            Invoice = null;
        }
    }
}

