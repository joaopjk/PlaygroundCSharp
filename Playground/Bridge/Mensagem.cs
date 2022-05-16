namespace Bridge
{
    public abstract class Mensagem
    {
        protected IDespachaMensagem despachaMensagem;
        public abstract void EnviaMensagem(string mensagem);
    }
}
