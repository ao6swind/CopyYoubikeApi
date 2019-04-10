using Models;
using Newtonsoft.Json;
using Services.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Services
{
    public class YouBikeSiteService : DbOperator<YouBikeSite>
    {
        public void Backup()
        {
            int created = 0;
            int updated = 0;
            string url = @"https://data.ntpc.gov.tw/od/data/api/54DDDC93-589C-4858-9C95-18B2046CC1FC?$format=json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string result = String.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
            List<YouBikeSite> youBikeSites = JsonConvert.DeserializeObject<List<YouBikeSite>>(result);

            foreach (YouBikeSite youBikeSite in youBikeSites)
            {
                if (Find(youBikeSite.SiteNumber) == null)
                {
                    Create(youBikeSite);
                    created++;
                }
                else
                {
                    Update(youBikeSite.SiteNumber, youBikeSite);
                    updated++;
                }
            }

            Console.WriteLine($"Created: {created}");
            Console.WriteLine($"Updated: {updated}");
        }
    }
}
