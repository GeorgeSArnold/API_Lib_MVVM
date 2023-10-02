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

        private string serverIp;
        private string zammadToken;

        public string ServerIp
        {
            get { return serverIp; }
            set
            {
                serverIp = value;
                NotifyOfPropertyChange(() => ServerIp);
            }
        }

        public string ZammadToken
        {
            get { return zammadToken; }
            set
            {
                zammadToken = value;
                NotifyOfPropertyChange(() => ZammadToken);
            }
        }

        // loaded props
        private string loadedServerIp;
        public string LoadedServerIp
        {
            get { return loadedServerIp; }
            set
            {
                loadedServerIp = value;
                NotifyOfPropertyChange(() => LoadedServerIp);
            }
        }

        private string loadedZammadToken;
        public string LoadedZammadToken
        {
            get { return loadedZammadToken; }
            set
            {
                loadedZammadToken = value;
                NotifyOfPropertyChange(() => LoadedZammadToken);
            }
        }

        public ConnectionViewModel()
        {
            LoadConnectionDetails();
        }

        public string GetServerIp()
        {
            return LoadedServerIp;
        }

        public string GetZammadToken()
        {
            return LoadedZammadToken;
        }


        public void SaveConnectionDetails()
        {
            try
            {
                var connectionDetails = new
                {
                    ServerIp,
                    ZammadToken
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

                    MessageBox.Show("Connection details loaded successfully!");
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

