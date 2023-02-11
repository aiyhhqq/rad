using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using vmmsharp;
using MQTTnet.Client;
using MQTTnet;
using DMAHelper.Code.Models;
using System.Diagnostics;
using System.Net.Configuration;
using System.Windows.Media.Media3D;
using System.Security.Cryptography;
using System.Globalization;
using DMAHelper.Code;
using Newtonsoft.Json.Linq;
using System.IO;

namespace DMAHelper
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
       
        pubg p = null;
        IMqttClient mqtt = new MqttFactory().CreateMqttClient();
        public MainWindow()
        {
            InitializeComponent();
            
            
        }
        private void P_OnPlayerListUpdate(PubgModel obj)
        {
            if (mqtt.IsConnected)
            {
                PubgMqttModel model = new PubgMqttModel();
                model.Map = obj.MapName;
                model.MyTeam = obj.MyTeam;
                model.MyName = obj.MyName;
                model.Game = obj.Game;
                List<dynamic> l = new List<dynamic>();
                foreach (var item in obj.Player)
                {
                    List<object> listobj = new List<object>();
                    listobj.Add(item.x);
                    listobj.Add(item.y);
                    listobj.Add(item.Distance);
                    listobj.Add(item.TeamId);
                    listobj.Add(item.HP);
                    listobj.Add(item.KillCount);
                    listobj.Add(item.SpectatedCount);
                    listobj.Add(item.Orientation);
                    //是不是队友，1=是队友，0不是队友
                    listobj.Add(item.IsMyTeam ? 1 : 0);
                    listobj.Add(item.isBot ? 1 : 0);
                    listobj.Add(0);
                    listobj.Add(0);
                    listobj.Add(item.bIsAimed);
                    listobj.Add(0);
                    listobj.Add(item.Name);
                    listobj.Add(1);
                    model.Player.Add(listobj);
                }

                if (obj.Cars != null && obj.Cars.Count > 0)
                {
                    foreach (var item in obj.Cars)
                    {
                        List<object> listobj = new List<object>();
                        listobj.Add(item.CarName);
                        listobj.Add(item.x);
                        listobj.Add(item.y);
                        listobj.Add(item.CarClass);
                        model.Car.Add(listobj);
                    }
                }
                if (obj.PubgGoods != null && obj.PubgGoods.Count > 0)
                {
                    foreach (var item in obj.PubgGoods)
                    {
                        List<object> listobj = new List<object>();
                        listobj.Add(item.Name);
                        listobj.Add(item.x);
                        listobj.Add(item.y);
                        if (item.group == 0)
                        {
                            listobj.Add("#FFFFFF");
                        }
                        else if (item.group == 1)
                        {
                            listobj.Add("#157DEC");
                        }
                        else if (item.group == 2)
                        {
                            listobj.Add("#FFFF00");
                        }
                        else if (item.group == 3)
                        {
                            listobj.Add("#FF00FF");
                        }
                        else if (item.group == 4)
                        {
                            listobj.Add("#00FF00");
                        }
                        else if (item.group == 5)
                        {
                            listobj.Add("#00FFFF");
                        }
                        listobj.Add(item.ClassName);
                        listobj.Add(item.group);
                        model.Goods.Add(listobj);
                    }

                }

                try
                {
                    mqtt.PublishAsync(new MqttApplicationMessageBuilder().WithTopic(zhuti).WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce).WithPayload(JsonConvert.SerializeObject(model)).Build()).ContinueWith(rs =>
                    {
                        try
                        {
                            if (rs.Result.ReasonCode == MqttClientPublishReasonCode.Success)
                            {
                            }
                        }
                        catch (Exception ee)
                        {

                        }

                    });

                }
                catch (Exception ex)
                {

                }
            }
            //this.Dispatcher.Invoke(() =>
            //{

            //    this.txt.Text = JsonConvert.SerializeObject(obj);
            //});
        }
        string zhuti = null;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (txtuid.Text == "")
            {
                txtLog.AppendText("账号不能为空\r\n");
                return;
            }
            zhuti = txtuid.Text;

           

            try
            {
                p = new pubg();
                p.OnExecTime += (s,m) =>
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        this.Title = s.ToString();
                    });
                    if (!string.IsNullOrEmpty(m))
                    {
                        this.Dispatcher.Invoke(() =>
                        {
                            txtLog.AppendText(m+"\r\n");
                        });
                        
                    }
                   
                };
                p.OnPlayerListUpdate += P_OnPlayerListUpdate;
                bool islocal = false;
                if (rbShuang.IsChecked==true)
                {
                    islocal = false;
                }
                else
                {
                    islocal = true;
                }
                if (p.Init(islocal, out string msg))
                {
                    MqttClientOptions op = null;
                    if (txtuid.Text.IndexOf("470138890") != -1 || txtuid.Text.IndexOf("binbin") != -1)
                    {
                        op = new MqttClientOptionsBuilder().WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce).WithTcpServer("113.107.160.90").Build();

                    }
                    else if (File.Exists("mqtt.txt"))
                    {
                        op = new MqttClientOptionsBuilder().WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce).WithTcpServer(File.ReadAllText("mqtt.txt")).Build();
                    }
                    else
                    {
                        if (txtuid.Text.IndexOf("470138890") != -1 || txtuid.Text.IndexOf("binbin") != -1)
                        {
                            op = new MqttClientOptionsBuilder().WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce).WithTcpServer("113.107.160.90").Build();

                        }
                        else
                        {
                            op = new MqttClientOptionsBuilder().WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce).WithTcpServer("219.129.239.39").Build();

                        }

                    }
                    mqtt.DisconnectedAsync += Mqtt_DisconnectedAsync;
                    mqtt.ConnectAsync(op).ContinueWith(rs =>
                    {
                        if (rs.Result.ResultCode == MqttClientConnectResultCode.Success)
                        {
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                txtLog.AppendText("网络连接成功\r\n");
                            }));

                        }
                    });
                    btnOk.IsEnabled = false;
                    p.Start();
                    if (txtuid.Text.IndexOf("470138890") != -1 || txtuid.Text.IndexOf("binbin") != -1)
                    {
                    }
                    else
                    {
                        Process.Start("http://pubg.xzbapi.com/?" + txtuid.Text.Trim() + "&addr=219.129.239.39");
                    }
                }
                else
                {
                    txtLog.AppendText("初始化DMA失败\r\n"+msg);
                    return;
                }
            }
            catch (Exception ex)
            {
                txtLog.AppendText("初始化DMA异常" + ex.Message + "\r\n");
                return;
            }
        }

        private Task Mqtt_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            var op = new MqttClientOptionsBuilder().WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtLeastOnce).WithTcpServer("113.107.160.90").Build();
            return mqtt.ConnectAsync(op).ContinueWith(rs =>
              {
                  if (rs.Result.ResultCode == MqttClientConnectResultCode.Success)
                  {
                      Dispatcher.BeginInvoke(new Action(() =>
                      {
                          txtLog.AppendText("网络重新连接成功\r\n");
                      }));

                  }
              });

        }

        private void cbWuZi_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void cbWuZi_Click(object sender, RoutedEventArgs e)
        {
            if (p != null)
            {
                p.isKaiWuZi = cbWuZi.IsChecked == true ? true : false;
            }
        }
    }
}
