using AutoMapper;
using Core.Entities;
using Core.Repositories;
using FluentValidation.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakfastController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BreakfastController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
        }

        [HttpPost]
        public async Task<ActionResult> TakeBreakfast(BreakfastDto breakFast)
        {
            var breakfast = _mapper.Map<BreakfastDto , BreakFast>(breakFast);
            await _unitOfWork.Repository<BreakFast>().Add(breakfast);
            await _unitOfWork.Complete();
            return Ok(breakFast);
        }
    }
}
