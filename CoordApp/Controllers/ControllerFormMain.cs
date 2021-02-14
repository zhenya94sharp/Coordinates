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
            string json = await GetPoints(form.textBoxAdress.Text);

            listData = JsonConvert.DeserializeObject<List<JsonData>>(json);


            int a = 1;
        }

        public Task<string> GetPoints(string adress)
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
