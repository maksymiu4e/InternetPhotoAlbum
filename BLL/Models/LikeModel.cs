using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class LikeModel
    {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public PhotoModel Photo { get; set; }
    }
}
