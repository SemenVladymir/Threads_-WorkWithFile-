
    internal class Program
    {
        private static string[]? dataString;
        private static AutoResetEvent waitHandler = new AutoResetEvent(true);


        private static void ReadFile()
        {
            waitHandler.WaitOne();
            if (File.Exists("D:\\Timer.txt"))
            {
                
                dataString = File.ReadAllLines("D:\\Timer.txt");
                
                if (dataString.Length > 0)
                {
                    foreach (var line in dataString)
                    {
                        Console.WriteLine(line);
                    }
                Console.WriteLine("---------");
                }
            }
            waitHandler.Set();
        }


        private static void Summ()
        {
            int summ = 0;
            waitHandler.WaitOne();
            if (dataString != null && dataString.Length >0)
            {
                foreach (string item in dataString)
                {
                    if(int.TryParse(item, out int x))
                        summ += x;
                }
                Console.WriteLine($"Summ = {summ}");
            }
            waitHandler.Set();
        }

        static void Main(string[] args)
        {
            Thread th1 = new Thread(ReadFile);
            th1.Start();

            Thread th2 = new Thread(Summ);
            th2.Start();
        }
    }