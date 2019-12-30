# DotnetCoreDI

In this demo, I will start with a poor man's dependency injection implementation for a Dotnet Core Console Application and make minimal changes to use Microsoft's Container to implement dependency injection.

```
      // Poor Man's Dependency Injection
      var productStockRepository = new ProductStockRepository();

      IOrderManager orderManager = new OrderManager(
        productStockRepository,
        new PaymentProcessor(),
        new ShippingProcessor(productStockRepository)
        );
```

In order to use the Dotnet Core version of DependencyInjection,

First, we install the dependency from the nuget package.

```
Microsoft.Extensions.DependencyInjection
```

Next, add a new class `*ContainerBuilder*` and register all dependencies for your project.

```
using Microsoft.Extensions.DependencyInjection;
...
public class ContainerBuilder
  {
    public IServiceProvider Build()
    {
      var container = new ServiceCollection();

      container.AddSingleton<IOrderManager, OrderManager>();
      container.AddSingleton<IPaymentProcessor, PaymentProcessor>();
      container.AddSingleton<IProductStockRepository, ProductStockRepository>();
      container.AddSingleton<IShippingProcessor, ShippingProcessor>();

      return container.BuildServiceProvider();
    }
  }
  
```

Now, update the *Program* class to use the *ContainerBuilder* to inject the dependencies

```
using Microsoft.Extensions.DependencyInjection;
...
  public class Program
  {
    public static readonly IServiceProvider Container = new ContainerBuilder().Build();

    public static void Main(string[] args)
    {
      string product = string.Empty;

      var orderManager = Container.GetService<IOrderManager>();

      while (product != "exit")
      ...
```

Run the application and test.

Enjoy.

the original video link [here](https://www.youtube.com/watch?v=2rv-lcqW1tM)


