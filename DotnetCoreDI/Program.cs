using System;
using System.ComponentModel.Design;
using Microsoft.Extensions.DependencyInjection;
namespace DotnetCoreDI
{
  public class Program
  {
    public static readonly IServiceProvider Container = new ContainerBuilder().Build();

    public static void Main(string[] args)
    {


      string product = string.Empty;

      var orderManager = Container.GetService<IOrderManager>();

      while (product != "exit")
      {
        Console.WriteLine("Enter a product:");
        product = Console.ReadLine();

        try
        {
          if (Enum.TryParse(product, out Product productEnum))
          {
            Console.WriteLine("Enter a valid payment method:");
            var paymentMethod = Console.ReadLine();

            Console.WriteLine("Enter a ExpiryDate:");
            var expiryDate = Console.ReadLine();

            if (string.IsNullOrEmpty(paymentMethod)) Console.WriteLine("Invalid paymentMethod");
            if (string.IsNullOrEmpty(expiryDate)) Console.WriteLine("Invalid expiryDate");

            orderManager.Submit(productEnum, paymentMethod, expiryDate);

            Console.WriteLine("Product Shipped.");
          }
          else
          {
            Console.WriteLine("Invalid Product");
          }

        }
        catch (Exception ex)
        {
          Console.WriteLine("Error:" + ex);
        }
        Console.WriteLine(Environment.NewLine);
      }
    }
  }
}
