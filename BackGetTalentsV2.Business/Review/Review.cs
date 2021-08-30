using System;
using System.Collections.Generic;

#nullable disable

namespace BackGetTalentsV2.Business.Review
{
    public partial class Review
    {
        public Review()
        {
            Pictures = new HashSet<Picture.Picture>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int? Note { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int CommentatorId { get; set; }
        public int UserId { get; set; }

        public virtual User.User Commentator { get; set; }
        public virtual User.User User { get; set; }
        public virtual ICollection<Picture.Picture> Pictures { get; set; }
    }
}
