using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using vmmsharp;
using DMAHelper.Code.Models;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using System.IO;
using System.Security.Cryptography;
using System.Timers;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using DMAHelper.Code;
using System.Globalization;

namespace DMAHelper
{
    //变量和数据类型
    public class pubg
    {
        //变量 isKaiWuZi是一个变量名，类型是bool，就是只有true和false的类型。
        public bool isKaiWuZi = false;
        Vmm vmm;
        uint pid = 0;
        #region 偏移
        ulong moduleBase;
        ulong GNamesAddress;

        #endregion

        
        //public 关键字是类型和类型成员的访问修饰符。 公共访问是允许的最高访问级别。 对访问公共成员没有限制。
        //private：编程语句在模块级别中使用，用于声明私有变量及分配存储空间
        //首先定义一个全局变量private List<Control>
        private List<CarModel> listCar = new List<CarModel>();
        public delegate ulong DecryptData(ulong c);
        public event Action<PubgModel> OnPlayerListUpdate;
        DecryptData decryptFunc;
        PlayerModel myModel = null;
        public event Action<long, string> OnExecTime;
        List<GoodItem> goodItems = new List<GoodItem>();
        bool isLocal = false;
        Offset off = new Offset();
        public pubg()
        {
            #region 载具列表
            listCar.Add(new CarModel()
            {
                CarClass = "AirBoat_V2_C",
                CarName = "汽艇"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "AquaRail_A_01_C",
                CarName = "摩托艇"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "AquaRail_A_02_C",
                CarName = "摩托艇"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "AquaRail_A_03_C",
                CarName = "摩托艇"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "AquaRail_C",
                CarName = "摩托艇"
            });

            listCar.Add(new CarModel()
            {
                CarClass = "BP_ATV_C",
                CarName = "全地形车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_BRDM_C",
                CarName = "装甲车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Bicycle_C",
                CarName = "自行车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_CoupeRB_C",
                CarName = "跑车RB"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_DO_Circle_Train_Merged_C",
                CarName = "火车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_DO_Line_Train_Dino_Merged_C",
                CarName = "火车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_DO_Line_Train_Merged_C",
                CarName = "火车"
            });

            listCar.Add(new CarModel()
            {
                CarClass = "BP_Dirtbike_C",
                CarName = "越野摩托"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Food_Truck_C",
                CarName = "食品运输车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_EmergencyPickupVehicle_C",
                CarName = "紧急取件"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_KillTruck_C",
                CarName = "杀戮卡车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_LootTruck_C",
                CarName = "物资车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_M_Rony_A_01_C",
                CarName = "罗尼车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_M_Rony_A_02_C",
                CarName = "罗尼车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_M_Rony_A_03_C",
                CarName = "罗尼车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_McLarenGT_Lx_Yellow_C",
                CarName = "迈凯轮"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_McLarenGT_St_black_C",
                CarName = "迈凯轮"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_McLarenGT_St_white_C",
                CarName = "迈凯轮"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Mirado_A_02_C",
                CarName = "跑车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Mirado_A_03_Esports_C",
                CarName = "跑车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Mirado_Open_03_C",
                CarName = "跑车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Mirado_Open_04_C",
                CarName = "跑车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Mirado_Open_05_C",
                CarName = "跑车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Motorbike_04_C",
                CarName = "摩托车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Motorbike_04_Desert_C",
                CarName = "摩托车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Motorbike_Solitario_C",
                CarName = "摩托车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Motorbike_04_SideCar_C",
                CarName = "三轮摩托"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Motorbike_04_SideCar_C",
                CarName = "三轮摩托"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Motorglider_C",
                CarName = "滑翔机"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Motorglider_Green_C",
                CarName = "滑翔机"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Niva_01_C",
                CarName = "雪地车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Niva_02_C",
                CarName = "雪地车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Niva_03_C",
                CarName = "雪地车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Niva_04_C",
                CarName = "雪地车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Niva_05_C",
                CarName = "雪地车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Niva_06_C",
                CarName = "雪地车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Niva_07_C",
                CarName = "雪地车"
            });

            listCar.Add(new CarModel()
            {
                CarClass = "BP_PickupTruck_A_01_C",
                CarName = "皮卡车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_PickupTruck_A_02_C",
                CarName = "皮卡车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_PickupTruck_A_03_C",
                CarName = "皮卡车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_PickupTruck_A_04_C",
                CarName = "皮卡车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_PickupTruck_A_05_C",
                CarName = "皮卡车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_PickupTruck_A_esports_C",
                CarName = "皮卡车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_PickupTruck_B_01_C",
                CarName = "皮卡车(敞篷)"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_PickupTruck_B_02_C",
                CarName = "皮卡车(敞篷)"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_PickupTruck_B_03_C",
                CarName = "皮卡车(敞篷)"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_PickupTruck_B_04_C",
                CarName = "皮卡车(敞篷)"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_PickupTruck_B_05_C",
                CarName = "皮卡车(敞篷)"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Pillar_Car_C",
                CarName = "●警车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_PonyCoupe_C",
                CarName = "新能源"
            });

            listCar.Add(new CarModel()
            {
                CarClass = "BP_Porter_C",
                CarName = "货拉拉"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Scooter_01_A_C",
                CarName = "滑板车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Scooter_02_A_C",
                CarName = "滑板车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Scooter_03_A_C",
                CarName = "滑板车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Scooter_04_A_C",
                CarName = "滑板车"
            });

            listCar.Add(new CarModel()
            {
                CarClass = "BP_Snowbike_01_C",
                CarName = "雪地自行车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Snowbike_02_C",
                CarName = "雪地自行车"
            });

            listCar.Add(new CarModel()
            {
                CarClass = "BP_Snowmobile_01_C",
                CarName = "雪地摩托"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Snowmobile_02_C",
                CarName = "雪地摩托"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Snowmobile_03_C",
                CarName = "雪地摩托"
            });

            listCar.Add(new CarModel()
            {
                CarClass = "BP_TukTukTuk_A_01_C",
                CarName = "三轮车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_TukTukTuk_A_02_C",
                CarName = "三轮车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_TukTukTuk_A_03_C",
                CarName = "三轮车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Van_A_01_C",
                CarName = "面包车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Van_A_02_C",
                CarName = "面包车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "BP_Van_A_03_C",
                CarName = "面包车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Boat_PG117_C",
                CarName = "冲锋艇"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "PG117_A_01_C",
                CarName = "冲锋艇"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Buggy_A_01_C",
                CarName = "山地车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Buggy_A_02_C",
                CarName = "山地车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Buggy_A_03_C",
                CarName = "山地车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Buggy_A_04_C",
                CarName = "山地车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Buggy_A_05_C",
                CarName = "山地车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Buggy_A_06_C",
                CarName = "山地车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Buggy_A_07_C",
                CarName = "山地车"
            });

            listCar.Add(new CarModel()
            {
                CarClass = "Dacia_A_01_v2_C",
                CarName = "轿车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Dacia_A_01_v2_snow_C",
                CarName = "轿车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Dacia_A_02_v2_C",
                CarName = "轿车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Dacia_A_03_v2_C",
                CarName = "轿车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Dacia_A_03_v2_Esports_C",
                CarName = "轿车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Dacia_A_04_v2_C",
                CarName = "轿车"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "DummyTransportAircraft_C",
                CarName = "飞机"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "WarModeTransportAircraft_C",
                CarName = "空投飞机"
            });

            listCar.Add(new CarModel()
            {
                CarClass = "EmergencyAircraft_Tiger_C",
                CarName = "应急飞机"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "MortarPawn_C",
                CarName = "迫击炮"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "ParachutePlayer_C",
                CarName = "降落伞"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "ParachutePlayer_Warmode_C",
                CarName = "降落伞"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "RedeployAircraft_Tiger_C",
                CarName = "直升机"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "TransportAircraft_Chimera_C",
                CarName = "直升机"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "TransportAircraft_Tiger_C",
                CarName = "直升机"
            });

            listCar.Add(new CarModel()
            {
                CarClass = "Uaz_A_01_C",
                CarName = "吉普车(敞篷)"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Uaz_Armored_C",
                CarName = "吉普车(armored)"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Uaz_B_01_C",
                CarName = "吉普车(软)"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Uaz_B_01_esports_C",
                CarName = "吉普车(软)"
            });
            listCar.Add(new CarModel()
            {
                CarClass = "Uaz_C_01_C",
                CarName = "吉普车(硬)"
            });

            #endregion

            if (File.Exists("offset.txt"))
            {
                try
                {
                    var jo = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("offset.txt"));
                    off = new Offset()
                    {
                        Offset_AcknowledgedPawn = ZhuanHuan(jo["Offset_AcknowledgedPawn"]),
                        Offset_GWorld = ZhuanHuan(jo["Offset_GWorld"]),
                        Offset_XenuineDecrypt = ZhuanHuan(jo["Offset_XenuineDecrypt"]),
                        Offset_FNameEntry = ZhuanHuan(jo["Offset_FNameEntry"]),
                        Offset_ChunkSize = ZhuanHuanint(jo["Offset_ChunkSize"]),
                        Offset_ObjID = ZhuanHuan(jo["Offset_ObjID"]),
                        Offset_XorKey1 = ZhuanHuanUint(jo["Offset_XorKey1"]),
                        Offset_XorKey2 = ZhuanHuanLong(jo["Offset_XorKey2"]),
                        Offset_RorValue = ZhuanHuanint(jo["Offset_RorValue"]),
                        Offset_Actors = ZhuanHuan(jo["Offset_Actors"]),
                        Offset_AimOffsets = ZhuanHuan(jo["Offset_AimOffsets"]),
                        Offset_CameraLocation = ZhuanHuan(jo["Offset_CameraLocation"]),
                        Offset_CharacterName = ZhuanHuan(jo["Offset_CharacterName"]),
                        Offset_ComponentLocation = ZhuanHuan(jo["Offset_ComponentLocation"]),
                        Offset_CurrentLevel = ZhuanHuan(jo["Offset_CurrentLevel"]),
                        Offset_DroppedItem = ZhuanHuan(jo["Offset_DroppedItem"]),
                        Offset_DroppedItemGroup = ZhuanHuan(jo["Offset_DroppedItemGroup"]),
                        Offset_DroppedItemGroup_UItem = ZhuanHuan(jo["Offset_DroppedItemGroup_UItem"]),
                        Offset_GameState = ZhuanHuan(jo["Offset_GameState"]),
                        Offset_GroggyHealth = ZhuanHuan(jo["Offset_GroggyHealth"]),
                        Offset_Health = ZhuanHuan(jo["Offset_Health"]),
                        Offset_ItemID = ZhuanHuan(jo["Offset_ItemID"]),
                        Offset_ItemInformationComponent = ZhuanHuan(jo["Offset_ItemInformationComponent"]),
                        Offset_LastTeamNum = ZhuanHuan(jo["Offset_LastTeamNum"]),
                        Offset_LerpSafetyZonePosition = ZhuanHuan(jo["Offset_LerpSafetyZonePosition"]),
                        Offset_LerpSafetyZoneRadius = ZhuanHuan(jo["Offset_LerpSafetyZoneRadius"]),
                        Offset_LocalPlayersPTR = ZhuanHuan(jo["Offset_LocalPlayersPTR"]),
                        Offset_Mesh = ZhuanHuan(jo["Offset_Mesh"]),
                        Offset_PlayerCameraManager = ZhuanHuan(jo["Offset_PlayerCameraManager"]),
                        Offset_PlayerController = ZhuanHuan(jo["Offset_PlayerController"]),
                        Offset_PlayerState = ZhuanHuan(jo["Offset_PlayerState"]),
                        Offset_PoisonGasWarningPosition = ZhuanHuan(jo["Offset_PoisonGasWarningPosition"]),
                        Offset_RedZoneRadius = ZhuanHuan(jo["Offset_RedZoneRadius"]),
                        Offset_PlayerStatistics = ZhuanHuan(jo["Offset_PlayerStatistics"]),
                        Offset_RedZonePosition = ZhuanHuan(jo["Offset_RedZonePosition"]),
                        Offset_PoisonGasWarningRadius = ZhuanHuan(jo["Offset_PoisonGasWarningRadius"]),
                        Offset_RootComponent = ZhuanHuan(jo["Offset_RootComponent"]),
                        Offset_SpectatedCount = ZhuanHuan(jo["Offset_SpectatedCount"]),
                        Offset_WorldLocation = ZhuanHuan(jo["Offset_WorldLocation"]),
                        Offset_IsingRor = jo["Offset_IsingRor"].Value<bool>()
                    };
                }
                catch (Exception)
                {


                }

            }
        }
        ulong ZhuanHuan(JToken tk)
        {
            if (tk.Type == JTokenType.String)
            {
                string j = tk.Value<string>();
                return ulong.Parse(j, NumberStyles.HexNumber);
            }
            else
            {
                return tk.Value<ulong>();
            }
        }
        uint ZhuanHuanUint(JToken tk)
        {
            if (tk.Type == JTokenType.String)
            {
                string j = tk.Value<string>();
                return uint.Parse(j, NumberStyles.HexNumber);
            }
            else
            {
                return tk.Value<uint>();
            }
        }
        int ZhuanHuanint(JToken tk)
        {
            if (tk.Type == JTokenType.String)
            {
                string j = tk.Value<string>();
                return int.Parse(j, NumberStyles.HexNumber);
            }
            else
            {
                return tk.Value<int>();
            }
        }

