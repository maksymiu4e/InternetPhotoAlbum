using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Photo
    {
        //public Photo()
        //{
        //    Likes = new List<Like>();
        //}
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public byte[] Content { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual User User { get; set; }
    }
}
