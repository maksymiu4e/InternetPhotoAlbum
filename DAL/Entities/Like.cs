using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
