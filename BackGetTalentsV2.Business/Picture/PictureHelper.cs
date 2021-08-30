using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Picture
{
    public class PictureHelper
    {
        public static List<PictureDTO> ConvertPictures(List<Picture> pictures)
        {
            return pictures.ConvertAll(picture => ConvertPicture(picture));
        }

        public static PictureDTO ConvertPicture(Picture picture)
        {
            PictureDTO pictureDTO = new()
            {
                Id = picture.Id,
                Path = picture.Path
            };

            return pictureDTO;
        }

        public static List<Picture> ConvertPicturesDTO(List<PictureDTO> picturesDTO)
        {
            return picturesDTO.ConvertAll(pictureDTO => ConvertPictureDTO(pictureDTO));
        }

        public static Picture ConvertPictureDTO(PictureDTO pictureDTO)
        {
            Picture picture = new()
            {
                Id = pictureDTO.Id,
                Path = pictureDTO.Path
            };

            return picture;
        }
    }
}