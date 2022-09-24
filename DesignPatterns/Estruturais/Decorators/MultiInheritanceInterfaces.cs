using static System.Console;

namespace Decorators
{
  interface IBird
  {
    void Fly();
  }

  interface ILizard
  {
    void Crawl();
  }

  class Bird : IBird
  {
    public void Fly()
    {
      WriteLine("Soaring in the sky");
    }
  }

  class Lizard : ILizard
  {
    public void Crawl()
    {
      WriteLine("Crawling in the dirt");
    }
  }

  class Dragon : IBird, ILizard
  {
    private readonly Bird bird;
    private readonly Lizard lizard;

    public Dragon(Bird bird, Lizard lizard)
    {
      this.bird = bird;
      this.lizard = lizard;
    }

    public void Crawl()
    {
      lizard.Crawl();
    }

    public void Fly()
    {
      bird.Fly();
    }
  }
}