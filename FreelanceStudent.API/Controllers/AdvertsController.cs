using FreelanceStudent.Entity.DTOs;
using FreelanceStudent.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FreelanceStudent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertsController : CustomBaseController
    {
        private readonly IAdvertService _advertService;

        public AdvertsController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _advertService.GetAllAsync();
            return ActionResultInstance(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var advert = await _advertService.GetByIdAsync(id);
            return ActionResultInstance(advert);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdvertDto advert)
        {
            var result = await _advertService.AddAsync(advert);
            return ActionResultInstance(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _advertService.Remove(id);
            return ActionResultInstance(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AdvertDto advert)
        {
            var result = await _advertService.Update(advert, advert.AdvertId);
            return ActionResultInstance(result);
        }



    }
}
