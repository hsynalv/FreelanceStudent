using FreelanceStudent.Entity.DTOs;
using FreelanceStudent.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreelanceStudent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForeignLanguagesController : CustomBaseController
    {
        private readonly IForeignLanguageService _foreignLanguageService;

        public ForeignLanguagesController(IForeignLanguageService foreignLanguageService)
        {
            _foreignLanguageService = foreignLanguageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _foreignLanguageService.GetAllAsync();
            return ActionResultInstance(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var foreignLanguage = await _foreignLanguageService.GetByIdAsync(id);
            return ActionResultInstance(foreignLanguage);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ForeignLanguageDto foreignLanguageDto)
        {
            var result = await _foreignLanguageService.AddAsync(foreignLanguageDto);
            return ActionResultInstance(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _foreignLanguageService.Remove(id);
            return ActionResultInstance(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ForeignLanguageDto foreignLanguageDto)
        {
            var result = await _foreignLanguageService.Update(foreignLanguageDto, foreignLanguageDto.FLanguageId);
            return ActionResultInstance(result);
        }
    }
}
