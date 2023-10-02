static int Convert_Decimale_Puntato_To_Intero(int[] dp)
        {
            int decimalNumber = 0;

            // Parte intera (da sinistra a destra)
            for (int i = 0; i < dp.Length; i++)
            {
                decimalNumber = decimalNumber * 10 + dp[i];
            }

            return decimalNumber;
        }

        static int Convert_Binario_To_Intero(bool[] b)
        {
            int decimalNumber = 0;

            // Scorrere l'array binario dall'inizio al termine (dal bit più significativo al meno significativo).
            for (int i = 0; i < b.Length; i++)
            {
                // Moltiplicare il numero decimale corrente per 2 (shift a sinistra) e aggiungere il bit corrente.
                decimalNumber = decimalNumber * 2 + (b[i] ? 1 : 0);
            }

            //Ritorno il numero decimale
            return decimalNumber;
        }