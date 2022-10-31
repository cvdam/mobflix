using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobflix.Model
{
    [Serializable]
    public class MBCategory
    {
        public int id { get; set; }
        public string Name { get; set; }
        public Color ButtonColor { get; set; }
        public string ButtonColorCode { get; set; }
        public List<MBCategory> categoryList { get; set; }

        public MBCategory()
        {
            categoryList = new List<MBCategory>();
        }
    }
}
