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

        public List<Tag> Get()
        {
            List<Tag> list = new List<Tag>();

                for (int i = 1; i < 11; i++)
                {
                    HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("https://api.stackexchange.com/2.2/tags?key=U4DMV*8nvpm3EOpvf69Rxw((&site=stackoverflow&page="+i+"&pagesize=100&order=desc&sort=popular&filter=default");
                    httpRequest.Method = "GET";
                    httpRequest.Accept = "*/*";
                    httpRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                    using (HttpWebResponse webResponse = (HttpWebResponse)httpRequest.GetResponse())
                    {
                        using (Stream dataStream = webResponse.GetResponseStream())
                        {
                            // Open the stream using a StreamReader for easy access.
                            StreamReader reader = new StreamReader(dataStream);
                            // Read the content.
                            string responseFromServer = reader.ReadToEnd();
                            TagListDTOIn tagListDTO = JsonConvert.DeserializeObject<TagListDTOIn>(responseFromServer);
                        List<Tag> list2 = tagListDTO.items.Select((item) => new Tag { Name = item.name, Count = item.count, Percent = 0 }).ToList();

                        list = list.Concat(list2).ToList();
                        }
                        
                    }
                }

                int countAll = list.Sum(a => a.Count);
                foreach(Tag tag in list)
                {
                    tag.Percent = Decimal.Round(((tag.Count/Convert.ToDecimal(countAll))* 100),4);
                };
                
           
            return list; 
        }

    }
}
