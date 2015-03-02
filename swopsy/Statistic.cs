using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swopsy
{
    public class Statistic
    {
        public Statistic(string name)
        {
            Stat = name;
            Value = 0;
        }

        public string Stat { get; set; }
        public int Value { get; set; }
    }

}
