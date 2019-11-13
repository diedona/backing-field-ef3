using DDona.BackingFieldEF3.ConsoleApp.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DDona.BackingFieldEF3.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new SistemaContextFactory().CreateDbContext())
            {
                var produtos = db.Produto
                    .Include(x => x.Precos)
                    .ToList();

                foreach (var produto in produtos)
                {
                    Console.WriteLine($"{produto.Nome} foi criado em {produto.DataCriado.ToShortDateString()}");

                    var precoAtual = produto.Precos.FirstOrDefault(x => x.Ativo);
                    if(precoAtual != null)
                    {
                        Console.WriteLine($"Custa {precoAtual.Preco.ToString()} (preço de {precoAtual.Data.ToShortDateString()})");
                    }
                    else
                    {
                        Console.WriteLine(" -- sem preço definido --");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
