namespace SistemaVendas.Entidades
{
    public class VendaProduto
    {
        public int CodigoVenda { get; set; }
        public int CodigoProduto { get; set; }
        public double Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Total { get; set; }
        public Produto Produto { get; set; }
        public Venda Venda { get; set; }
    }
}
