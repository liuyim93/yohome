using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Img
    {
        public int ImgId { get; set; }
        public string ImgUrl { get; set; }
        public int ImgTypeId { get; set; }
        public string Title { get; set; }
        public string LinkUrl { get; set; }
        public string Remark { get; set; }
        public int Rank { get; set; }
        public string CreateTime { get; set; }
        public int IsShow { get; set; }
    }
}
