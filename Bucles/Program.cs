using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Números del 1 al 10 usando for:");
        for (int i = 1; i <= 1000; i++)
        {
            Console.Write(" *" + i);
        }

        Console.WriteLine("\nNúmeros del 1 al 1000 usando while:");
        int j = 1;
        while (j <= 1000)
        {
            Console.Write(" *" + j);
            j++;
        }

        Console.WriteLine("\nNúmeros del 1 al 1000 usando do-while:");
        int k = 1; 
        do
        {
            Console.Write(" *" + k);
            k++;
        } while (k <= 1000);

        int suma = 0, contador = 1;
        do
        {
            suma += contador;
            contador++;
        } while(contador <= 1000);
        Console.WriteLine("\nLa suma de todos los numeros del 1 al 1000 es: " + suma);

    }
}
