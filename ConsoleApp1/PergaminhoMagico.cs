using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class PergaminhoMagico : ItemMagico
    {
        private string feitico;

        public PergaminhoMagico(string nome, double preco, string feitico, int quantidade, RaridadeItens raro) : base(nome, preco, quantidade)
        {
            SetFeitico(feitico);
        }

        public string GetFeitico() { return this.feitico; }
        public void SetFeitico(string feitico)
        {
            if (string.IsNullOrWhiteSpace(feitico))
            {
                Console.WriteLine("Feitiço inválido!");
            }
            else
            {
                this.feitico = feitico;
            }
        }

        public override void ToString()
        {
            base.ToString();
            Console.WriteLine($"FEITIÇO: {feitico}");
        }

    }
}