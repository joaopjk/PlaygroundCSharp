using System;

namespace Builders
{
  //Product
  class Computador
  {
    public string TipoComputador { get; set; }

    public Computador(string tipoComputador)
    {
      TipoComputador = tipoComputador;
    }
  }

  //Builder
  abstract class ComputadorBuilder
  {
    public abstract void BuildSo();
    public abstract void BuildDispositivo();
    public virtual Computador TipoComputador { get; }
  }

  //Concrete Builder
  class DesktopBuilder : ComputadorBuilder
  {
    readonly Computador computador;
    public DesktopBuilder()
    {
      computador = new Computador("Desktop");
    }
    public override void BuildDispositivo()
    {
      Console.WriteLine("Build dispositivos no desktop...");
    }

    public override void BuildSo()
    {
      Console.WriteLine("Build Sistema Operacional no Desktop");
    }

    public override Computador TipoComputador
    {
      get { return computador; }
    }
  }

  class NotebookBuilder : ComputadorBuilder
  {
    readonly Computador computador;

    public NotebookBuilder()
    {
      computador = new Computador("Notebook");
    }
    public override void BuildDispositivo()
    {
      Console.WriteLine("Build dispositivos no Notebook...");
    }

    public override void BuildSo()
    {
      Console.WriteLine("Build Sistema Operacional no Notebook");
    }

    public override Computador TipoComputador
    {
      get { return computador; }
    }
  }

  //Director
  static class Fabricante
  {
    public static void Build(ComputadorBuilder computadorBuilder)
    {
      computadorBuilder.BuildDispositivo();
      computadorBuilder.BuildSo();
    }
  }
}