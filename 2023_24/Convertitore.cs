using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertitore
{
    class Program
    {
        static void Main(string[] args)
        {
            // Esempio di utilizzo 1:
            bool[] binaryArray = { true, false, true, true }; // Rappresenta 1011 in binario.
            int[] decimalResult = Convert_Binario_To_Decimale_Puntato(binaryArray);

            // Stampa il numero decimale puntato.
            Console.Write("Numero decimale puntato: ");
            for (int i = 0; i < decimalResult.Length; i++)
            {
                Console.Write(decimalResult[i]);
            }

            Console.WriteLine();


            // Esempio di utilizzo 2:
            int[] decimalArray = { 1,0,0,1};
            bool[] binaryResult = Convert_Decimale_Puntato_To_Binario(decimalArray);

            // Stampa il numero binario.
            Console.Write("Numero binario: ");
            for (int i = 0; i < binaryResult.Length; i++)
            {
                Console.Write(binaryResult[i] ? "1" : "0");
            }

            Console.WriteLine();


            // Esempio di utilizzo 3:
            long num = 23; // Ad esempio, converti 23 in binario.
            bool[] bin = Convert_Numero_Decimale_To_Binario(num);

            // Stampa il numero binario.
            Console.Write("Numero binario: ");
            foreach (bool bit in bin)
            {
                Console.Write(bit ? "1" : "0");
            }

            Console.WriteLine();


            // Esempio di utilizzo 4:
            long decimalNumber = 12345; // Ad esempio, converti 12345 con 2 posizioni decimali.
            int[] fixedPointResult = Convert_Numero_Decimale_To_Decimale_Puntato(decimalNumber);

            // Stampa il numero decimale puntato.
            Console.Write("Numero decimale puntato: ");
            for (int i = 0; i < fixedPointResult.Length; i++)
            {
                Console.Write(fixedPointResult[i]);
                if (i == 0)
                {
                    Console.Write("."); // Separatore tra parte intera e parte decimale
                }
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        static int[] Convert_Binario_To_Decimale_Puntato(bool[] b)
        {
            int[] decimalArray = new int[b.Length + 2];

            // Copia la parte intera dall'array binario
            for (int i = 0; i < b.Length; i++)
            {
                decimalArray[i] = b[i] ? 1 : 0;
            }

            return decimalArray;

        }

        static bool[] Convert_Decimale_Puntato_To_Binario(int[] dp)
        {
            bool[] binaryArray = new bool[dp.Length - 2];

            // Converte la parte intera in binario
            for (int i = 0; i < binaryArray.Length; i++)
            {
                binaryArray[i] = dp[i] == 1;
            }

            return binaryArray;
        }

        static bool[] Convert_Numero_Decimale_To_Binario(long numero)
        {
            if (numero == 0)
            {
                return new bool[] { false };
            }

            bool[] binaryArray = new bool[64]; // Usiamo un array di 64 elementi per supportare i long.

            int index = 0;

            while (numero > 0)
            {
                binaryArray[index++] = (numero % 2 == 1);
                numero /= 2;
            }

            Array.Reverse(binaryArray, 0, index); // Invertiamo solo la parte interessante dell'array.

            return binaryArray;
        }


        static int[] Convert_Numero_Decimale_To_Decimale_Puntato(long numero)
        {
            int decimalPlaces = 2; //specifico le posizioni decimali
            if (decimalPlaces < 0)
            {
                throw new ArgumentException("Il numero di posizioni decimali deve essere non negativo.");
            }

            int[] decimalArray = new int[decimalPlaces + 1]; // +1 per la parte intera

            // Calcola la parte intera
            decimalArray[0] = (int)(numero / (long)Math.Pow(10, decimalPlaces));
            numero -= decimalArray[0] * (long)Math.Pow(10, decimalPlaces);

            // Calcola le parti decimali
            for (int i = 1; i <= decimalPlaces; i++)
            {
                decimalArray[i] = (int)(numero / (long)Math.Pow(10, decimalPlaces - i));
                numero -= decimalArray[i] * (long)Math.Pow(10, decimalPlaces - i);
            }

            return decimalArray;
        }
    }
}
