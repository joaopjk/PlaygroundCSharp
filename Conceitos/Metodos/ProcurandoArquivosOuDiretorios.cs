﻿using System;
using System.IO;

namespace Metodos
{/*
  * DirectoryInfo: Se você pretende reutilizar um objeto várias vezes, considere usar o método de instância do DirectoryInfo 
  * em vez de métodos estáticos correspondentes da Directory class, pois uma verificação de segurança sempre será necessária.
  */
  static class ProcurandoArquivosOuDiretorios
  {
    static void Main(string[] _)
    {
    }

    public static void ProcurarPor(string diretorioInicial, string criterioBusca, bool somenteDiretorio)
    {
      DirectoryInfo di = new DirectoryInfo(diretorioInicial);
      DirectoryInfo[] diretorios = di.GetDirectories(criterioBusca, SearchOption.AllDirectories);
      _ = diretorios.Length;
      ExibirResultadoPesquisa(diretorios);

      if (!somenteDiretorio)
      {
        FileInfo[] arquivos = di.GetFiles(criterioBusca, SearchOption.AllDirectories);
        ExibirResultadoPesquisa(arquivos);
        _ = arquivos.Length;
      }
    }

    public static void ExibirResultadoPesquisa(DirectoryInfo[] diretorios)
    {
      foreach (var item in diretorios)
      {
        Console.WriteLine($"{item.Name}\t{item.Parent}\tD");
      }
    }

    public static void ExibirResultadoPesquisa(FileInfo[] arquivos)
    {
      foreach (var item in arquivos)
      {
        Console.WriteLine($"{item.Name}\t{item.DirectoryName}\tD");
      }
    }
  }
}
