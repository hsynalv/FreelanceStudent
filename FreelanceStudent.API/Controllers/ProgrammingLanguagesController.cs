using FreelanceStudent.Entity.DTOs;
using FreelanceStudent.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreelanceStudent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : CustomBaseController
    {
        private readonly IProgrammingLanguageService _programmingLanguageService;

        public ProgrammingLanguagesController(IProgrammingLanguageService programmingLanguageService)
        {
            _programmingLanguageService = programmingLanguageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _programmingLanguageService.GetAllAsync();
            return ActionResultInstance(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var programmingLanguage = await _programmingLanguageService.GetByIdAsync(id);
            return ActionResultInstance(programmingLanguage);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProgrammingLanguageDto programmingLanguageDto)
        {
            var result = await _programmingLanguageService.AddAsync(programmingLanguageDto);
            return ActionResultInstance(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _programmingLanguageService.Remove(id);
            return ActionResultInstance(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProgrammingLanguageDto programmingLanguageDto)
        {
            var result = await _programmingLanguageService.Update(programmingLanguageDto, programmingLanguageDto.LanguageId);
            return ActionResultInstance(result);
        }
    }
}
