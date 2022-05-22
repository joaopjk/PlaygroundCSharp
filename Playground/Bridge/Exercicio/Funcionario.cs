namespace Bridge.Exercicio
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Incentivo { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal SalarioTotal { get; set; }

        public override string ToString()
        {
            return
                $"Id: {Id}\n" +
                $"Nome: {Nome}\n" +
                $"Incentivo: {Incentivo}\n" +
                $"Salário Base :{SalarioBase}\n" +
                $"Salário Total:{SalarioTotal}";
        }
    }
}
