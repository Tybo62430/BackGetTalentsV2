using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackGetTalentsV2.Business.Skill;

namespace BackGetTalentsV2.Controllers
{
    [Route("skills")]
    [ApiController]
    public class SkillsController : Controller
    {
        private ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpPost]
        public IActionResult CreateSkill([FromBody] SkillDTOMinimalist skillDTO)
        {
            Skill skill = SkillHelper.ConvertSkillDTO(skillDTO);
            _skillService.AddSkill(skill);
            return Created(nameof(CreateSkill), skill);
        }

        [HttpGet]
        public IActionResult GetSkills()
        {
            IList<Skill> skills = _skillService.GetAllSkills();
            List<SkillDTO> skillsDTO = SkillHelper.ConvertSkills(skills.ToList());
            return Ok(skillsDTO);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSkillById([FromRoute] int id)
        {
            try
            {
                Skill skill = _skillService.GetSkillById(id);

                SkillDTO skillDTO = SkillHelper.ConvertSkill(skill);

                return Ok(skillDTO);
            }
            catch (SkillNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateSkill([FromRoute] int id, [FromBody] Skill skill)
        {
            try
            {
                _skillService.UpdateSkill(id, skill);
                return NoContent();
            }
            catch (SkillNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteSkill([FromRoute] int id)
        {
            try
            {
                _skillService.DeleteSkill(id);
                return NoContent();
            }
            catch (SkillNotFoundException)
            {
                return NotFound();
            }
        }

    }


}