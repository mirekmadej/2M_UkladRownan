namespace _2M_UkladRownan
{
    class Wyznacznik
    {
        private int N = 3;
        private int[][] tab;
        public Wyznacznik(int[][] tablica, int rozmiar)
        {
            this.N = rozmiar;
            tab = tablica;
        }
        private int wartosc()
        {
            int w = 0;
            int s = 1;
            // linijki dodatnie
            for(int i = 0; i < N; i++)
            {
                s = 1;
                for (int j = i; j < N + i; j++)
                    s *= tab[i][j%N];
                w += s;
            }
            //linijki ujemne
            for (int i = 0; i < N; i++)
            {
                s = 1;
                for (int j = N-1; j >=0 ; j--) //tu
                    s *= tab[i][j-i];//tu
                w -= s;
            }
            return w;
        }
        public override string ToString()
        {
            return "Wyznacznik";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
