using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private int     _id;
    private string  _name;
    private string  _telephone;
    private string  _email;
    private Address _address;
    private static List<Contact> _instances = new List<Contact> {};
    private static int _idCounter = 0;

    public Contact(string name, string telephone, string email, Address address)
    {
      _id        = _idCounter;
      _name      = name;
      _telephone = telephone;
      _email     = email;
      _address   = address;

      _instances.Add(this);
      _idCounter ++;
    }

    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public string GetTelephone()
    {
      return _telephone;
    }
    public void SetTelephone(string newTelephone)
    {
      _telephone = newTelephone;
    }
    public string GetEmail()
    {
      return _email;
    }
    public void SetEmail(string newEmail)
    {
      _email = newEmail;
    }
    public Address GetAddress()
    {
      return _address;
    }
    public void SetAddress(Address newAddress)
    {
      _address = newAddress;
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId];
    }
    public static void ClearAll()
    {
      _instances = new List<Contact> {};
    }
  }
}
