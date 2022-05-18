namespace Composite.Exercicio
{
    //Component
    public abstract class ItemQuestionario
    {
        protected string Descricao;
        protected ItemQuestionario(string descricao)
        {
            Descricao = descricao;
        }

        public abstract void Exibir();
    }
}
