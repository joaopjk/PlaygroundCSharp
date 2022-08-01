namespace Bridge
{
    //Bridge
    public abstract class Arquivo
    {
        protected IGerarArquivo gerarArquivo;

        protected Arquivo(IGerarArquivo gerarArquivo)
        {
            this.gerarArquivo = gerarArquivo;
        }
        public virtual void GravarArquivo(Funcionario funcionario)
        {
            gerarArquivo.GerarArquivo(funcionario);
        }
    }
}
