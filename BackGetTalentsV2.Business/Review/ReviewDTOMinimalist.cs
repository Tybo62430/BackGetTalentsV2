using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Review
{
    public class ReviewDTOMinimalist
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int? Note { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int RecipientId { get; set; }
        public int SenderId { get; set; }
        public virtual ICollection<Picture.PictureDTO> Pictures { get; set; }
    }
}
