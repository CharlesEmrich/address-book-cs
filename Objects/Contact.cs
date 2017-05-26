namespace JobBoard.Objects
{
  public class Contact
  {
    private string _name;
    private string _telephone;
    private string _email;

    public Contact(string name, string telephone, string email)
    {
      _name      = name;
      _telephone = telephone;
      _email     = email;
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
  }
}
