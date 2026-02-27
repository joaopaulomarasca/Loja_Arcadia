using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class ItemMagico
    {

        private string nome;
        private double preco;
        private int quantidade;
        private static int contador = 0;
        private int id;
        internal object Nome;

        public int ID => id;

        public int Quantidade { get; internal set; }
        public object Preco { get; internal set; }

        public ItemMagico(string nome, double preco, int quantidade, RaridadeItens raridade)
        {

            contador++;
            this.id = contador;

            SetNome(nome);
            SetPreco(preco);
            SetQuantidade(quantidade);

        }

        public ItemMagico(string nome, double preco, int quantidade)
        {
            this.nome = nome;
            this.preco = preco;
            this.quantidade = quantidade;
        }

        public string GetNome() { return this.nome; }
        public int GetQuantidade() { return this.quantidade; }
        public double GetPreco() { return this.preco; }


        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome inválido!");
            }
            else
            {
                this.nome = nome;
            }
        }

        public void SetQuantidade(int quantidade)
        {
            if (quantidade < 0)
            {
                this.quantidade = 0;
                Console.WriteLine("A quantidade não pode ser negativa");
            }
            else
            {
                this.quantidade = quantidade;
            }
        }
        public void SetPreco(double preco)
        {
            if (preco <= 0)
            {
                Console.WriteLine("Preço deve ser maior que 0");//
            }
            else
            {
                this.preco = preco;
            }
        }

        public virtual void ToString()
        {

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"ID: ");
            Console.ResetColor();
            Console.Write($"{ID} | ");


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("NOME: ");
            Console.ResetColor();
            Console.Write($"{nome} | ");



            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("QTD: ");
            Console.ResetColor();
            Console.Write($"{quantidade} | ");


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("PREÇO BASE: ");
            Console.ResetColor();
            Console.Write($"{preco:C2} | ");
        }

        internal double CalcularDesconto()
        {
            throw new NotImplementedException();
        }
    }
}