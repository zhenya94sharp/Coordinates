using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoordApp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoordApp.Controllers
{
    class ControllerFormMain
    {
        private static List<JsonData> listData = new List<JsonData>();
        public async void ConvertJsonToObject(FormMain form)
        {
            if (form.textBoxAdress.Text=="")
            {
                MessageBox.Show("Введите адрес!");
                return;
            }
            string json = await GetJson(form.textBoxAdress.Text);

            JArray array = JArray.Parse(json);

            JObject jsonData = JObject.FromObject(array[0]);


            List<List<double>> coordinates = JsonConvert.DeserializeObject<List<List<double>>>(jsonData["geojson"]["coordinates"][0][0].ToString());


        }

        public Task<string> GetJson(string adress)
        {
            string url = $"https://nominatim.openstreetmap.org/search?q={adress}&format=json&polygon_geojson=1";
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            return Task<string>.Factory.StartNew(() => webClient.DownloadString(url));
        }

        public void SaveFile(FormMain form)
        {
            if (form.saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = form.saveFileDialog.FileName;

            foreach (var data in listData[0].geojson.coordinates)
            {
                System.IO.File.WriteAllText(filename, data.ToString());
            }
            
            MessageBox.Show("Файл сохранен");
        }
    }
}
