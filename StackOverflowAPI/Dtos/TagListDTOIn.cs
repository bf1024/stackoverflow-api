using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflowAPI.Dtos
{
    class TagListDTOIn
    {
        public List<TagDTOIn> items { get; set; }
        public bool has_more { get; set; }
        public int quota_max { get; set; }
        public int quota_remaining { get; set; }
    }
}
