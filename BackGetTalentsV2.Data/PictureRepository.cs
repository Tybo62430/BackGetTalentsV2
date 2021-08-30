using BackGetTalentsV2.Business.Picture;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Data
{
    public class PictureRepository : IPictureRepository
    {
        private gettalentsContext _dbContext;

        public PictureRepository(gettalentsContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Create(Picture picture)
        {
            if (picture == null)
            {
                throw new ArgumentNullException(nameof(picture));
            }

            _dbContext.Pictures.Add(picture);
            _dbContext.SaveChanges();
        }

        public Picture GetPictureById(int id)
        {
            Picture picture = _dbContext.Pictures.Where(c => c.Id.Equals(id)).FirstOrDefault();

            if (picture == null)
            {
                throw new PictureNotFoundException();
            }

            return picture;
        }

        public IList<Picture> GetAllPictures()
        {
            return _dbContext.Pictures.ToList();
        }

        public void Update(Picture picture)
        {
            Picture pictureTemp = _dbContext.Pictures.Where(c => c.Id.Equals(picture.Id)).FirstOrDefault();

            if (pictureTemp == null)
            {
                throw new ArgumentNullException(nameof(picture));
            }

            if (pictureTemp != null)
            {
                pictureTemp.Path = picture.Path;
                _dbContext.SaveChanges();
            }
        }

        public void Delete(Picture picture)
        {
            if (picture == null)
            {
                throw new ArgumentNullException(nameof(picture));
            }

            if (GetPictureById(picture.Id) != null)
            {
                _dbContext.Pictures.Remove(picture);
                _dbContext.SaveChanges();
            }
        }
    }
}