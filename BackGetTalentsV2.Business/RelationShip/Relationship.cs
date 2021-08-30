using System;
using System.Collections.Generic;

#nullable disable

namespace BackGetTalentsV2.Business.Relationship
{
    public partial class Relationship
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserLiked { get; set; }
        public string Status { get; set; }

        public virtual User.User User { get; set; }
        public virtual User.User UserLikedNavigation { get; set; }
    }
}
