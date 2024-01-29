using Microsoft.AspNetCore.Mvc;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("TECH/[controller]")]
    public class TECHController : ControllerBase
    {

        private readonly IGrainFactory _grains;

        public TECHController(IGrainFactory grains)
        {
            _grains = grains;
        }
        /// <summary>
        /// 勘定科目を取得します
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("")]
        public IList<string> Index()
        {
            var items = new List<string>();
            // ↓↓　一般的にはデータベースから取得する
            // SELECT * FROM AccountItem;
            items.Add("100");
            items.Add("300");
            items.Add("700");
            // ↑↑　
            return items;
        }
        [HttpGet()]
        [Route("day")]
        public string getday()
        {

            return DateTime.Now.ToLongTimeString();
        }
    }
    
}