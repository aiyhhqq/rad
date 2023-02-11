using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMAHelper.Code
{
    public  class Offset
    {
         
        public ulong Offset_AcknowledgedPawn { get; set; } = 0x0478;
        public ulong Offset_GWorld { get; set; } = 0x08D3B500;
        public ulong Offset_XenuineDecrypt { get; set; } = 0x07117628;
        public ulong Offset_FNameEntry { get; set; } = 0x08F105A0;
        public int Offset_ChunkSize { get; set; } = 0x41B8;
        public ulong Offset_ObjID { get; set; } = 0x24;
        public   uint Offset_XorKey1 { get; set; } = 0x65D2A73B;
        public   long Offset_XorKey2 { get; set; } = 0xE9C2FC83;
        public   int Offset_RorValue { get; set; } = 0x02;
        public   bool Offset_IsingRor { get; set; } = true;
        public ulong Offset_CharacterName { get; set; } = 0x0F90;
        public ulong Offset_CurrentLevel { get; set; }= 0x08E8;
        public ulong Offset_Actors { get; set; } = 0x0110;
        public ulong Offset_AimOffsets { get; set; } = 0x1670;
        public ulong Offset_ItemInformationComponent { get; set; } = 0x00B0;
        public ulong Offset_ItemID { get; set; } = 0x248;
        public ulong Offset_DroppedItem { get; set; } = 0x420;
        public ulong Offset_DroppedItemGroup { get; set; } = 0x40;
        public ulong Offset_DroppedItemGroup_UItem { get; set; } = 0x748;
        public ulong Offset_SpectatedCount { get; set; } = 0x0F0C;
        public ulong Offset_LerpSafetyZoneRadius { get; set; } = 0x0480;
        public ulong Offset_LerpSafetyZonePosition { get; set; } = 0x06F4;
        public ulong Offset_PoisonGasWarningPosition { get; set; } = 0x0518;
        public ulong Offset_PoisonGasWarningRadius { get; set; } = 0x0754;
        public ulong Offset_RedZonePosition { get; set; } = 0x0524;
        public ulong Offset_RedZoneRadius { get; set; } = 0x054C;
        public ulong Offset_GameState { get; set; } = 0x420;
        public ulong Offset_WorldLocation { get; set; } = 0x09D0;
        public ulong Offset_Mesh { get; set; } = 0x4B0;
        public ulong Offset_Health { get; set; } = 0x1AE0;
        public ulong Offset_GroggyHealth { get; set; } = 0x10D0;
        public ulong Offset_PlayerState { get; set; } = 0x420;
        public ulong Offset_LastTeamNum { get; set; } = 0x1AA0;
        public ulong Offset_PlayerController { get; set; } = 0x0038;
        public ulong Offset_LocalPlayersPTR { get; set; } = 0x08E73770;
        public ulong Offset_PlayerCameraManager { get; set; } = 0x498;
        public ulong Offset_CameraLocation { get; set; } = 0x1018;
        public ulong Offset_PlayerStatistics { get; set; } = 0x4B8;
        public ulong Offset_RootComponent { get; set; } = 0x03A0;
        //有的叫position
        public ulong Offset_ComponentLocation { get; set; } = 0x2A0;
    }
}
