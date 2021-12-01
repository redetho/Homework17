using System;
using System.Globalization;
using ConsoleApp15.Fatura;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            //recebe o modelo, dados de check in e check out.
            Console.WriteLine("Entre com os dados da locação:");
            Console.Write("modelo:");
            string model = Console.ReadLine();
            Console.Write("Check-in (dd/MM/yyyy HH:mm):");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Check-out (dd / MM / yyyy HH: mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            
            //recebe o preço por hora e dia
            Console.Write("Entre com o preço por hora: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            Console.Write("Entre com o preço por dia: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            //armazena os dados recebidos
            CarRental carRental = new CarRental(start, finish, new Vehicle(model));
            //armazena o preço por dia e impostos.
            RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());
            rentalService.ProcessInvoice(carRental);
            //apresenta a fatura.
            Console.WriteLine("FATURA: ");
            Console.WriteLine(carRental.Invoice);
            Console.ReadKey();
        }
    }
}
