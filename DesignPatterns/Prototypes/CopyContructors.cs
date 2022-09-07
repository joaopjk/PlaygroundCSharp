using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototypes
{
  public interface IPrototype<T>
  {
    T DeepCopy();
  }

  public class Person : IPrototype<Person>
  {
    private string[] names;
    private Address address;

    public string[] Names { get => names; set => names = value; }
    public Address Address { get => address; set => address = value; }

    public Person(string[] names, Address address)
    {
      this.names = names;
      this.address = address;
    }

    public Person(Person other)
    {
      names = other.Names;
      Address = new Address(other.Address);
    }

    public Person DeepCopy()
    {
      return new Person(Names, Address.DeepCopy());
    }
  }

  public class Address : IPrototype<Address>
  {
    private string streetName;
    private int houseNumber;

    public string StreetName { get => StreetName; set => StreetName = value; }
    public int HouseNumber { get => houseNumber; set => houseNumber = value; }

    public Address(string streetName, int houseNumber)
    {
      this.streetName = streetName;
      this.houseNumber = houseNumber;
    }

    public Address(Address other)
    {
      streetName = other.streetName;
      houseNumber = other.houseNumber;
    }

    public Address DeepCopy()
    {
      return new Address(StreetName, HouseNumber);
    }
  }
}