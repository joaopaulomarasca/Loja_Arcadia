using System;

namespace ConsoleApp1
{
    public class Pocao : ItemMagico
    {
        private string efeito;

        public Pocao(string nome, double preco, string efeito, int quantidade, RaridadeItens raridade = RaridadeItens.Indefinido)
            : base(nome, preco, quantidade, raridade)
        {
            SetEfeito(efeito);
        }

        public string GetEfeito()
        {
            return this.efeito;
        }

        public void SetEfeito(string efeito)
        {
            if (string.IsNullOrWhiteSpace(efeito))
            {
                Console.WriteLine("Efeito inválido!");
            }
            else
            {
                this.efeito = efeito;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Pocao pocao &&
                   ID == pocao.ID &&
                   efeito == pocao.efeito;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, efeito);
        }

       
    }
}