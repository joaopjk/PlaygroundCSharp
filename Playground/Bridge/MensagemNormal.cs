namespace Bridge
{
    public class MensagemNormal : Mensagem
    {
        public MensagemNormal(IDespachaMensagem despachaMensagem)
        {
            this.despachaMensagem = despachaMensagem;
        }
        public override void EnviaMensagem(string mensagem)
        {
            despachaMensagem.EnviaMensagem(mensagem);
        }
    }
}
