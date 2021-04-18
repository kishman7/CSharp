using System;
using System.Collections.Generic;
using System.Text;

namespace BildHouse
{
    interface IWorker
    {
        public House House { set; get; }
        public void Working();
    }
}
