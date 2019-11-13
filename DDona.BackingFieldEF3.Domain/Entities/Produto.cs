using System;
using System.Collections.Generic;
using System.Text;

namespace DDona.BackingFieldEF3.Domain.Entities
{
    public class Produto
    {
        private readonly List<PrecoProduto> _precos;

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriado { get; set; }
        public decimal? PrecoUnidade { get; set; }

        public Produto()
        {
            _precos = new List<PrecoProduto>();
        }

        public IReadOnlyCollection<PrecoProduto> Precos { get { return _precos.AsReadOnly(); } }
    }
}
