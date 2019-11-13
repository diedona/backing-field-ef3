using System;
using System.Collections.Generic;
using System.Text;

namespace DDona.BackingFieldEF3.Domain.Entities
{
    public class PrecoProduto
    {
        public Guid Id { get; set; }
        public Guid IdProduto { get; set; }
        public decimal Preco { get; set; }
        public DateTime Data { get; set; }
        public bool Ativo { get; set; }

        public Produto Produto { get; set; }
    }
}
