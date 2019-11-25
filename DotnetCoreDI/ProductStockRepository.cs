using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreDI
{
  public interface IProductStockRepository
  {
    bool IsInStock(Product product);
    void ReduceStock(Product product);
    void AddStock(Product product);
  }

  public class ProductStockRepository : IProductStockRepository
  {

    public static Dictionary<Product, int> _productStockDatabase = Setup();

    private static Dictionary<Product, int> Setup()
    {
      _productStockDatabase = new Dictionary<Product, int>();
      _productStockDatabase.Add(Product.Keyboard, 1);
      _productStockDatabase.Add(Product.Mic, 1);
      _productStockDatabase.Add(Product.Monitor, 1);
      _productStockDatabase.Add(Product.Mouse, 1);
      _productStockDatabase.Add(Product.Speaker, 1);

      return _productStockDatabase;
    }

    public bool IsInStock(Product product)
    {
      Console.WriteLine("Checking IsInStock");
      return _productStockDatabase[product] > 0;
    }

    public void ReduceStock(Product product)
    {
      Console.WriteLine("Update Stock");
      _productStockDatabase[product]--;
    }

    public void AddStock(Product product)
    {
      Console.WriteLine("Update Stock");
      _productStockDatabase[product]++;
    }
  }

}
