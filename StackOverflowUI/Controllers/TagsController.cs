using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        IConfiguration _configuration;
        ILogger _logger;
        public TagsController(ITagsService tagsService, IMapper mapper, IConfiguration configuration, ILogger<TagsController> logger)
        {
            _tagsService = tagsService;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
        }
        // GET: api/<TagsController>
        [HttpGet]
        public IActionResult Get()
        {
            var tags = _tagsService.Get(_configuration.GetValue<string>("Settings:StackOverflowApiKey"));
            var tagDTOs = _mapper.Map<List<TagDTO>>(tags);
            _logger.LogInformation("OK");
            return Ok(tagDTOs);
        }
    }
}
