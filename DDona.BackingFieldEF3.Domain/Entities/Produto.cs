using System;
using System.Collections.Generic;
using System.Text;

namespace DDona.BackingFieldEF3.Domain.Entities
{
    public class Produto
    {
        private readonly List<PrecoProduto> _precoProdutos;

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriado { get; set; }
        public decimal? PrecoUnidade { get; set; }

        public Produto()
        {
            _precoProdutos = new List<PrecoProduto>();
        }

        public IReadOnlyCollection<PrecoProduto> Precos { get { return _precoProdutos.AsReadOnly(); } }
    }
}
