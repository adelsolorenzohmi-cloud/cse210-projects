public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Getter for Address object
    public Address GetAddress() => _address;

    // Getter for Name
    public string GetName() => _name;

    // Delegates country check to the Address object
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }
}