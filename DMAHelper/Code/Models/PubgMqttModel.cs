using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMAHelper.Code.Models
{
    public class PubgMqttModel
    {
        public string Map { get; set; }
        public List<List<object>> Game = new List<List<object>>();
        public List<PlayerModel> MyTeam { get; set; } = new List<PlayerModel>();
        public string MyName { get; set; }

         public List<List<object>> Car { get; set; } = new List<List<object>>();
        public List<string> Box { get; set; } = new List<string>();
        public List<List<object>> Goods { get; set; } = new List<List<object>>();
        public List<List<object>> Player { get; set; } = new List<List<object>>();
    }
}
