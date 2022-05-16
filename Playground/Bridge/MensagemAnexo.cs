using System.Text;

namespace Bridge
{
    public class MensagemAnexo : Mensagem
    {
        public MensagemAnexo(IDespachaMensagem despachaMensagem)
        {
            this.despachaMensagem = despachaMensagem;
        }

        private string anexo = " <<[Anexo]>> ";
        public override void EnviaMensagem(string mensagem)
        {
            StringBuilder mensagemAnexo = new(mensagem);
            mensagemAnexo.Append(anexo);
            despachaMensagem.EnviaMensagem(mensagemAnexo.ToString());
        }
    }
}
