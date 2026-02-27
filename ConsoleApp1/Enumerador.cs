using System;

namespace ConsoleApp1
{
    public enum RaridadeItens
    {
        Indefinido = 0,
        Comum = 1,
        Raro = 2,
        Epico = 3,
        Lendario = 4,
        Divino = 5
    }

    public static class RaridadeItensExtensions
    {
        public static ConsoleColor ObterCor(this RaridadeItens raridade)
        {
            switch (raridade)
            {
                case RaridadeItens.Comum:
                    return ConsoleColor.White;

                case RaridadeItens.Raro:
                    return ConsoleColor.Blue;

                case RaridadeItens.Epico:
                    return ConsoleColor.Magenta;

                case RaridadeItens.Lendario:
                    return ConsoleColor.Yellow;

                case RaridadeItens.Divino:
                    return ConsoleColor.Cyan;

                default:
                    return ConsoleColor.Gray;
            }
        }
    }

    
        
}