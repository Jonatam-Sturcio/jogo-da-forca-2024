namespace JogoDaForca.ConsoleApp {
    internal class Forca {
        private string[] lista = { "ABACAXI", "ABACATE", "ACEROLA", "AÇAÍ", "ARAÇA", "BACABA", "BACURI", "BANANA", "CAJÁ", "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA" };
        private int erros = 0;
        private void MontarForca(int erros) {
            Console.WriteLine(" " + new string('_', 10));
            Console.WriteLine(" |/" + new string(' ', 7) + "|");
            if (erros > 0)
                Console.WriteLine(" |" + new string(' ', 8) + "O");
            else
                Console.WriteLine(" |");
            if (erros == 2)
                Console.WriteLine(" |" + new string(' ', 8) + "X");
            else if (erros == 3)
                Console.WriteLine(" |" + new string(' ', 7) + "/X");
            else if (erros > 3)
                Console.WriteLine(" |" + new string(' ', 7) + "/X\\");
            else
                Console.WriteLine(" |");
            if (erros == 5)
                Console.WriteLine(" |" + new string(' ', 8) + "X");
            else
                Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine(" |");
            Console.WriteLine("_|____");
        }
        private string SelecionarPalavra() {
            return this.lista[new Random().Next(1, lista.Length)];
        }
        public void IniciarJogo() {
            string palavra = SelecionarPalavra();
            string chute, letrasUsadas = "", exibicao = new string('_', palavra.Length);

            while (true) {
                MontarForca(erros);
                Console.WriteLine("\n " + exibicao);

                if (!exibicao.Contains("_")) {
                    Console.WriteLine("\nVocê Ganhou!!! Pressione enter para jogar novamente!");
                    Console.ReadLine();
                    return;
                }
                if (erros == 5) {
                    Console.WriteLine("\nVocê perdeu! Pressione enter para tentar novamente!");
                    Console.ReadLine();
                    return;
                }
                Console.WriteLine($"Letras já utilizadas: {letrasUsadas}");
                Console.Write("\nQual o seu chute? ");
                chute = Console.ReadLine().ToUpper();
                if (chute.Length > 0 && letrasUsadas.Contains(chute.ToCharArray()[0])) {
                    Console.WriteLine("A letra já foi utilizada! Pressione qualquer enter para continuar");
                    Console.ReadLine();
                }
                else if (chute.Length > 0) {
                    letrasUsadas += chute[0] + " ";
                    exibicao = VerificaLetra(palavra, exibicao, chute);
                }

                Console.Clear();
            }
        }
        private string VerificaLetra(string palavra, string exibicao, string chute) {
            char[] chars = exibicao.ToCharArray();
            if (palavra.Contains(chute.ToArray()[0])) {
                for (int i = 0; i < palavra.Length; i++) {
                    if (palavra[i] == chute.ToCharArray()[0]) {
                        chars[i] = chute.ToCharArray()[0];
                    }
                }
            }
            else {
                this.erros++;
                return exibicao;
            }
            return exibicao = new string(chars);
        }
    }
}
