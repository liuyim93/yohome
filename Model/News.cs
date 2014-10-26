using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class News
    {
        public int NewsId { get; set; }
        public int NewsTypeId { get; set; }
        public string ImgUrl { get; set; }
        public string CreateTime { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
        public string Details { get; set; }
        public int IsShow { get; set; }
        public int IndexShow { get; set; }
        public int IsTop { get; set; }
    }
}
