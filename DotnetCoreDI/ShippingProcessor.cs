using System;

namespace DotnetCoreDI
{
  public interface IShippingProcessor
  {
    void ShipProduct(Product product);
  }

  public class ShippingProcessor : IShippingProcessor
  {
    private IProductStockRepository _productStockRepository;

    public ShippingProcessor(IProductStockRepository productStockRepository)
    {
      _productStockRepository = productStockRepository;
    }
    public void ShipProduct(Product product)
    {
      _productStockRepository = new ProductStockRepository();
      _productStockRepository.ReduceStock(product);

      Console.WriteLine("Call Shipping API");
    }
  }
}