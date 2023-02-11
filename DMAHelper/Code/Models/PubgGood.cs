using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMAHelper.Code.Models
{
    public class PubgGood
    {
        public int x { get; set; }
        public int y { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public int group { get; set; }
        public ulong ItemObject { get; set; }
        public ulong UItemAddress { get; set; }
        public ulong UItemIDAddress { get; set; }
        public uint UItemID { get; set; }
        public ulong fNamePtr { get; set; }
        public ulong fName { get; set; }
        public bool isShow { get; set; }
    }
}
