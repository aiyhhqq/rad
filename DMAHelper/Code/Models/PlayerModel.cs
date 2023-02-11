using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace DMAHelper.Code.Models
{
    public  class PlayerModel
    {
        internal bool bIsAimed;
        internal bool isBot;
        public bool IsMyTeam { get; set; }
        public string Name { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float HP { get; set; }
        public int SpectatedCount { get; set; }
        public int TeamId { get; set; }
        public int KillCount { get; internal set; }
        public float Orientation { get; internal set; }
        public Vector3D ActorLocation { get; internal set; }
        public float Distance { get; internal set; }
    }
}
