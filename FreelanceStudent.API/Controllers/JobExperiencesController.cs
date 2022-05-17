using FreelanceStudent.Entity.DTOs;
using FreelanceStudent.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreelanceStudent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobExperiencesController : CustomBaseController
    {
        private readonly IJobExperienceService _jobExperienceService;

        public JobExperiencesController(IJobExperienceService jobExperienceService)
        {
            _jobExperienceService = jobExperienceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _jobExperienceService.GetAllAsync();
            return ActionResultInstance(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var job = await _jobExperienceService.GetByIdAsync(id);
            return ActionResultInstance(job);
        }

        [HttpPost]
        public async Task<IActionResult> Add(JobExperienceDto jobExperienceDto)
        {
            var result = await _jobExperienceService.AddAsync(jobExperienceDto);
            return ActionResultInstance(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _jobExperienceService.Remove(id);
            return ActionResultInstance(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(JobExperienceDto jobExperienceDto)
        {
            var result = await _jobExperienceService.Update(jobExperienceDto, jobExperienceDto.Id);
            return ActionResultInstance(result);
        }
    }
}
