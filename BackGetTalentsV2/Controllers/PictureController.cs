using BackGetTalentsV2.Business.Picture;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Controllers
{
    [Route("pictures")]
    [ApiController]
    public class PictureController : Controller
    {
        private IPictureService _pictureService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PictureController(IPictureService pictureService, IWebHostEnvironment hostingEnvironment)
        {
            _pictureService = pictureService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePicture()
        {
            string folderPath = _hostingEnvironment.ContentRootPath + "/images/";

            IFormCollection formCollection = await Request.ReadFormAsync();
            IFormFile file = formCollection.Files.First();

            Image image = Image.Load(file.OpenReadStream());

            PictureDTO pictureDTO = new PictureDTO();
            pictureDTO.MimeType = file.ContentType;
            pictureDTO.FileName = Guid.NewGuid().ToString();
            pictureDTO.Path = folderPath + pictureDTO.FileName;

            if (pictureDTO.MimeType == "image/jpeg")
                pictureDTO.FileName += ".jpg";

            image.Save( folderPath + pictureDTO.FileName);

            Picture picture = PictureHelper.ConvertPictureDTO(pictureDTO);

            _pictureService.AddPicture(picture);

            return Created(nameof(CreatePicture), picture);
            
        }

        [HttpGet]
        public IActionResult GetPictures()
        {
            IList<Picture> pictures = _pictureService.GetAllPictures();

            List<PictureDTO> picturesDTO = PictureHelper.ConvertPictures(pictures.ToList());

            return Ok(picturesDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPictureById([FromRoute] int id)
        {
            try
            {
                Picture picture = _pictureService.GetPictureById(id);

                PictureDTO pictureDTO = PictureHelper.ConvertPicture(picture);

                return Ok(pictureDTO);
            }
            catch (PictureNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletePicture([FromRoute] int id)
        {
            try
            {
                _pictureService.DeletePicture(id);

                return NoContent();
            }
            catch (PictureNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdatePicture([FromRoute] int id, [FromBody] PictureDTO pictureDTO)
        {
            try
            {
                Picture picture = PictureHelper.ConvertPictureDTO(pictureDTO);

                _pictureService.UpdatePicture(id, picture);

                return NoContent();
            }
            catch (PictureNotFoundException)
            {
                return NotFound();
            }
        }
    }
}