namespace Composite
{
    //Component
    public abstract class HoraTrabalhada
    {
        public string Nome { get; set; }
        public virtual void Add(HoraTrabalhada component) { }
        public abstract int GetHoraTrabalhada();
    }
}
