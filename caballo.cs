using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingrese ubicación de los frutos:");
        string entradaFrutos = Console.ReadLine();

        Console.WriteLine("Ingrese posición inicial del caballo:");
        string posicion = Console.ReadLine().ToUpper();

        Console.WriteLine("Ingrese los movimientos:");
        string movimientos = Console.ReadLine();

        Dictionary<string, char> frutos = new Dictionary<string, char>();

        string[] lista = entradaFrutos.Split(',');

        foreach (string f in lista)
        {
            string pos = f.Substring(0, 2).ToUpper();
            char tipo = f[2];
            frutos[pos] = tipo;
        }

        int x = posicion[0] - 'A';
        int y = posicion[1] - '1';

        string[] movs = movimientos.Split(',');

        List<char> recogidos = new List<char>();

        foreach (string m in movs)
        {
            string mov = m.Trim().ToUpper();

            switch (mov)
            {
                case "UL": x -= 1; y += 2; break;
                case "UR": x += 1; y += 2; break;
                case "LU": x -= 2; y += 1; break;
                case "LD": x -= 2; y -= 1; break;
                case "RU": x += 2; y += 1; break;
                case "RD": x += 2; y -= 1; break;
                case "DL": x -= 1; y -= 2; break;
                case "DR": x += 1; y -= 2; break;
            }

            if (x >= 0 && x < 8 && y >= 0 && y < 8)
            {
                string posActual = ((char)('A' + x)).ToString() + (y + 1);

                if (frutos.ContainsKey(posActual))
                {
                    recogidos.Add(frutos[posActual]);
                    frutos.Remove(posActual);
                }
            }
        }

        Console.WriteLine("Los frutos recogidos son:");

        foreach (char f in recogidos)
        {
            Console.Write(f + " ");
        }
    }
}
