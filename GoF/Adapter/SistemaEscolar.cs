namespace Adapter
{
  public static class SistemaEscolar
  {
    public static string[,] GeListaAlunosMensalidades()
    {
      return new string[5, 4]
       {
            {"101" ,"Maria","Artes","1000"},
            {"102" ,"Pedro","Engenharia","2000"},
            {"103" ,"Jane","SI","2000"},
            {"104" ,"Augusto","ADS","3000"},
            {"101" ,"Dylon","Direito","850"},
       };
    }
  }
}
