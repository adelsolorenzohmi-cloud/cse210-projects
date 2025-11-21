public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Calculates the total price (product costs + shipping)
    public decimal GetTotal()
    {
        decimal productTotal = 0;

        foreach (Product product in _products)
        {
            productTotal += product.GetTotalCost();
        }

        // Conditional Shipping Cost Logic
        // USA: $5, International: $35
        decimal shippingCost = _customer.IsInUSA() ? 5.00m : 35.00m;

        return productTotal + shippingCost;
    }

    // Generates the packing label (Product Name and ID list)
    public string GetPackingLabel()
    {
        string label = "--- Packing Label ---\n";
        foreach (Product product in _products)
        {
            label += $"Product: {product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    // Generates the shipping label (Customer Name and Address)
    public string GetShippingLabel()
    {
        string label = "--- Shipping Label ---\n";
        label += $"Customer: {_customer.GetName()}\n";
        label += _customer.GetAddress().GetFullAddressString();
        return label;
    }
}