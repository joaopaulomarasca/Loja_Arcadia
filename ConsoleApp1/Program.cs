using System;
using System.Collections.Generic;

class Program
{
    static int ouroJogador = 500;

    static void Main()
    {
        List<ItemVenda> itensLoja = new List<ItemVenda>()
        {
            new ItemVenda(1,"Espada de Fogo",200,"Épico"),
            new ItemVenda(2,"Magia Negra",300,"Raro"),
            new ItemVenda(3,"Pergaminho Sombrio",150,"Raro"),
            new ItemVenda(4,"Cajado Arcano",400,"Lendário")
        };

        List<ItemVenda> inventario = new List<ItemVenda>();

        bool lojaAberta = true;

        while (lojaAberta)
        {
            Console.Clear();

           
            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < 6; i++)
                Console.WriteLine("=================================");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("       LOJA DE ITENS MÁGICOS");

            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i < 6; i++)
                Console.WriteLine("=================================");

            Console.ResetColor();

            Console.WriteLine($"\nSeu ouro: {ouroJogador}\n");

            Console.WriteLine("Itens disponíveis:\n");

            foreach (var item in itensLoja)
            {
                Console.ForegroundColor = item.GetCorPorRaridade();
                Console.WriteLine(item);
            }

            Console.ResetColor();

            Console.WriteLine("\n1 - Comprar Item");
            Console.WriteLine("2 - Vender Item");
            Console.WriteLine("3 - Ver Inventário");
            Console.WriteLine("0 - Sair");

            Console.Write("\nEscolha: ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    ComprarItem(itensLoja, inventario);
                    break;

                case 2:
                    VenderItem(inventario);
                    break;

                case 3:
                    MostrarInventario(inventario);
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
    }

    static void ComprarItem(List<ItemVenda> loja, List<ItemVenda> inventario)
    {
        Console.Write("\nDigite o ID do item: ");
        int id = int.Parse(Console.ReadLine());

        ItemVenda itemSelecionado = loja.Find(i => i.ID == id);

        if (itemSelecionado == null)
        {
            Console.WriteLine("Item não encontrado!");
        }
        else if (ouroJogador < itemSelecionado.Preco)
        {
            Console.WriteLine("Ouro insuficiente!");
        }
        else
        {
            ouroJogador -= itemSelecionado.Preco;
            inventario.Add(new ItemVenda(itemSelecionado.ID, itemSelecionado.Nome, itemSelecionado.Preco, itemSelecionado.Raridade));
            Console.WriteLine("Item comprado com sucesso!");
        }

        Console.ReadKey();
    }

    static void VenderItem(List<ItemVenda> inventario)
    {
        if (inventario.Count == 0)
        {
            Console.WriteLine("\nVocê não possui itens no inventário.");
            Console.WriteLine("Digite um item que deseja vender para a loja.");

            Console.Write("Nome do item: ");
            string nome = Console.ReadLine();

            Console.Write("Preço do item: ");
            int preco = int.Parse(Console.ReadLine());

            Console.Write("Raridade do item: ");
            string raridade = Console.ReadLine();

            int valorVenda = preco / 2;
            ouroJogador += valorVenda;

            Console.WriteLine($"\nVocê vendeu {nome} por {valorVenda} de ouro!");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\nSeu Inventário:\n");
        for (int i = 0; i < inventario.Count; i++)
        {
            Console.ForegroundColor = inventario[i].GetCorPorRaridade();
            Console.WriteLine($"{i} - {inventario[i]}");
        }

        Console.ResetColor();

        Console.Write("\nEscolha o item para vender: ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < inventario.Count)
        {
            ItemVenda item = inventario[index];
            int valorVenda = item.Preco / 2;
            ouroJogador += valorVenda;
            inventario.RemoveAt(index);
            Console.WriteLine($"Item vendido por {valorVenda} de ouro!");
        }
        else
        {
            Console.WriteLine("Item inválido!");
        }

        Console.ReadKey();
    }

    static void MostrarInventario(List<ItemVenda> inventario)
    {
        Console.WriteLine("\nInventário:\n");

        if (inventario.Count == 0)
        {
            Console.WriteLine("Inventário vazio.");
        }
        else
        {
            foreach (var item in inventario)
            {
                Console.ForegroundColor = item.GetCorPorRaridade();
                Console.WriteLine(item);
            }
            Console.ResetColor();
        }

        Console.ReadKey();
    }
}

class ItemVenda
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public int Preco { get; set; }
    public string Raridade { get; set; }

    public ItemVenda(int id, string nome, int preco, string raridade)
    {
        ID = id;
        Nome = nome;
        Preco = preco;
        Raridade = raridade;
    }

    public ConsoleColor GetCorPorRaridade()
    {
        return Raridade switch
        {
            "Comum" => ConsoleColor.Gray,
            "Raro" => ConsoleColor.Blue,
            "Épico" => ConsoleColor.Magenta,
            "Lendário" => ConsoleColor.Yellow,
            _ => ConsoleColor.White,
        };
    }

    public override string ToString()
    {
        return $"ID: {ID} | {Nome} | Preço: {Preco} | Raridade: {Raridade}";
    }
}
