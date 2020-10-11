using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflowAPI.Dtos
{
    class TagDTOIn
    {
        public bool has_synonyms { get; set; }
        public bool is_moderator_only { get; set; }
        public bool is_required { get; set; }
        public int count { get; set; }
        public string name { get; set; }
    }
}
