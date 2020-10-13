using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using StackOverflowAPI.Dtos;
using System.Linq;
using Newtonsoft.Json;

namespace StackOverflowAPI.Services
{
    public class TagsService : ITagsService
    {

        public List<Tag> Get(string apiKey)
        {
            var list = new List<Tag>();

                for (var i = 1; i < 11; i++)
                {
                    var httpRequest = (HttpWebRequest)WebRequest.Create(
                        $"https://api.stackexchange.com/2.2/tags?key={apiKey}&site=stackoverflow&page={i}&pagesize=100&order=desc&sort=popular&filter=default");
                    httpRequest.Method = "GET";
                    httpRequest.Accept = "*/*";
                    httpRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                    using (var webResponse = (HttpWebResponse)httpRequest.GetResponse())
                    {
                        using (var dataStream = webResponse.GetResponseStream())
                        {
                            // Open the stream using a StreamReader for easy access.
                            var reader = new StreamReader(dataStream);
                            // Read the content.
                            var responseFromServer = reader.ReadToEnd();
                            var tagListDTO = JsonConvert.DeserializeObject<TagListDTOIn>(responseFromServer);
                            var list2 = tagListDTO.items.Select((item) => new Tag { Name = item.name, Count = item.count, Percent = 0 }).ToList();

                            list = list.Concat(list2).ToList();
                            if (!tagListDTO.has_more)
                            break;
                        }
                        
                    }
                }

                var countAll = list.Sum(a => a.Count);
                foreach(var tag in list)
                {
                    tag.Percent = Decimal.Round(((tag.Count/Convert.ToDecimal(countAll))* 100),4);
                };
                
           
            return list; 
        }

    }
}
