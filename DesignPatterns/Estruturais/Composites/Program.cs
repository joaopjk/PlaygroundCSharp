using System;

namespace Composites
{
  static class Program
  {
    static void Main(string[] _)
    {
      //Geometric Shape
      var drawing = new GraphicObject { Name = "My Drawing" };
      drawing.Children.Add(new Square { Color = "Red" });
      drawing.Children.Add(new Circle { Color = "Yellow" });

      var group = new GraphicObject();
      group.Children.Add(new Circle { Color = "Blue" });
      group.Children.Add(new Square { Color = "Black" });

      drawing.Children.Add(group);

      //Neural Networks
      var neuron1 = new Neuron();
      var neuron2 = new Neuron();

      neuron1.ConnectTo(neuron2);

      var layer1 = new NeuronLayer();
      var layer2 = new NeuronLayer();

      neuron1.ConnectTo(layer1);
      layer1.ConnectTo(layer2);
    }
  }
}
