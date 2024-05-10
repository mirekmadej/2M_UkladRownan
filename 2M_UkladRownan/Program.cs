namespace _2M_UkladRownan
{
    class Wyznacznik
    {
        private int N = 3;
        private int[,] tab;
        public int wynik { get {  return wartosc(); } }
        public Wyznacznik(int[,] tablica, int rozmiar)
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
                    s *= tab[j%N,(j+i)%N];
                w += s;
                
            }
            for (int i = 0; i < N; i++)
            {
                s = 1;
                for (int j = N-1-i; j >=0-i ; j--) //tu
                    s *= tab[N-j-1-i,(N+j)%N];//tu
                w -= s;
            }
            return w;
        }
        public override string ToString()
        {
            return $"Wyznacznik {wynik}";
        }
    }
    internal class Program
    {
        private static int[,] tablica(int[,] tab, int[] w, int n, int poz)
        {
            int[,] t = new int [n,n];
            for(int i = 0;i<n; i++)
                for(int j = 0; j<n; j++)
                    t[i,j] = tab[i,j];
            for(int i = 0;i<n;i++)
                t[i,poz] = w[i];
            return t;
        }
        static void Main(string[] args)
        {
            int n = 3;
            int[,] tab = {
                { 2,  3, -1 },
                { 1, -1,  1 },
                {-1,  2, -3 }
            };
            int[] wolne = [11, 0, 12];
            Wyznacznik w0 = new Wyznacznik(tab, n);
            int wy0 = w0.wynik;
            Console.WriteLine("W0=" + wy0);
            Wyznacznik w1 = new Wyznacznik(tablica(tab, wolne, n, 0), n);
            int wy1 = w1.wynik;
            Console.WriteLine("W1=" + wy1);
            Wyznacznik w2 = new Wyznacznik(tablica(tab, wolne, n, 1), n);
            int wy2 = w2.wynik;
            Console.WriteLine("W2=" + wy2);
            Wyznacznik w3 = new Wyznacznik(tablica(tab, wolne, n, 2), n);
            int wy3 = w3.wynik;
            Console.WriteLine("W3=" + wy3);
            Console.WriteLine("Rozwiązania:");
            Console.WriteLine("x=" + 1.0 * wy1 / wy0);
            Console.WriteLine("y=" + 1.0 * wy2 / wy0);
            Console.WriteLine("z=" + 1.0 * wy3 / wy0);
        }
    }
}
