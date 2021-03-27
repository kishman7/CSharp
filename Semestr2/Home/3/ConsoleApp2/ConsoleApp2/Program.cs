using System;

namespace ConsoleApp2
{
    class Program
    {

        static Event[] ListEvent = new Event[0];
        static Client[] ListClients = new Client[0];
        static void Main(string[] args)
        {
            int act = 1;
            while (act != 0)
            {
                Console.WriteLine("1. Add Client\n2. Add Even\n3. Remove Event\n4. Clear Events\n5. Searh Events whis data\n6. Searh Events from > to\n7. Searh Events whis Client");
                act = Convert.ToInt32(Console.ReadLine());
                switch (act)
                {
                    case 1:
                        {
                            AddClient();
                            break;
                        }
                    case 2:
                        {

                            if (ListClients.Length == 0)
                            {
                                Console.WriteLine("First Add Client!");
                            }
                            else
                            {
                                int id = PrintClient();
                                AddEvent(ListClients[id]);
                            }
                            break;
                        }
                    case 3:
                        {
                            RemoveEvent();
                            break;
                        }
                    case 4:
                        {
                            Array.Resize(ref ListEvent, 0);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Searh whis data");
                            SearhEventsData();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Searh whis data range");
                            SearhEventsDataRange();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Searh whis Client");
                            SearhEventsClient();
                            break;
                        }
                }
            }
        }

        static void AddClient()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            string telephone = "";

            bool tryNam = true;
            while (tryNam)
            {
                Console.WriteLine("Enter Telephone");
                telephone = Console.ReadLine();
                tryNam = !IsDigitsOnly(telephone);
                if (telephone.Length < 10)
                    Console.WriteLine("Min 10 symbols");
            }

            Array.Resize(ref ListClients, ListClients.Length + 1);
            ListClients[ListClients.Length - 1] = new Client(name, telephone);

        }
        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    Console.WriteLine("Not correct number");
                    return false;
                }
            }

            return true;
        }
        static int PrintClient()
        {
            Console.WriteLine("Select client:");
            for (int i = 0; i < ListClients.Length; i++)
                Console.WriteLine($"{i}. {ListClients[i].ToString()}");

            int client = Int32.Parse(Console.ReadLine());
            if (client >= 0 && client < ListClients.Length)
                return client;

            Console.WriteLine("Select not corect");
            return PrintClient();
        }
        static void AddEvent(Client c)
        {
            Console.WriteLine("Enter Event name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Count Guests:");
            int guests = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter place:");
            string place = Console.ReadLine();

            Array.Resize(ref ListEvent, ListEvent.Length + 1);
            ListEvent[ListEvent.Length - 1] = new Event(name, guests, place, c, GetData());
        }
        static DateTime GetData()
        {
            Console.WriteLine("Enter data event (01/01/2001):");
            DateTime data = DateTime.Parse(Console.ReadLine());
            if (data > DateTime.Now)
                return data;

            Console.WriteLine("Not correct data");
            return GetData();
        }
        static void RemoveEvent()
        {
            Console.WriteLine("Select  id Event for remove:");
            for (int i = 0; i < ListEvent.Length; i++)
                Console.WriteLine($"{i}. {ListEvent[i].ToString()}");

            int id = Int32.Parse(Console.ReadLine());
            if (id >= 0 && id < ListEvent.Length)
            {
                ListEvent[id] = ListEvent[ListEvent.Length - 1];
                Array.Resize(ref ListEvent, ListEvent.Length - 1);
            }
            else
            {
                Console.WriteLine("Id not correct");
                RemoveEvent();
            }
        }

        static void SearhEventsData()
        {
            DateTime data = GetData();
            foreach (Event e in ListEvent)
                if (data.Date == e.DataEvent.Date)
                    Console.WriteLine(e.ToString());
        }
        static void SearhEventsDataRange()
        {
            Console.WriteLine("Enter data 1:");
            DateTime data = GetData();
            Console.WriteLine("Enter data 2:");
            DateTime data2 = GetData();
            foreach (Event e in ListEvent)
                if (data.Date <= e.DataEvent.Date && data2.Date >= e.DataEvent.Date)
                    Console.WriteLine(e.ToString());
        }
        static void SearhEventsClient()
        {
            Client client = ListClients[PrintClient()];

            foreach (Event e in ListEvent)
                if (client == e.Client)
                    Console.WriteLine(e.ToString());
        }
    }
}