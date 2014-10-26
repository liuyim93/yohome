using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Msg
    {
        public int MsgId { get; set; }
        public string Author { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Details { get; set; }
        public string CreateTime { get; set; }
        public int IsRead { get; set; }
    }
}
