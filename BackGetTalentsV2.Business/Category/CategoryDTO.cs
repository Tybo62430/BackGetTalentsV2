using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackGetTalentsV2.Business.Skill;

namespace BackGetTalentsV2.Business.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Picture.PictureDTO CategoryPicture { get; set; }
        public virtual ICollection<SkillDTOForCategory> Skills { get; set; }
    }
}
