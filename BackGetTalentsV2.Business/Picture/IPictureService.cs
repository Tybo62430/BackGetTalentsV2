using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Picture
{
    public interface IPictureService
    {
        void AddPicture(Picture picture);
        IList<Picture> GetAllPictures();
        Picture GetPictureById(int id);
        void UpdatePicture(int id, Picture picture);
        void DeletePicture(int id);
    }
}