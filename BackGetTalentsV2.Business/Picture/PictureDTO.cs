﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Picture
{
    public class PictureDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string Path { get; set; }
    }
}