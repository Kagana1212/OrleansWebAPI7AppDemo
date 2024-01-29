using Microsoft.AspNetCore.Mvc;
using Orleans.Serialization.Codecs;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;
using System;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("A/[controller]")]
    public class AController : ControllerBase
    {

        private readonly IGrainFactory _grains;

        public AController(IGrainFactory grains)
        {
            _grains = grains;
        }
       

        [HttpGet()]
        [Route("日本")]
        public string getday()
        {

            return DateTime.Now.ToString();

            
        }
        [HttpGet()]
        [Route("イギリス(UTC)")]
        public string gettime()
        {

            return DateTime.UtcNow.ToString();


        }

        [HttpGet()]
        [Route("アメリカ")]
        public string getdate()
        {

            return DateTime.Now.AddHours(-14).ToString();



        }

    }
}

