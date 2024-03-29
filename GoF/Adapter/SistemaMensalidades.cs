﻿using System.Collections.Generic;

namespace Adapter
{
  public static class SistemaMensalidades
  {
    public static void CalcularMensalidade(List<Aluno> listaAlunos)
    {
      foreach (var item in listaAlunos)
      {
        _ = item.Mensalidade * 1.1M;
        System.Console.WriteLine($"Aluno - {item.Nome} | Valor da mensalidade R$ {item.Mensalidade}");
      }
    }
  }
}
