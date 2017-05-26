namespace AddressBook.Objects
{
  public class Address
  {
    private string _street;
    private string _city;
    private string _zip;

    public Address (string street, string city, string zip)
    {
      _street = street;
      _city   = city;
      _zip    = zip;
    }

    public string GetStreet()
    {
      return _street;
    }
    public void SetStreet(string newStreet)
    {
      _street = newStreet;
    }
    public string GetCity()
    {
      return _city;
    }
    public void SetCity(string newCity)
    {
      _city = newCity;
    }
    public string GetZip()
    {
      return _zip;
    }
    public void SetZip(string newZip)
    {
      _zip = newZip;
    }
  }
}
