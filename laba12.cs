namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {

            mainmenu maain = new mainmenu();
            int a;
            List<bok> boki = maain.zapolnenie();
            do
            {
                maain.menu();
                a = Convert.ToInt32(Console.ReadLine());
                if (a >= 1 && a <= 5)
                {
                    switch (a)
                    {
                        case 1:
                            Console.Clear();
                            maain.viborkapoizd(boki);
                            break;
                        case 2:
                            Console.Clear();
                            maain.viborkapoavtore(boki);
                            break;
                        case 3:
                            maain.kniginarukax(boki);
                            Console.Clear();
                            break;
                        case 4:
                            maain.knigivintervale(boki);
                            Console.Clear();
                            break;
                        case 5:
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка");
                }
            }
            while (a != 5);
        }
    }
    public class bok
    {
        public string? avtor;
        public string? proiz;
        public string? id;
        public string? god;
        public string? naimizdan;
        public string? zhanr;
        public List<string> dati = new List<string>();
    }
    public class mainmenu
    {
        public List<bok> zapolnenie()
        {
            Console.WriteLine("Введите кол-во книг:");
            List<bok> book1 = new List<bok>();
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                bok books = new bok();
                Console.WriteLine("Введите автора:");
                books.avtor = Console.ReadLine();
                Console.WriteLine("Название произведения:");
                books.proiz = Console.ReadLine();
                Console.WriteLine("ID:");
                books.id = Console.ReadLine();
                Console.WriteLine("Год издания:");
                books.god = Console.ReadLine();
                Console.WriteLine("Название издательства:");
                books.naimizdan = Console.ReadLine();
                Console.WriteLine("Жанр:");
                books.zhanr = Console.ReadLine();
                while (true)
                {
                    Console.WriteLine("Дата выдачи(год.месяц.день):");
                    string? datavid = Console.ReadLine();
                    if (datavid == "")
                    {
                        break;
                    }
                    Console.WriteLine("Дата сдачи(год.месяц.день), если книга еще на руках - :");
                    string? datasdach = Console.ReadLine();
                    books.dati.Add(datavid + " " + datasdach);
                }
                book1.Add(books);
            }
            return book1;
        }
        public void menu()
        {
            Console.WriteLine("Выборки:");
            Console.WriteLine("1.По издательству");
            Console.WriteLine("2.По автору");
            Console.WriteLine("3.Книги на руках");
            Console.WriteLine("4.Книги в интервале");
            Console.WriteLine("5.Выход");
        }
        public void viborkapoizd(List<bok> boki)
        {
            Console.WriteLine("Введите издание:");
            string? izd = Console.ReadLine();
            foreach (bok c in boki)
            {
                if (izd == c.naimizdan)
                {
                    Console.WriteLine("==============================");
                    Console.WriteLine($"Автор:{c.avtor}");
                    Console.WriteLine($"Произведение:{c.proiz}");
                    Console.WriteLine($"ID:{c.id}");
                    Console.WriteLine($"Год издания:{c.god}");
                    Console.WriteLine($"Название издания:{c.naimizdan}");
                    Console.WriteLine($"Жанр:{c.zhanr}");
                    foreach (string f in c.dati)
                    {
                        Console.WriteLine($"Даты выдачи и сдачи:{f}");
                    }
                    Console.WriteLine("==============================");
                }
            }

        }
        public void viborkapoavtore(List<bok> boki)
        {
            Console.WriteLine("Введите издание:");
            string? avtor = Console.ReadLine();
            foreach (bok c in boki)
            {
                if (avtor == c.naimizdan)
                {
                    Console.WriteLine("==============================");
                    Console.WriteLine($"Автор:{c.avtor}");
                    Console.WriteLine($"Произведение:{c.proiz}");
                    Console.WriteLine($"ID:{c.id}");
                    Console.WriteLine($"Год издания:{c.god}");
                    Console.WriteLine($"Название издания:{c.naimizdan}");
                    Console.WriteLine($"Жанр:{c.zhanr}");
                    foreach (string f in c.dati)
                    {
                        Console.WriteLine($"Даты выдачи и сдачи:{f}");
                    }
                    Console.WriteLine("==============================");
                }
            }
        }
        public void kniginarukax(List<bok> boki)
        {
            foreach (bok c in boki)
            {
                foreach (string f in c.dati)
                {
                    string[] baro = f.Split(" ");
                    if (baro[1] == "-")
                    {
                        Console.WriteLine("==============================");
                        Console.WriteLine($"Автор:{c.avtor}");
                        Console.WriteLine($"Произведение:{c.proiz}");
                        Console.WriteLine($"ID:{c.id}");
                        Console.WriteLine($"Год издания:{c.god}");
                        Console.WriteLine($"Название издания:{c.naimizdan}");
                        Console.WriteLine($"Жанр:{c.zhanr}");
                        foreach (string k in c.dati)
                        {
                            Console.WriteLine($"Даты выдачи и сдачи:{k}");
                        }
                        Console.WriteLine("==============================");
                        break;
                    }
                }
            }
        }
        public void knigivintervale(List<bok> boki)
        {
            foreach (bok c in boki)
            {
                foreach (string f in c.dati)
                {
                    string[] baro = f.Split(" ");
                    Console.WriteLine("Введите интервал (год.месяц.день) через -");
                    string? interval = Console.ReadLine();
                    string[] array = interval.Split("-");
                    DateTime vidtime = DateTime.Parse(baro[0]);
                    DateTime sdachtime = DateTime.Parse(baro[1]);
                    DateTime interval1 = DateTime.Parse(array[0]);
                    DateTime interval2 = DateTime.Parse(array[1]);
                    if (baro[1] == "-")
                    {
                        continue;
                    }
                    if (vidtime>=interval1 && interval2<=sdachtime)
                    {
                        Console.WriteLine("==============================");
                        Console.WriteLine($"Автор:{c.avtor}");
                        Console.WriteLine($"Произведение:{c.proiz}");
                        Console.WriteLine($"ID:{c.id}");
                        Console.WriteLine($"Год издания:{c.god}");
                        Console.WriteLine($"Название издания:{c.naimizdan}");
                        Console.WriteLine($"Жанр:{c.zhanr}");
                        foreach (string k in c.dati)
                        {
                            Console.WriteLine($"Даты выдачи и сдачи:{k}");
                        }
                        Console.WriteLine("==============================");
                        break;
                    }
                }
            }
        }
    }
}