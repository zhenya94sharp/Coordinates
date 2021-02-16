using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoordApp.Controllers
{
    class ControllerFormMain
    {
        private static List<List<double>> coordinates = new List<List<double>>();
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

            int lastIndex = jsonData["geojson"]["coordinates"].Count() - 1;

            if (jsonData["geojson"]["type"].ToString() == "Polygon")
            {
                coordinates = JsonConvert.DeserializeObject<List<List<double>>>(jsonData["geojson"]["coordinates"][lastIndex].ToString());
            }
            else
            {
                coordinates = JsonConvert.DeserializeObject<List<List<double>>>(jsonData["geojson"]["coordinates"][lastIndex][0].ToString());
            }

            MessageBox.Show("Получены точки полигона");
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

            List<string> points = new List<string>();

            foreach (var point in coordinates)
            {
                points.Add(point[0].ToString());
                points.Add(point[1].ToString());
            }

            System.IO.File.WriteAllLines(filename, points);

            MessageBox.Show("Файл сохранен");
        }
    }
}
