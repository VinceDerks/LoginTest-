using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginTest.Model
{
    public class Destination
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string TimeArrive { get; set; }
        public string TimeDepart { get; set; }
        public string TypeOf { get; set; }
        public byte[] Image { get; set; }
        public string Status { get; set; }
    }

    public class Route
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }

    }
}