        long ZhuanHuanLong(JToken tk)
        {
            if (tk.Type == JTokenType.String)
            {
                string j = tk.Value<string>();
                return long.Parse(j, NumberStyles.HexNumber);
            }
            else
            {
                return tk.Value<long>();
            }
        }

        public uint dec_objid(int value)
        {
            uint v18 = _ROR4_oL_((uint)(value ^ off.Offset_XorKey1), off.Offset_RorValue, off.Offset_IsingRor);
            return v18 ^ (v18 << 16) ^ (uint)off.Offset_XorKey2;
        }

        uint _ROR4_oL_(uint x, int count, bool IsRor)
        {
            count %= 32;
            if (IsRor)
                return (x << (32 - count)) | (x >> count);
            else
                return (x << count) | (x >> (32 - count));
        }


        public bool Init(bool isLocal, out string msg)
        {
            msg = "";
            try
            {

                this.isLocal = isLocal;
                try
                {
                    if (File.Exists("itemfilter.json"))
                    {

                        string jsonStr = File.ReadAllText("itemfilter.json");
                        var jo = JsonConvert.DeserializeObject<JObject>(jsonStr);
                        var v = jo.Properties();
                        foreach (var item in v)
                        {
                            JToken token = item.Root[item.Name];
                            goodItems.Add(new GoodItem() { className = item.Name, shortName = token["shortName"].Value<string>(), showItem = token["showItem"].Value<bool>(), group = token["group"].Value<int>() });
                        }

                    }

                }
                catch (Exception ex)
                {


                }
                if (isLocal)
                {
                    try
                    {
                        vmm = new Vmm("", "-device", "pmem");
                    }
                    catch (Exception e)
                    {
                        msg += "11:" + e.Message;
                        return false;

                    }
                }
                else
                {
                    try
                    {
                        vmm = new Vmm("", "-device", "fpga");
                    }
                    catch (Exception e)
                    {

                    }

                    try
                    {
                        if (vmm == null)
                        {
                            vmm = new Vmm("", "-device", "fpga", "-memmap", "auto");
                        }

                    }
                    catch (Exception e)
                    {
                        msg += "1:" + e.Message;
                        return false;

                    }

                }
                if (vmm == null)
                {
                    msg = "vmm初始化失败";
                    return false;
                }
                // GetMemMap();
                var plist = vmm.PidList();
                foreach (var item in plist)
                {
                    string strKernel32KernelPath = vmm.ProcessGetInformationString(item, Vmm.VMMDLL_PROCESS_INFORMATION_OPT_STRING_PATH_KERNEL);
                    if (strKernel32KernelPath.ToLower().Contains("tslgame.exe"))
                    {
                        moduleBase = vmm.ProcessGetModuleBase(item, "TslGame.exe");
                        if (moduleBase > 0)
                        {
                            var d = vmm.MemReadInt64(item, moduleBase + off.Offset_XenuineDecrypt);
                            if (d > 0)
                            {
                                this.pid = item;
                                break;
                            }
                        }
                    }
                }

                if (pid <= 0)
                {
                    msg = "找不到游戏进程";
                    return false;
                }

                moduleBase = vmm.ProcessGetModuleBase(pid, "TslGame.exe");
                if (moduleBase <= 0)
                {
                    msg = "模块获取失败";
                    return false;
                }
                var DecryptThis = vmm.MemReadInt64(pid, moduleBase + off.Offset_XenuineDecrypt);
                if (DecryptThis > 0)
                {
                    var val2 = vmm.MemReadInt32(pid, DecryptThis + 3);
                    ulong LeaAddr = DecryptThis + val2 + 7;
                    //在自身进程申请的内存
                    var buff = vmm.MemRead(pid, DecryptThis + 7, 100);
                    #region 申请内存，调用方法
                    List<byte> l = new List<byte>();
                    //第一个字节
                    l.Add(0x48);
                    l.Add(0x8B);
                    l.Add(0xD1);
                    l.Add(0x48);
                    l.Add(0xB8);
                    l.AddRange(BitConverter.GetBytes(LeaAddr));
                    l.AddRange(buff);
                    var DecryptData = l.ToArray();
                    //两种申请内存空间
                    //IntPtr addr = Marshal.AllocHGlobal(DecryptData.Length);
                    IntPtr addr = Common.VirtualAlloc(IntPtr.Zero, DecryptData.Length, AllocationType.Commit, MemoryProtection.ExecuteReadWrite);
                    //数据拷贝到申请的内存空间
                    Marshal.Copy(DecryptData, 0, addr, DecryptData.Length);
                    //指针转换成方法
                    decryptFunc = (DecryptData)Marshal.GetDelegateForFunctionPointer(addr, typeof(DecryptData));
                    #endregion 
                    msg = "";
                    return true;
                }
                else
                {
                    msg = "DecryptThis小于0";
                    return false;
                }
            }
            catch (Exception ex)
            {
                msg += "2:" + ex.Message;
                return false;

            }

            msg += "未知错误";
            return false;
        }
        Thread t;
        DateTime dt = DateTime.Now;
        DateTime dtWuZi = DateTime.Now;
        DateTime dtCar = DateTime.Now;
        bool diyici = true;
        public void Start()
        {
            Task.Run(() =>
            {
                try
                {


                    VmmScatter scatter = vmm.Scatter_Initialize(pid, Vmm.FLAG_NOCACHE);
                    List<ZhiZhenModel> ListZhiZhenModel = new List<ZhiZhenModel>();
                    List<PlayerModel> ListPlayer = new List<PlayerModel>();
                    List<PubgGood> goods = new List<PubgGood>();
                    List<CarModel> listCarModel = new List<CarModel>();
                    while (true)
                    {
                        if (isLocal)
                        {
                            Thread.Sleep(30);
                        }
                        ListZhiZhenModel.Clear();
                        ListPlayer.Clear();

                        listCarModel.Clear();
                        dt = DateTime.Now;
                    
                        try
                        {
                            scatter.Clear(pid, Vmm.FLAG_NOCACHE);
                            Stopwatch sw = new Stopwatch();
                            sw.Start();
                            if (scatter != null)
                            {

                                PubgModel model = new PubgModel();
                                ulong world = decryptFunc(vmm.MemReadInt64(pid, moduleBase + off.Offset_GWorld));
                                ulong ULocalPlayer = vmm.MemReadInt64(pid, moduleBase + off.Offset_LocalPlayersPTR);
                                ulong PlayerController = decryptFunc(vmm.MemReadInt64(pid, ULocalPlayer + off.Offset_PlayerController));
                                ulong CameraManager = vmm.MemReadInt64(pid, PlayerController + off.Offset_PlayerCameraManager);
                                Vector3D cameraLocation = vmm.MemReadVector(pid, CameraManager + off.Offset_CameraLocation);
                                ulong PersistentLevel = decryptFunc(vmm.MemReadInt64(pid, world + off.Offset_CurrentLevel));
                                ulong ActorsArray = decryptFunc(vmm.MemReadInt64(pid, PersistentLevel + off.Offset_Actors));
                                uint Actorscount = vmm.MemReadInt32(pid, ActorsArray + 0x08);
                                ulong actorBase = vmm.MemReadInt64(pid, ActorsArray);
                                ulong GNames = decryptFunc(vmm.MemReadInt64(pid, moduleBase + off.Offset_FNameEntry));
                                GNamesAddress = decryptFunc(vmm.MemReadInt64(pid, GNames));
                                // int h = vmm.MemReadInt(pid, world + Offset_WorldLocation + 0x4);
                                uint MapId = dec_objid(vmm.MemReadInt(pid, world + off.Offset_ObjID));
                                ulong LocalPlayerPawn = decryptFunc(vmm.MemReadInt64(pid, PlayerController + off.Offset_AcknowledgedPawn));
                                ulong CharacterId = vmm.MemReadInt64(pid, LocalPlayerPawn + off.Offset_CharacterName);
                                var MyName = vmm.MemReadString(pid, CharacterId, 64);
                                string mapName = GetObjName(MapId);
                                ulong GameState = decryptFunc(vmm.MemReadInt64(pid, world + off.Offset_GameState));
                                if (diyici)
                                {
                                    diyici = false;
                                    //if (OnExecTime != null)
                                    //{
                                    //    OnExecTime(0, $"world={world},ULocalPlayer={ULocalPlayer},PlayerController={PlayerController},CameraManager={CameraManager},PersistentLevel={PersistentLevel},ActorsArray={ActorsArray},Actorscount={Actorscount},actorBase={actorBase},GNames={GNames},MapId={MapId},LocalPlayerPawn={LocalPlayerPawn},CharacterId={CharacterId},MyName={MyName},mapName={mapName},GameState={GameState}");
                                    //}
                                }
                                if (mapName == "TslLobby_Persistent_Main")
                                {
                                    continue;
                                }
                                if (string.IsNullOrEmpty(MyName) && myModel != null)
                                {
                                    MyName = myModel.Name;
                                }
                                model.MapName = mapName;
                                scatter.Prepare(GameState + off.Offset_LerpSafetyZoneRadius, 4);
                                scatter.Prepare(GameState + off.Offset_LerpSafetyZonePosition, 8);
                                scatter.Prepare(GameState + off.Offset_PoisonGasWarningPosition, 8);
                                scatter.Prepare(GameState + off.Offset_PoisonGasWarningRadius, 4);
                                scatter.Prepare(GameState + off.Offset_RedZonePosition, 8);
                                scatter.Prepare(GameState + off.Offset_RedZoneRadius, 4);
                                #region 读取所有类名

                                if (Actorscount > 20000)
                                {
                                    continue;
                                }
                                for (int i = 0; i < Actorscount; i++)
                                {
                                    try
                                    {
                                        scatter.Prepare(actorBase + (ulong)i * 8, 8);

                                    }
                                    catch (Exception ex)
                                    {

                                        Console.WriteLine("lei:" + ex.Message + ex.StackTrace);
                                    }
                                }
                                bool isExec = scatter.Execute();
                                var lerpSafetyGasRadius = scatter.ReadFloat(GameState + off.Offset_LerpSafetyZoneRadius);
                                var lerpSafetyPosition = scatter.ReadVector(GameState + off.Offset_LerpSafetyZonePosition);
                                var poisonGasPosition = scatter.ReadVector(GameState + off.Offset_PoisonGasWarningPosition);
                                var poisonGasRadius = scatter.ReadFloat(GameState + off.Offset_PoisonGasWarningRadius);
                                var redPosition = scatter.ReadVector(GameState + off.Offset_RedZonePosition);
                                var redRadius = scatter.ReadFloat(GameState + off.Offset_RedZoneRadius);
                                for (int i = 0; i < Actorscount; i++)
                                {
                                    ulong pObjPointer = scatter.ReadUInt64(actorBase + (ulong)i * 8);
                                    if (pObjPointer > 0x100000)
                                    {
                                        ListZhiZhenModel.Add(new ZhiZhenModel() { pObjPointer = pObjPointer });


                                    }
                                }
                                //准备actorId
                                scatter.Clear(pid, Vmm.FLAG_NOCACHE);
                                //  scatter = vmm.Scatter_Initialize(pid, Vmm.FLAG_NOCACHE);
                                foreach (var item in ListZhiZhenModel)
                                {
                                    scatter.Prepare(item.pObjPointer + off.Offset_ObjID, 4);
                                }
                                isExec = scatter.Execute();
                                //读取actorId
                                foreach (var item in ListZhiZhenModel)
                                {
                                    int actorId = scatter.ReadInt(item.pObjPointer + off.Offset_ObjID);
                                    uint objId = dec_objid(actorId);
                                    item.actorId = actorId;
                                    item.objId = objId;
                                }
                                //准备fNamePtr
                                scatter.Clear(pid, Vmm.FLAG_NOCACHE);
                                //scatter = vmm.Scatter_Initialize(pid, Vmm.FLAG_NOCACHE);
                                foreach (var item in ListZhiZhenModel)
                                {
                                    scatter.Prepare((GNamesAddress + (ulong)(item.objId / off.Offset_ChunkSize) * 0x8), 8);
                                }
                                isExec = scatter.Execute();
                                //读取fNamePtr 
                                foreach (var item in ListZhiZhenModel)
                                {
                                    ulong fNamePtr = scatter.ReadUInt64((GNamesAddress + (ulong)(item.objId / off.Offset_ChunkSize) * 0x8));
                                    if (fNamePtr > 0)
                                    {
                                        item.fNamePtr = fNamePtr;
                                        scatter.Prepare(fNamePtr + (ulong)(item.objId % off.Offset_ChunkSize) * 0x8, 8);
                                    }
                                }
                                ListZhiZhenModel = ListZhiZhenModel.Where(x => x.fNamePtr > 0).ToList();
                                //准备fName
                                scatter.Clear(pid, Vmm.FLAG_NOCACHE);
                                foreach (var item in ListZhiZhenModel)
                                {
                                    item.fNamePtr = item.fNamePtr;
                                    scatter.Prepare(item.fNamePtr + (ulong)(item.objId % off.Offset_ChunkSize) * 0x8, 8);
                                }
                                isExec = scatter.Execute();
                                //读取fName，
                                foreach (var item in ListZhiZhenModel)
                                {
                                    ulong fName = scatter.ReadUInt64(item.fNamePtr + (ulong)(item.objId % off.Offset_ChunkSize) * 0x8);
                                    if (fName > 0)
                                    {
                                        item.fName = fName;
                                    }
                                }
                                //准备className
                                scatter.Clear(pid, Vmm.FLAG_NOCACHE);
                                ListZhiZhenModel = ListZhiZhenModel.Where(x => x.fName > 0).ToList();
                                foreach (var item in ListZhiZhenModel)
                                {
                                    scatter.Prepare(item.fName + 0x10, 64);
                                }
                                scatter.Execute();
                                //读取className
                                foreach (var item in ListZhiZhenModel)
                                {
                                    string className = scatter.ReadStringASCII(item.fName + 0x10, 64);
                                    item.className = className;
                                }
                                #endregion
                                #region 读取玩家名字 
                                //准备读取CharacterId
                                scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                var listPlay = ListZhiZhenModel.Where(item =>
                                        (!string.IsNullOrEmpty(item.className) && (item.className == "PlayerMale_A_C" ||
                                                                                   item.className == "PlayerFemale_A_C" ||
                                                                                   item.className == "AIPawn_Base_Female_C" ||
                                                                                   item.className == "AIPawn_Base_Male_C" ||
                                                                                   item.className ==
                                                                                   "UltAIPawn_Base_Female_C" ||
                                                                                   item.className == "UltAIPawn_Base_Male_C")))
                                    .ToList();
                                foreach (var item in listPlay)
                                {

                                    scatter.Prepare(item.pObjPointer + off.Offset_CharacterName, 8);

                                }
                                scatter.Execute();
                                //读取CharacterId
                                foreach (var item in listPlay)
                                {
                                    item.CharacterId = scatter.ReadUInt64(item.pObjPointer + off.Offset_CharacterName);
                                }
                                //准备读取CharacterName

                                scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                foreach (var item in listPlay)
                                {
                                    scatter.Prepare(item.CharacterId, 64);
                                }
                                scatter.Execute();
                                //读取CharacterName
                                foreach (var item in listPlay)
                                {
                                    item.Name = scatter.ReadStringUnicode(item.CharacterId, 64);
                                }
                                #endregion

                                #region 读取hp
                                //准备hp+读取倒地hp+读取观战人数 
                                scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                foreach (var item in listPlay)
                                {
                                    scatter.Prepare(item.pObjPointer + off.Offset_Health, 4);
                                    scatter.Prepare(item.pObjPointer + off.Offset_GroggyHealth, 4);
                                    scatter.Prepare(item.pObjPointer + off.Offset_SpectatedCount, 4);
                                    scatter.Prepare(item.pObjPointer + off.Offset_LastTeamNum, 4);
                                    scatter.Prepare(item.pObjPointer + off.Offset_AimOffsets + 0x4, 4);

                                }
                                //读取hp+读取倒地hp+读取观战人数 
                                scatter.Execute();
                                foreach (var item in listPlay)
                                {
                                    item.Hp = scatter.ReadFloat(item.pObjPointer + off.Offset_Health);
                                    item.groggyHp = scatter.ReadFloat(item.pObjPointer + off.Offset_GroggyHealth);
                                    item.SpectatedCount = scatter.ReadInt(item.pObjPointer + off.Offset_SpectatedCount);
                                    int teamNum = scatter.ReadInt(item.pObjPointer + off.Offset_LastTeamNum);
                                    if (teamNum == 100000 || teamNum > 100000)
                                    {
                                        item.teamNum = teamNum - 100000;
                                    }
                                    else
                                    {
                                        item.teamNum = teamNum;
                                    }
                                    item.Orientation = scatter.ReadFloat(item.pObjPointer + off.Offset_AimOffsets + 0x4);

                                }
                                listPlay = listPlay.Where(s => s.Hp > 0 || s.groggyHp > 0.1).ToList();

                                #endregion




                                #region 读取杀敌数量
                                //准备读取PlayerState
                                scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                foreach (var item in listPlay)
                                {
                                    scatter.Prepare(item.pObjPointer + off.Offset_PlayerState, 8);
                                }
                                //读取PlayerState
                                scatter.Execute();
                                foreach (var item in listPlay)
                                {
                                    item.PlayerState = scatter.ReadUInt64(item.pObjPointer + off.Offset_PlayerState);
                                }

                                //准备读取KillCount
                                scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                foreach (var item in listPlay)
                                {
                                    scatter.Prepare(item.PlayerState + off.Offset_PlayerStatistics, 4);

                                }
                                //读取KillCount
                                scatter.Execute();
                                foreach (var item in listPlay)
                                {
                                    item.KillCount = scatter.ReadInt(item.PlayerState + off.Offset_PlayerStatistics);
                                }
                                #endregion


                                Console.WriteLine("zuobiao");
                                #region 读取坐标
                                //准备读取MeshAddr
                                scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                foreach (var item in listPlay)
                                {
                                    scatter.Prepare(item.pObjPointer + off.Offset_Mesh, 8);
                                }
                                //读取MeshAddr
                                scatter.Execute();
                                foreach (var item in listPlay)
                                {
                                    item.MeshAddr = scatter.ReadUInt64(item.pObjPointer + off.Offset_Mesh);
                                }
                                //准备读取Offset_ComponentLocation
                                scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                foreach (var item in listPlay)
                                {
                                    scatter.Prepare(item.MeshAddr + off.Offset_ComponentLocation, 12);

                                }
                                //读取Offset_ComponentLocation
                                scatter.Prepare(world + off.Offset_WorldLocation, 4);
                                scatter.Prepare(world + off.Offset_WorldLocation + 0x04, 4);
                                scatter.Execute();
                                foreach (var item in listPlay)
                                {

                                    float X = scatter.ReadFloat(item.MeshAddr + off.Offset_ComponentLocation);
                                    float Y = scatter.ReadFloat(item.MeshAddr + off.Offset_ComponentLocation + 0x4);
                                    float Z = scatter.ReadFloat(item.MeshAddr + off.Offset_ComponentLocation + 0x8);
                                    float w = scatter.ReadInt(world + off.Offset_WorldLocation);
                                    float h = scatter.ReadInt(world + off.Offset_WorldLocation + 0x4);
                                    item.actorLocation = new Vector3D(X, Y, Z);
                                    Vector3D aimFov = (item.actorLocation - cameraLocation);
                                    var tempV = (item.actorLocation - cameraLocation);
                                    float Radpi = (float)(180 / 3.1415926535f);
                                    float Yaw = (float)Math.Atan2(tempV.Y, tempV.X) * Radpi;
                                    float Pitch = (float)Math.Atan2(item.z, Math.Sqrt((tempV.X * tempV.X) + (tempV.Y * tempV.Y))) * Radpi;
                                    float Roll = 0;
                                    aimFov = new Vector3D(Yaw, Pitch, Roll);
                                    item.aimFov = aimFov;

                                    item.x = X + w;
                                    item.y = Y + h;
                                    item.z = Z;


                                    if (item.className == "PlayerMale_A_C" || item.className == "PlayerFemale_A_C")
                                    {
                                        item.isBot = false;
                                    }
                                    else if (item.className == "AIPawn_Base_Female_C" || item.className == "AIPawn_Base_Male_C" || item.className == "UltAIPawn_Base_Female_C" || item.className == "UltAIPawn_Base_Male_C")
                                    {
                                        item.isBot = true;
                                    }
                                    if (item.x < 0)
                                    {
                                        item.x = -item.x;
                                    }
                                    if (item.y < 0)
                                    {
                                        item.y = -item.y;
                                    }
                                    if (item.z < 0)
                                    {
                                        item.z = -item.z;
                                    }
                                }

                                #endregion
                                Console.WriteLine("amimz");
                                #region 读取AmiMz
                                //准备读取AmiMz
                                scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                foreach (var item in listPlay)
                                {
                                    scatter.Prepare(item.pObjPointer + off.Offset_AimOffsets, 4);

                                }
                                //读取AmiMz
                                scatter.Execute();
                                foreach (var item in listPlay)
                                {
                                    item.AmiMz = scatter.ReadFloat(item.pObjPointer + off.Offset_AimOffsets);
                                    float AimX = (float)Math.Abs(item.aimFov.X - item.AmiMz);
                                    item.bIsAimed = (AimX > -5 && AimX < 5);
                                    float Distance = (float)(cameraLocation - item.actorLocation).Length / 100;
                                    item.Distance = Distance;
                                    ListPlayer.Add(new PlayerModel()
                                    {
                                        Name = item.Name,
                                        HP = item.Hp,
                                        TeamId = item.teamNum,
                                        isBot = item.isBot,
                                        bIsAimed = item.bIsAimed,
                                        Distance = item.Distance,
                                        x = item.x,
                                        y = item.y,
                                        z = item.z,
                                        KillCount = item.KillCount,
                                        Orientation = item.Orientation,
                                        SpectatedCount = item.SpectatedCount,
                                        ActorLocation = item.actorLocation,

                                    });
                                }

                                #endregion

                                #region 读取物资
                                goods.Clear();
                                if (isKaiWuZi == true)
                                {


                                    dtWuZi = DateTime.Now;
                                    var listgoods = ListZhiZhenModel.Where(item =>
                                       (!string.IsNullOrEmpty(item.className) && item.className == "DroppedItemGroup"))
                                   .ToList();
                                    if (listgoods != null && listgoods.Count() > 0)
                                    {
                                        //准备读取ItemGroupPtr
                                        scatter.Clear(pid, Vmm.FLAG_NOCACHE);
                                        foreach (var item in listgoods)
                                        {
                                            scatter.Prepare(item.pObjPointer + off.Offset_DroppedItemGroup, 8);
                                        }
                                        //读取ItemGroupPtr
                                        scatter.Execute();
                                        foreach (var item in listgoods)
                                        {
                                            item.ItemGroupPtr = scatter.ReadUInt64(item.pObjPointer + off.Offset_DroppedItemGroup);
                                        }
                                        //准备读取ItemCount 
                                        scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                        foreach (var item in listgoods)
                                        {
                                            if (item.ItemGroupPtr > 0)
                                            {
                                                scatter.Prepare(item.pObjPointer + off.Offset_DroppedItemGroup + 0x8, 4);
                                            }
                                        }
                                        //读取ItemCount
                                        scatter.Execute();

                                        foreach (var item in listgoods)
                                        {
                                            if (item.ItemGroupPtr > 0)
                                            {

                                                item.ItemCount = scatter.ReadInt(item.pObjPointer + off.Offset_DroppedItemGroup + 0x8);
                                            }
                                        }

                                        //准备ItemObject
                                        scatter.Clear(pid, Vmm.FLAG_NOCACHE);


                                        foreach (var item in listgoods)
                                        {
                                            if (item.ItemGroupPtr > 0 && item.ItemCount > 0 && item.ItemCount < 5000)
                                            {
                                                for (int itemIndex = 0; itemIndex < item.ItemCount; itemIndex++)
                                                {
                                                    scatter.Prepare(item.ItemGroupPtr + (ulong)(itemIndex * 0x10), 8);
                                                }
                                            }
                                        }
                                        //读取ItemObject
                                        scatter.Execute();
                                        foreach (var item in listgoods)
                                        {
                                            if (item.ItemGroupPtr > 0 && item.ItemCount > 0 && item.ItemCount < 5000)
                                            {
                                                for (int itemIndex = 0; itemIndex < item.ItemCount; itemIndex++)
                                                {
                                                    ulong ItemObject = scatter.ReadUInt64(item.ItemGroupPtr + (ulong)(itemIndex * 0x10));
                                                    goods.Add(new PubgGood()
                                                    {
                                                        ItemObject = ItemObject
                                                    });

                                                }
                                            }
                                        }
                                        //准备UItemAddress 
                                        scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                        foreach (var item in goods)
                                        {
                                            if (item.ItemObject > 0)
                                            {
                                                scatter.Prepare(item.ItemObject + off.Offset_DroppedItemGroup_UItem, 8);
                                            }
                                        }

                                        //读取UItemAddress
                                        scatter.Execute();
                                        foreach (var item in goods)
                                        {
                                            if (item.ItemObject > 0)
                                            {
                                                item.UItemAddress = scatter.ReadUInt64(item.ItemObject + off.Offset_DroppedItemGroup_UItem);
                                            }
                                        }
                                        //准备读取UItemIDAddress
                                        scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                        foreach (var item in goods)
                                        {
                                            if (item.UItemAddress > 0)
                                            {
                                                scatter.Prepare(item.UItemAddress + off.Offset_ItemInformationComponent, 8);
                                            }
                                        }
                                        //读取UItemIDAddress
                                        scatter.Execute();
                                        foreach (var item in goods)
                                        {
                                            if (item.UItemAddress > 0)
                                            {
                                                item.UItemIDAddress = scatter.ReadUInt64(item.UItemAddress + off.Offset_ItemInformationComponent);
                                            }
                                        }
                                        //准备读取UItemID
                                        scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                        foreach (var item in goods)
                                        {
                                            if (item.UItemIDAddress > 0)
                                            {
                                                scatter.Prepare(item.UItemIDAddress + off.Offset_ItemID, 4);
                                            }
                                        }
                                        //读取UItemID
                                        scatter.Execute();
                                        foreach (var item in goods)
                                        {
                                            if (item.UItemIDAddress > 0)
                                            {
                                                item.UItemID = scatter.ReadUInt(item.UItemIDAddress + off.Offset_ItemID);
                                            }
                                        }
                                        //准备读取UItem坐标
                                        scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                        foreach (var item in goods)
                                        {
                                            if (item.UItemID > 0 && item.UItemID < 0xfff0ff)
                                            {
                                                scatter.Prepare(item.ItemObject + off.Offset_ComponentLocation, 12);
                                            }
                                        }
                                        //读取UItem坐标
                                        scatter.Prepare(world + off.Offset_WorldLocation, 4);
                                        scatter.Prepare(world + off.Offset_WorldLocation + 0x04, 4);
                                        scatter.Execute();
                                        float ww = scatter.ReadInt(world + off.Offset_WorldLocation);
                                        float hh = scatter.ReadInt(world + off.Offset_WorldLocation + 0x4);
                                        foreach (var item in goods)
                                        {
                                            if (item.UItemID > 0 && item.UItemID < 0xfff0ff)
                                            {
                                                var zuobiao = scatter.Read(item.ItemObject + off.Offset_ComponentLocation, 12);
                                                Vector3D v3d = new Vector3D(BitConverter.ToSingle(zuobiao, 0), BitConverter.ToSingle(zuobiao, 4), BitConverter.ToSingle(zuobiao, 8));
                                                var tempv3 = new Vector3D(ww, hh, 0) + v3d;
                                                item.x = (int)tempv3.X;
                                                item.y = (int)tempv3.Y;
                                            }
                                        }

                                        //准备fNamePtr
                                        scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                        foreach (var item in goods)
                                        {
                                            scatter.Prepare((GNamesAddress + (ulong)(item.UItemID / off.Offset_ChunkSize) * 0x8), 8);
                                        }
                                        isExec = scatter.Execute();
                                        //读取fNamePtr 
                                        foreach (var item in goods)
                                        {
                                            ulong fNamePtr = scatter.ReadUInt64((GNamesAddress + (ulong)(item.UItemID / off.Offset_ChunkSize) * 0x8));
                                            if (fNamePtr > 0)
                                            {
                                                item.fNamePtr = fNamePtr;
                                            }
                                        }
                                        goods = goods.Where(x => x.fNamePtr > 0).ToList();
                                        //准备fName
                                        scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                        foreach (var item in goods)
                                        {
                                            scatter.Prepare(item.fNamePtr + (ulong)(item.UItemID % off.Offset_ChunkSize) * 0x8, 8);
                                        }
                                        isExec = scatter.Execute();
                                        //读取fName，
                                        foreach (var item in goods)
                                        {
                                            ulong fName = scatter.ReadUInt64(item.fNamePtr + (ulong)(item.UItemID % off.Offset_ChunkSize) * 0x8);
                                            if (fName > 0)
                                            {
                                                item.fName = fName;
                                            }
                                        }
                                        //准备读取物资名字
                                        scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                        goods = goods.Where(x => x.fName > 0).ToList();
                                        foreach (var item in goods)
                                        {
                                            scatter.Prepare(item.fName + 0x10, 64);
                                        }
                                        scatter.Execute();
                                        //读取物资名字
                                        foreach (var item in goods)
                                        {
                                            string className = scatter.ReadStringASCII(item.fName + 0x10, 64);
                                            var tempM = goodItems.Where(s => s.className == className).FirstOrDefault();
                                            if (tempM != null)
                                            {
                                                item.Name = tempM.shortName;
                                                item.isShow = tempM.showItem;
                                                item.ClassName = className;
                                                item.group = tempM.group;
                                            }
                                            //else
                                            //{
                                            //    item.ClassName = className;
                                            //    item.isShow = true;
                                            //    item.Name = className;
                                            //}

                                        }
                                    }

                                }
                                #endregion
                                #region 读取载具

                                var listtempcar = ListZhiZhenModel.Where(item =>
                                    (!string.IsNullOrEmpty(item.className) && (listCar.Any(h => h.CarClass == item.className)))).ToList();
                                Console.WriteLine("listtempcar " + listtempcar.Count());
                                if (listtempcar.Count() == 0)
                                {

                                }

                                if (listtempcar != null && listtempcar.Count() > 0)
                                {
                                    //准备读取载具RootComponent
                                    scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                    foreach (var item in listtempcar)
                                    {

                                        var tempCarModel = listCar.Where(s => s.CarClass == item.className).FirstOrDefault();
                                        if (tempCarModel != null)
                                        {
                                            listCarModel.Add(new CarModel()
                                            {
                                                CarClass = item.className,
                                                CarName = tempCarModel.CarName,
                                                pObjPointer = item.pObjPointer
                                            });
                                        }

                                        scatter.Prepare(item.pObjPointer + off.Offset_RootComponent, 12);
                                    }
                                    //读取载具RootComponent
                                    scatter.Execute();
                                    foreach (var item in listCarModel)
                                    {
                                        var RootComponentAddress = scatter.ReadUInt64(item.pObjPointer + off.Offset_RootComponent);
                                        if (RootComponentAddress > 0)
                                        {
                                            item.RootComponent = decryptFunc(RootComponentAddress);
                                        }
                                    }
                                    //准备读取坐标
                                    scatter.Clear(pid, Vmm.FLAG_NOCACHE);

                                    foreach (var item in listCarModel)
                                    {
                                        scatter.Prepare(item.RootComponent + off.Offset_ComponentLocation, 12);
                                    }
                                    //读取坐标
                                    scatter.Prepare(world + off.Offset_WorldLocation, 4);
                                    scatter.Prepare(world + off.Offset_WorldLocation + 0x04, 4);
                                    scatter.Execute();
                                    foreach (var item in listCarModel)
                                    {
                                        var zuobiao = scatter.Read(item.RootComponent + off.Offset_ComponentLocation, 12);
                                        Vector3D v3d = new Vector3D(BitConverter.ToSingle(zuobiao, 0), BitConverter.ToSingle(zuobiao, 4), BitConverter.ToSingle(zuobiao, 8));
                                        float w = scatter.ReadInt(world + off.Offset_WorldLocation);
                                        float h = scatter.ReadInt(world + off.Offset_WorldLocation + 0x4);
                                        var tempv3 = new Vector3D(w, h, 0) + v3d;
                                        item.x = (int)tempv3.X;
                                        item.y = (int)tempv3.Y;
                                    }
                                }


                                #endregion

                                var tempMyModel = ListPlayer.Where(s => s.Name == MyName).FirstOrDefault();

                                if (tempMyModel != null)
                                {
                                    myModel = tempMyModel;
                                    foreach (var item in ListPlayer)
                                    {

                                        if (item.TeamId == myModel.TeamId)
                                        {
                                            item.IsMyTeam = true;
                                        }
                                    }
                                }
                                model.Cars = listCarModel;
                                model.Player = ListPlayer;
                                model.MyTeam = ListPlayer.Where(s => s.IsMyTeam == true).ToList();
                                model.Game.Add(new List<object>() { lerpSafetyPosition.X, lerpSafetyPosition.Y, lerpSafetyGasRadius });

                                model.Game.Add(new List<object>() { poisonGasPosition.X, poisonGasPosition.Y, poisonGasRadius });
                                model.Game.Add(new List<object>() { redPosition.X, redPosition.Y, redRadius });
                                if (tempMyModel != null)
                                {
                                    model.MyName = tempMyModel.Name;
                                }
                                model.MyName = MyName;
                                if (ListPlayer.Count == 0)
                                {
                                    continue;
                                }
                                model.PubgGoods = goods.Where(s => s.isShow).ToList();
                                if (OnPlayerListUpdate != null)
                                {
                                    OnPlayerListUpdate(model);
                                }
                            }
                            sw.Stop();
                            if (OnExecTime != null)
                            {
                                OnExecTime(sw.ElapsedMilliseconds, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            if (OnExecTime != null)
                            {
                                OnExecTime(0, null);
                            }

                            Console.WriteLine("11:" + ex.Message + "\r\n" + ex.StackTrace);
                        }
                        // GC.Collect();
                    }
                }
                catch (Exception eee)
                {
                    if (OnExecTime != null)
                    {
                        OnExecTime(0, eee.Message);
                    }

                }
            });
            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(2);
            //timer.Tick += (ss, ee) =>
            //{
            //    if ((DateTime.Now - dt).TotalSeconds > 2)
            //    {
            //        try
            //        {
            //            if (t != null)
            //            {
            //                t.Abort();
            //            }
            //        }
            //        catch (Exception)
            //        {


            //        }

            //    }
            //};

            //timer.Start();


        }

        string GetObjName(uint objId)
        {
            //获取类名地址
            ulong fNamePtr = vmm.MemReadInt64(pid, (GNamesAddress + (ulong)(objId / off.Offset_ChunkSize) * 0x8));
            if (fNamePtr > 0)
            {
                //获取类名地址
                ulong fName = vmm.MemReadInt64(pid, fNamePtr + (ulong)(objId % off.Offset_ChunkSize) * 0x8);
                if (fName > 0)
                {
                    var nameByte = vmm.MemRead(pid, fName + 0x10, 64);

                    //获取类名
                    string name = Encoding.ASCII.GetString(nameByte.ToArray());

                    return name.Substring(0, name.IndexOf('\0') >= 0 ? name.IndexOf('\0') : name.Length);
                }
            }
            return null;
        }
    }
}
