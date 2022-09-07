namespace Prototypes
{
  public class AddressP
  {
    public string StreetName;
    public int HouseNumber;

    public AddressP() { }
    public AddressP(string streetName, int houseNumber)
    {
      StreetName = streetName;
      HouseNumber = houseNumber;
    }
  }

  public class PersonP
  {
    public string[] Names;
    public AddressP Address;
    public PersonP() { }
    public PersonP(string[] names, AddressP address)
    {
      Names = names;
      Address = address;
    }
  }

  public class Employee : PersonP
  {
  }
}