using System;
using System.Collections.Generic;
using ConsoleApp1;
using static ConsoleApp1.ArmaMagico;

class Program
{
    private static int opcao;

    public static void Main()
    {
        List<ItemMagico> loja = new List<ItemMagico>()
        {
            new ItemMagico("Espadão", 25, 5),
            new ArmaMagica("Espada Flamejante", 100, 150, 3, RaridadeItens.Epico),
            new Pocao("Poção do Conhecimento", 27, "Sabedoria", 10, RaridadeItens.Epico),
            new PergaminhoMagico("Pergaminho do Ice", 500, "Ice Ball", 2, RaridadeItens.Epico)
        };

        bool lojaAberta = true;

        while (lojaAberta)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("=================================");
            Console.WriteLine("=================================");
            Console.WriteLine("=================================");
            Console.WriteLine("       LOJA DE ITENS MÁGICOS     ");
            Console.WriteLine("=================================");
            Console.WriteLine("=================================");
            Console.WriteLine("=================================");
            Console.WriteLine("=================================");

            Console.WriteLine("\nItens disponíveis:\n");

            foreach (var item in loja)
            {
                Console.WriteLine(item);
            }

            lojaAberta = false;
            Console.WriteLine("\n1 - Comprar Item");
            Console.WriteLine("0 - Sair");

            Console.Write("\nEscolha: ");

            switch (opcao)
            {
                case 1:
                    Console.Write("Digite o ID do item: ");
                    int id = int.Parse(Console.ReadLine());

                    ItemMagico itemSelecionado = loja.Find(i => i.ID == id);

                    if (itemSelecionado != null)
                    {
                        if (itemSelecionado.GetQuantidade() > 0)
                        {
                            itemSelecionado.SetQuantidade(itemSelecionado.GetQuantidade() - 1);
                            Console.WriteLine("Item comprado com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Item esgotado!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Item não encontrado!");
                    }

                    Console.ReadKey();
                    break;

                case 0:
                    lojaAberta = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    break;
            }
        }

        static int NewMethod()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
