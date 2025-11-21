public class Address
{
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    // Returns whether the country is "USA" (case-insensitive)
    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    // Returns the formatted address string
    public string GetFullAddressString()
    {
        return $"{_street}\n{_city}, {_stateProvince}\n{_country}";
    }
}