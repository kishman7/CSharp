using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanning
{
    class Event
    {
        public string NameEvent { set; get; }
        public string Place { set; get; }
        public DateTime Date { set; get; }
        public int Priority { set; get; }

        public override string ToString()
        {
            return $" {NameEvent} {Place} {Date} Priority = {Priority}";
        }
    }
}
