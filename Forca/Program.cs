using System;
using System.Runtime.InteropServices;

namespace Forca {
    internal class Program {

        static string[] palavras = {"ABACATE","ABACAXI", "ACEROLA", "AÇAI", "ARAÇA", "BACABA", "BACURI", "BANANA",
            "CAJA", "CAJU", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO","MAÇA", "MANGABA",
            "MANGA", "MARACUJA", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" };

        static int indicePalavraSecreta = 0, erros = 0, acertos = 0;
        static char erro1 = ' ', erro2=' ', erro3 = ' ', erro4 = ' ', erro5 = ' ';

        static void DesenharForca() {
            switch (erros) {
                
                case 1: erro1 ='O';break;
                case 2: erro2 = 'X'; break;
                case 3: erro3 = '/'; break;
                case 4: erro4 = '\\'; break;
                case 5: erro5 = '|';break;
            }
            Console.WriteLine(" -----------");
            Console.WriteLine(" |/        |");
            Console.WriteLine($" |         {erro1}");
            Console.WriteLine($" |        {erro3}{erro2}{erro4}");
            Console.WriteLine($" |         {erro5}");
            Console.WriteLine(" |         ");
            Console.WriteLine(" |         ");
            Console.WriteLine(" |         ");
            Console.WriteLine("_|________ ");
            Console.WriteLine();
        }
        private static char[] SortearPalavra() {
            Random random = new Random();
            indicePalavraSecreta = random.Next(palavras.Length);
            char[] palavraSecretaArray = palavras[indicePalavraSecreta].ToCharArray();

            return palavraSecretaArray;
        }
        static char[] ConfigurarLetrasCorretas(int tamanhoPalavra) {
            char[] arrayAcerto = new char[tamanhoPalavra];
            Array.Fill<char>(arrayAcerto, '_');
            return arrayAcerto;
        }
        static void EscreverLetrasCorretas(char[] arrayAcerto) {
            for (int i = 0; i < arrayAcerto.Length; i++) {
                Console.Write(arrayAcerto[i]);
            }
        }
        static bool VerificarVitoria(int acertos, char[] palavraSecretaArray) {

            bool parar = false;
            if (acertos >= palavraSecretaArray.Length) {
                Console.WriteLine();
                Console.WriteLine("Você Ganhou!");
                parar = true;
            }
            return parar;
        }
        static bool VerificarDerrota(int erros, char[]arrayAcerto) {
            bool parar = false;
            if (erros >= 5) {
                Console.Clear();
                DesenharForca();
                for (int i = 0; i < arrayAcerto.Length; i++) {
                    Console.Write(arrayAcerto[i]);
                }
                Console.WriteLine("\n\nVocê MORREU!");
                parar = true;
            }
            return parar;
        }
        static void AnalisarChute(char[] palavraSecretaArray, char[] arrayAcerto) {
            Console.Write("\n\nInforme o chute: ");
            char chute = char.Parse(Console.ReadLine());
            bool acertou = false;

            for (int i = 0; i < palavraSecretaArray.Length; i++) {
                if (chute == palavraSecretaArray[i] && arrayAcerto[i] != palavraSecretaArray[i]) {
                    acertou = true;
                    acertos++;
                    arrayAcerto[i] = palavraSecretaArray[i];
                }
                if (chute == arrayAcerto[i]) {
                    acertou = true;
                }
            }
            if (!acertou) {
                erros++;
            }
        }
        static void Main(string[] args) {
            
            char[] palavraSecretaArray = SortearPalavra();
            char[] arrayAcerto = ConfigurarLetrasCorretas(palavraSecretaArray.Length);
            
            while (erros <= 5) {

                DesenharForca();
                EscreverLetrasCorretas(arrayAcerto);
                bool parar = VerificarVitoria(acertos, palavraSecretaArray);
                parar = VerificarDerrota(erros, arrayAcerto);
                if (parar) break;
                AnalisarChute(palavraSecretaArray, arrayAcerto);
                Console.Clear();
            }
        }
    }
}