using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class ArmaMagico
    {
        public class ArmaMagica : ItemMagico
        {
            private int dano;
            private string v1;
            private int v2;
            private int v3;
            private int v4;
           

            public ArmaMagica(string nome, double preco, int dano, int quantidade, RaridadeItens raridade = RaridadeItens.Indefinido) : base(nome, preco, quantidade, raridade)
            {

                SetDano(dano);
            }


            public int GetDano() { return this.dano; }
            public void SetDano(int dano)
            {
                if (dano <= 0)
                {
                    Console.WriteLine("Dano deve ser maior que 0");
                }
                else
                {
                    this.dano = dano;
                }
            }

            public override void ToString()
            {
                base.ToString(); 
                Console.WriteLine($"DANO: {dano}");
            }
        }
    }
}
