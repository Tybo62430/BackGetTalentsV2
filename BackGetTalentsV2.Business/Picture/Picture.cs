using System;
using System.Collections.Generic;

#nullable disable

namespace BackGetTalentsV2.Business.Picture
{
    public partial class Picture
    {
        public Picture()
        {
            Categories = new HashSet<Category.Category>();
            Users = new HashSet<User.User>();
        }

        public int Id { get; set; }
        public string Path { get; set; }
        public int? ReviewId { get; set; }
        public int? MessageId { get; set; }

        public virtual Message.Message Message { get; set; }
        public virtual Review.Review Review { get; set; }
        public virtual ICollection<Category.Category> Categories { get; set; }
        public virtual ICollection<User.User> Users { get; set; }
    }
}
