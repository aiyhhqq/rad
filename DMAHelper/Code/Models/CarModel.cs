namespace DMAHelper.Code.Models
{
    public class CarModel
    {
        public string CarClass { get; set; }
        public string CarName { get; set; }
        public ulong RootComponent { get; set; }
        public ulong pObjPointer { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }
}