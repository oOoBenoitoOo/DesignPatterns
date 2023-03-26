namespace AbstractFactory
{
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();

        IShippingCostService CreateShippingCostService();
    }

    /// <summary>
    /// Abstract product
    /// </summary>
    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }

    /// <summary>
    /// Concrete product
    /// </summary>
    public class BelgiumDiscountService: IDiscountService
    {
        public int DiscountPercentage => 20;
    }

    /// <summary>
    /// Concrete product
    /// </summary>
    public class FranceDiscountService: IDiscountService
    {
        public int DiscountPercentage => 10;
    }

    /// <summary>
    /// Abstract product
    /// </summary>
    public interface IShippingCostService
    {
        decimal ShippingCosts { get; }
    }

    /// <summary>
    /// Concrete product
    /// </summary>
    public class BelgiumShippingCostService: IShippingCostService
    {
        public decimal ShippingCosts => 20;
    }

    /// <summary>
    /// Concrete product
    /// </summary>
    public class FranceShippingCostService: IShippingCostService
    {
        public decimal ShippingCosts => 25;
    }

    public class BelgiumShoppingCartPurchaseFactory: IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new BelgiumShippingCostService();
        }
    }

    public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new FranceShippingCostService();
        }
    }

    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostService _shippingCostService;
        private int _orderCosts;

        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _discountService = factory.CreateDiscountService();
            _shippingCostService= factory.CreateShippingCostService();
            _orderCosts = 200;
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total costs = " +
                $"{_orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostService.ShippingCosts}");
        }
    }

}
