using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Classes
{/*
  * Na linguagem C#, clonar um objeto é copirar todos os membros do objeto para outro objeto. E no C# podemos realizar uma 
  * clonagem superficial conhecida como Shallow Copy ou uma clonagem profunda conhecida como Deep Copy.
  */
  public static class ClassesClonaveis
  {
    public interface IShallowCopy<T>
    {
      T ShallowCopy();
    }

    public interface IDeepCopy<T>
    {
      T DeepCopy();
    }

    class ShallowClone : IShallowCopy<ShallowClone>
    {
      public int Data = 1;
      public List<string> ListData = new List<string>();
      public object ObjData = new object();

      //Esse método criar uma cópia superficial do objeto atual
      public ShallowClone ShallowCopy() => (ShallowClone)this.MemberwiseClone();
    }

    class DeepClone : IDeepCopy<DeepClone>
    {
      public int data = 1;
      public List<string> ListData = new List<string>();
      public object objData = new object();

      public DeepClone DeepCopy()
      {
        BinaryFormatter BF = new BinaryFormatter();
        MemoryStream memStream = new MemoryStream();
        BF.Serialize(memStream, this);
        memStream.Flush();
        memStream.Position = 0;
        return (DeepClone)BF.Deserialize(memStream);
      }
    }

    [Serializable]
    public class MultiClone : IShallowCopy<MultiClone>, IDeepCopy<MultiClone>
    {
      public int data = 1;
      public List<string> ListData = new List<string>();
      public object objData = new object();

      public MultiClone ShallowCopy() => (MultiClone)this.MemberwiseClone();

      public MultiClone DeepCopy()
      {
        BinaryFormatter BF = new BinaryFormatter();
        MemoryStream memStream = new MemoryStream();
        BF.Serialize(memStream, this);
        memStream.Flush();
        memStream.Position = 0;
        return (MultiClone)BF.Deserialize(memStream);
      }
    }
  }
}
