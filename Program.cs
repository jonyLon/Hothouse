namespace Hothouse
{

    delegate void HotHouseDeleg(Hothouse house);
    class Hothouse
    {
        private int temp = 10;
        private int maxt = 30;
        private int mint = 0;

        public int Temperature { get => temp; set {
            if (value > maxt) {
                temp = value;
                TooHot?.Invoke(this);
                Console.WriteLine("It is too hot in Hothouse");
            }
            else if (value < 0)
            {
                temp = value;
                TooCold?.Invoke(this);
                Console.WriteLine("It is too cool in Hothouse");
            } else {
                    temp = value;
                    Well?.Invoke(this);
                    Console.WriteLine("It is normal in Hothouse");
            }
            } }


        public event HotHouseDeleg? TooHot;
        public event HotHouseDeleg? TooCold;
        public event HotHouseDeleg? Well;
    }

    class Heater
    {
        public void Warm(Hothouse h)
        {
            h.Temperature += 5;
            Console.WriteLine();
            Console.WriteLine("\tHeater warms hothouse");
            Console.WriteLine();
        }
    }

    class Cooler
    {
        public void Cool(Hothouse h)
        {
            h.Temperature -= 5;
            Console.WriteLine();
            Console.WriteLine("\tCooler cools hothouse");
            Console.WriteLine();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            Hothouse hothouse = new Hothouse();
            Heater heater = new Heater();
            Cooler cooler = new Cooler();

            hothouse.TooHot += cooler.Cool;
            hothouse.TooCold += heater.Warm;

            while (Console.ReadKey().Key != ConsoleKey.Spacebar)
            {
                Random random = new Random();
                int chage = random.Next(-2,3);
                hothouse.Temperature += chage;
                Console.WriteLine(hothouse.Temperature);
            }
        }
    }
}