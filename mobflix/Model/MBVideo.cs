using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace mobflix.Model
{
    [Serializable]
    public  class MBVideo
    { 
        public int id { get; set; }
        public  Color ButtonColor { get; set; }
        public string ButtonColorCode { get; set; }
        public  string Url { get; set; }
        public  string Category { get; set; }
        public  List<MBVideo> videoList { get; set; }

        public MBVideo()
        {
            videoList = new List<MBVideo>();
        }

    }
}
