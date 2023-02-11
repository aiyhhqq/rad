using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace DMAHelper.Code.Models
{
    public  class ZhiZhenModel
    {  
        public ulong pObjPointer { get; set; }
        public int actorId { get; set; }
        public uint objId { get; set; }
        public float groggyHp { get; set; }

        public ulong fNamePtr { get; set; }
        public ulong fName { get; set; }
        public string className { get; set; }
        public ulong CharacterId { get; set; }
        public string Name { get; set; }
        public float Hp { get; set; }
        public int SpectatedCount { get; set; }
        public int teamNum { get; set; }
        public int KillCount { get; set; }
        public ulong  PlayerState { get; set; }
        public float Direction { get; set; }
        public ulong MeshAddr { get; set; }
        public Vector3D actorLocation { get; set; }
        public Vector3D aimFov { get; set; }
        public float Orientation { get; set; }

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public bool isBot { get; set; }
        public float AmiMz { get; set; }
        public bool bIsAimed { get; set; }
        public float Distance { get; set; }
        public ulong ItemGroupPtr { get; set; }
        public int ItemCount { get; set; }
        
    }
    
}
