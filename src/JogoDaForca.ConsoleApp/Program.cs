namespace JogoDaForca.ConsoleApp {
    internal class Program {
        static void Main(string[] args) {
            Forca forca = new Forca();
            while (true) {
                forca.IniciarJogo();
                Console.Clear();
            }
        }
    }
}
