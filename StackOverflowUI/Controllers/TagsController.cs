using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StackOverflowAPI.Dtos;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StackOverflowUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        ITagsService _tagsService;
        IMapper _mapper;
        public TagsController(ITagsService tagsService, IMapper mapper)
        {
            _tagsService = tagsService;
            _mapper = mapper;
        }
        // GET: api/<TagsController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Tag> tags = _tagsService.Get();
            List<TagDTO> tagDTOs = _mapper.Map<List<TagDTO>>(tags);
            return Ok(tagDTOs);
        }
    }
}
