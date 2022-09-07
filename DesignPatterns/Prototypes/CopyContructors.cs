using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototypes
{
  public class Person
  {
    private string[] names;
    private Address address;

    public string[] Names { get => names; set => names = value; }
    public Address Address { get => address; set => address = value; }

    public Person(Person other)
    {
      names = other.Names;
      Address = new Address(other.Address);
    }
  }

  public class Address
  {
    private string streetName;
    private int houseNumber;

    public string StreetName { get => StreetName; set => StreetName = value; }
    public int HouseNumber { get => houseNumber; set => houseNumber = value; }

    public Address(Address other)
    {
      streetName = other.streetName;
      houseNumber = other.houseNumber;
    }
  }
}