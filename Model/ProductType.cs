using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ProductType
    {
        public int ProTypeId { get; set; }
        public string TypeName { get; set; }
        public int FatherId { get; set; }
        public int Rank { get; set; }
        public string Remark { get; set; }
    }
}
