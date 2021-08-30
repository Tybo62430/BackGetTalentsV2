using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Picture
{
    public class PictureService : IPictureService
    {
        private IPictureRepository _pictureRepository;

        public PictureService(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }

        public void AddPicture(Picture picture)
        {
            _pictureRepository.Create(picture);
        }

        public void DeletePicture(int id)
        {
            Picture picture = _pictureRepository.GetPictureById(id);

            if (picture == null)
            {
                throw new PictureNotFoundException();
            }

            _pictureRepository.Delete(picture);
        }

        public Picture GetPictureById(int id)
        {
            Picture picture = _pictureRepository.GetPictureById(id);

            if (picture == null)
            {
                throw new PictureNotFoundException();
            }

            return picture;
        }

        public IList<Picture> GetAllPictures()
        {
            return _pictureRepository.GetAllPictures();
        }

        public void UpdatePicture(int id, Picture picture)
        {
            Picture tempPicture = _pictureRepository.GetPictureById(id);

            if (tempPicture == null)
            {
                throw new PictureNotFoundException();
            }

            _pictureRepository.Update(picture);
        }
    }
}