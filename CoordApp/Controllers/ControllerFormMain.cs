using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CoordApp.Controllers
{
    class ControllerFormMain
    {
        private List<List<double>> coordinates;
        private int frequency;
        public async void ConvertJsonToObject(FormMain form)
        {
            if (form.textBoxAdress.Text == "")
            {
                MessageBox.Show("Введите адрес!");
                return;
            }

            string json;

            try
            {
                json = await GetJson(form.textBoxAdress.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }


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

        private async Task<string> GetJson(string adress)
        {
            try
            {
                string url = $"https://nominatim.openstreetmap.org/search?q={adress}&format=json&polygon_geojson=1";

                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                string json = await client.GetStringAsync(url);

                return json;
            }
            catch (Exception e)
            {
                throw new Exception("Ошибка! Проверьте соединение\n" + e.Message);
            }

        }

        public void SaveFile(FormMain form)
        {
            if (coordinates == null)
            {
                MessageBox.Show("Вначале загрузите точки!");
                return;
            }

            try
            {
                if (form.textBoxFrequency.Text != "")
                {
                    frequency = int.Parse(form.textBoxFrequency.Text);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Введите корректное значение\n" + e.Message);
                return;
            }

            if (form.saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = form.saveFileDialog.FileName;

            List<string> allPoints = new List<string>();

            List<string> sortList = new List<string>();

            foreach (var point in coordinates)
            {
                allPoints.Add(point[0].ToString());
                allPoints.Add(point[1].ToString());
            }

            if (frequency > 1)
            {
                int length = allPoints.Count;

                if (allPoints.Count % frequency != 0)
                {
                    length = allPoints.Count - (allPoints.Count % frequency);
                }
                for (int i = 0; i < length; i += frequency)
                {
                    sortList.Add(allPoints[i]);
                    sortList.Add(allPoints[i + 1]);
                }
                System.IO.File.WriteAllLines(filename, sortList);
                MessageBox.Show("Файл сохранен");
                return;
            }
            System.IO.File.WriteAllLines(filename, allPoints);

            MessageBox.Show("Файл сохранен");
        }
    }
}
