using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Event
    {
        public string Name { set; get; }
        public int CountHuman { set; get; }
        public string Place { set; get; }
        public DateTime DataEvent { set; get; }

        int id = -1;
        int Id { get; }

        static int Count = 0;
        public Client Client { set; get; }

        public Event(string name, int countHuman, string plase,Client client, DateTime dateTime )
        {
            Name = name;
            CountHuman = countHuman;
            Place = plase;
            DataEvent = dateTime;
            Client = client;
            Count++;
            id = Count;
        }

        public void AddDays(int count)
        {
            DataEvent = DataEvent.AddDays(count);
        }
        public void AddWeeks(int count)
        {
            DataEvent = DataEvent.AddDays(count * 7);
        }

        public override string ToString()
        {
            return $"Event {Name} ID: {Id}\nData: {DataEvent}\nPlace: {Place}\nCount Human: {CountHuman}";
        }
    }
}
