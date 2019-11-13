using DDona.BackingFieldEF3.ConsoleApp.Factories;
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
                var produtos = db.Produto.ToList();
                foreach (var produto in produtos)
                {
                    Console.WriteLine($"{produto.Nome} foi criado em {produto.DataCriado.ToShortDateString()}");

                    if(produto.PrecoUnidade.HasValue)
                    {
                        Console.WriteLine($"Custa {produto.PrecoUnidade.Value.ToString()}");
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
