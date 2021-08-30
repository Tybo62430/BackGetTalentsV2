using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Picture
{
    public interface IPictureRepository
    {
        void Create(Picture picture);
        IList<Picture> GetAllPictures();
        Picture GetPictureById(int id);
        void Update(Picture picture);
        void Delete(Picture picture);
    }
}