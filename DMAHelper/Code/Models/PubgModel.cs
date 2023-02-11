using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMAHelper.Code.Models
{
    public  class PubgModel
    {
        public List<PlayerModel> Player { get; set; } = new List<PlayerModel>();
        public string MapName { get; set; }
        public List<CarModel> Cars { get; set; }

        public List<PubgGood> PubgGoods { get; set; }
        public string MyName { get; set; }
        public List<List<object>> Game = new List<List<object>>();
        public List<PlayerModel> MyTeam { get; set; } = new List<PlayerModel>();

    }
}
