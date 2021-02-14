using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoordApp.Controllers
{
    class ControllerFormMain
    {

        public async void Blabla(FormMain form)
        {
            string json = await GetPoints(form.textBoxAdress.Text);
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
    }
}
