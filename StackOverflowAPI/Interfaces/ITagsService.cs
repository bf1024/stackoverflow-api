using StackOverflowAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowAPI.Interfaces
{
    public interface ITagsService
    {
        public List<Tag> Get(string apiKey);
    }
}
