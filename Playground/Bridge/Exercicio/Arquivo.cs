namespace Bridge.Exercicio
{
    public abstract class Arquivo
    {
        protected IGerarArquivo gerarArquivo;
        public Arquivo(IGerarArquivo gerarArquivo)
        {
            this.gerarArquivo = gerarArquivo;
        }

        public virtual void GravarArquivo(Funcionario funcionario)
        {
            gerarArquivo.GerarArquivo(funcionario);
        }
    }
}
