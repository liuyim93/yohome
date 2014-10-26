using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Remark { get; set; }
        public string CreateTime { get; set; }
        public int IsSuper { get; set; }
    }
}
