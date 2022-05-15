namespace Adpter
{
    public class SistemaEscolar
    {
        public static string[,] GetListaAlunosMensalidades()
        {
            string[,] alunosArray = new string[5, 4]
            {
                {"101","Maria","Artes","1000"},
                {"102","Pedro","Engenharia","2000"},
                {"103","Bianca","Veterinária","3000"},
                {"104","Pamela","Moda","900"},
                {"105","Sergio","Desenho","850"}
            };

            return alunosArray;
        }
    }
}
