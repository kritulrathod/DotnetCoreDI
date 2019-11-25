using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreDI
{
  public interface IPaymentProcessor
  {
    void ChargeCreditCard(string cardNumber, string expiryDate);
  }

  public class PaymentProcessor : IPaymentProcessor
  {
    public void ChargeCreditCard(string cardNumber, string expiryDate)
    {
      if (string.IsNullOrEmpty(cardNumber)) throw new ArgumentException("Invalid CreditCard details");
      if (string.IsNullOrEmpty(expiryDate)) throw new ArgumentException("Invalid ExpiryDate details");

      Console.WriteLine("Call CreditCard Payment API");
    }


  }
}
