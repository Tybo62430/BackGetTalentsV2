using System;
using System.Collections.Generic;

#nullable disable

namespace BackGetTalentsV2.Business.Category
{
    public partial class Category
    {
        public Category()
        {
            Skills = new HashSet<Skill.Skill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? PictureId { get; set; }

        public virtual Picture.Picture Picture { get; set; }
        public virtual ICollection<Skill.Skill> Skills { get; set; }
    }
}
