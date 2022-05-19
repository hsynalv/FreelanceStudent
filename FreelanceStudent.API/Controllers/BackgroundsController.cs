using FreelanceStudent.Entity.DTOs;
using FreelanceStudent.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreelanceStudent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackgroundsController : CustomBaseController
    {
        private readonly IBackgroundService _backgroundService;

        public BackgroundsController(IBackgroundService backgroundService)
        {
            _backgroundService = backgroundService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _backgroundService.GetAllAsync();
            return ActionResultInstance(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var background = await _backgroundService.GetByIdAsync(id);
            return ActionResultInstance(background); 
        }

        [HttpPost]
        public async Task<IActionResult> Add(BackgroundDto backgroundDto)
        {
            var result = await _backgroundService.AddAsync(backgroundDto);
            return ActionResultInstance(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _backgroundService.Remove(id);
            return ActionResultInstance(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BackgroundDto backgroundDto)
        {
            var result = await _backgroundService.Update(backgroundDto, backgroundDto.BackgroundId);
            return ActionResultInstance(result);
        }

    }
}
