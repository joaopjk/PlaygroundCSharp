using System;
using System.Collections;
using System.Collections.Generic;

namespace Adapters
{
  public interface ICommand
  {
    void Execute();
  }

  class SaveCommand : ICommand
  {
    public void Execute()
    {
      Console.WriteLine("Saving a file");
    }
  }

  class OpenCommand : ICommand
  {
    public void Execute()
    {
      Console.WriteLine("Opening a file");
    }
  }

  class Button
  {
    private readonly ICommand command;
    private readonly string name;

    public Button(ICommand command, string name)
    {
      this.command = command;
      this.name = name;
    }

    public void Click()
    {
      command.Execute();
    }

    public void PrintMe()
    {
      Console.WriteLine(name);
    }
  }

  class Editor
  {
    private readonly IEnumerable<Button> buttons;

    public Editor(IEnumerable<Button> buttons)
    {
      this.buttons = buttons;
    }

    public void ClickAll()
    {
      foreach (var btn in buttons)
        btn.Click();
    }
  }
}