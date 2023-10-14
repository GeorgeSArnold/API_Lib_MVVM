using API_Lib;
using Caliburn.Micro;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace TicketUI.ViewModels
{
    public class ConnectionViewModel : Screen
    {
        //#region Props
        //// hardcoded props
        //private string serverIp = "http://192.168.150.151";
        //private string zammadToken = "NeCpzB3EXJCZNLck-CKNbWK8sZ-BhK59mPrhpsVilAN8M22xbeAr9_xiqKLcY-ZB";

        // server ip
        public string ServerIp
        {
            get { return serverIp; }
            set
            {
                serverIp = value;
                NotifyOfPropertyChange(() => ServerIp);
            }
        }
        private string serverIp;
         
        // zammad
        public string ZammadToken
        {
            get { return zammadToken; }
            set
            {
                zammadToken = value;
                NotifyOfPropertyChange(() => ZammadToken);
            }
        }
        private string zammadToken;

        // gpt
        public string GptToken
        {
            get { return gptToken; }
            set
            {
                gptToken = value;
                NotifyOfPropertyChange(() => GptToken);
            }
        }
        private string gptToken;

        // loaded ip
        public string LoadedServerIp
        {
            get { return loadedServerIp; }
            set
            {
                loadedServerIp = value;
                NotifyOfPropertyChange(() => LoadedServerIp);
            }
        }
        private string loadedServerIp;

        // loaded zammad
        public string LoadedZammadToken
        {
            get { return loadedZammadToken; }
            set
            {
                loadedZammadToken = value;
                NotifyOfPropertyChange(() => LoadedZammadToken);
            }
        }
        private string loadedZammadToken;

        // loaded gpt
        public string LoadedGptToken
        {
            get { return loadedGptToken; }
            set
            {
                loadedGptToken = value;
                NotifyOfPropertyChange(() => LoadedGptToken);
            }
        }
        private string loadedGptToken;

        // const
        public ConnectionViewModel()
        {
            LoadConnectionDetails();
        }
   
        // get methods
        public string GetServerIp()
        {
            return LoadedServerIp;
        }
        public string GetZammadToken()
        {
            return LoadedZammadToken;
        }
        public string GetGptToken()
        {
            return loadedGptToken;
        }

        // save & load
        public void SaveConnectionDetails()
        {
            try
            {
                var connectionDetails = new
                {
                    ServerIp,
                    ZammadToken,
                    GptToken
                };

                string json = JsonConvert.SerializeObject(connectionDetails);
                File.WriteAllText("connection.json", json);
                MessageBox.Show("Connection details saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving connection details: " + ex.Message);
            }
        }
        public void LoadConnectionDetails()
        {
            try
            {
                if (File.Exists("connection.json"))
                {
                    string json = File.ReadAllText("connection.json");
                    var connectionDetails = JsonConvert.DeserializeObject<dynamic>(json);

                    LoadedServerIp = connectionDetails.ServerIp;
                    LoadedZammadToken = connectionDetails.ZammadToken;
                    LoadedGptToken = connectionDetails.GptToken;

                    // check
                    Console.WriteLine($@"# Server Ip loaded: {LoadedServerIp}
# Zammad Token > OK
# Gpt Token > OK");

                    //MessageBox.Show("Connection details loaded successfully!");
                }
                else
                {
                    MessageBox.Show("No saved connection details found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading connection details: " + ex.Message);
            }
        }
    }
}

