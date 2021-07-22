using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResBase
{
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Coast { get; set; }
        public int Rank { get; set; }
    }

    public class Menu
    {
        public IList<Food> food { get; set; }
    }


}
