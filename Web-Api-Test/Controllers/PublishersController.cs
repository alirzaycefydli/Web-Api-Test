﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Api_Test.Data.Services;
using Web_Api_Test.Data.ViewModels;

namespace Web_Api_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {

        public PublishersService _publisherService;

        public PublishersController(PublishersService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddAuthor([FromBody] PublisherViewModel publisherViewModel)
        {
            _publisherService.AddPublisher(publisherViewModel);
            return Ok();
        }
    }
}
