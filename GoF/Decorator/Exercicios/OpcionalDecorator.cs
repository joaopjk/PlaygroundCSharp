namespace Decorator.Exercicios
{
    public abstract class OpcionalDecorator : ICafe
    {
        protected ICafe _cafe;
        protected string _opcional = "indefinodo";
        protected decimal _preco = 0.00m;
        protected OpcionalDecorator(ICafe cafe)
        {
            _cafe = cafe;
        }
        public virtual string Decricao()
        {
            return _cafe.Decricao() + _opcional;
        }

        public virtual decimal Preco()
        {
            return _cafe.Preco() + _preco;
        }
    }
}
