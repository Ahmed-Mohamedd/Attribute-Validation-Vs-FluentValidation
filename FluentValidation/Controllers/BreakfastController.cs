using AutoMapper;
using Core.Entities;
using Core.Repositories;
using FluentValidation.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Reflection.Metadata.Ecma335;

namespace FluentValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreakfastController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<BreakfastDto> _validator;
        public BreakfastController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<BreakfastDto> validator)
        {
            _unitOfWork=unitOfWork;
            _mapper=mapper;
            _validator=validator;
        }

        [HttpPost]
        public async Task<ActionResult> TakeBreakfast(BreakfastDto breakFast)
        {

            ValidationResult result = await _validator.ValidateAsync(breakFast);
            if(!result.IsValid)
            {
                var errors = new ModelStateDictionary();
                foreach (ValidationFailure validationFailure in result.Errors)
                    errors.AddModelError(validationFailure.PropertyName , validationFailure.ErrorMessage);
                return BadRequest(errors);
            }
            var breakfast = _mapper.Map<BreakfastDto , BreakFast>(breakFast);
            await _unitOfWork.Repository<BreakFast>().Add(breakfast);
            await _unitOfWork.Complete();
            return Ok(breakFast);
        }
    }
}
