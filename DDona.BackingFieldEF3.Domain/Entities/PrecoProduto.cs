using System;
using System.Collections.Generic;
using System.Text;

namespace DDona.BackingFieldEF3.Domain.Entities
{
    public class PrecoProduto
    {
        private decimal _preco;

        public Guid Id { get; set; }
        public Guid IdProduto { get; set; }
        public decimal Preco { get { return _preco; } }
        public DateTime Data { get; set; }
        public bool Ativo { get; set; }

        public void SetarPreco(decimal valor)
        {
            // aplicando qualquer tipo de lógica
            if (valor <= 0)
            {
                throw new Exception("Preço negativo ou zerado não é permitido.");
            }

            //grava o valor
            _preco = valor;

            // atualiza a data
            Data = DateTime.Now;
        }

        public Produto Produto { get; set; }
    }
}
