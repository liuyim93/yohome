using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Product
    {
        public int ProId { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
        public string Details { get; set; }
        public string CreateTime { get; set; }
        public string ImgUrl { get; set; }
        public int ProTypeId { get; set; }
        public int IndexShow { get; set; }
        public int IsShow { get; set; }
        public string BigImgUrl { get; set; }
    }
}
