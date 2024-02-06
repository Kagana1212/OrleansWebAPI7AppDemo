using Microsoft.AspNetCore.Mvc;
using Orleans.Serialization.Codecs;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;
using System;

namespace OrleansWebAPI7AppDemo.Controllers.Accounting
{
    [ApiController]
    [Route("A/[controller]")]
    public class ATimeController : ControllerBase
    {

        private readonly IGrainFactory _grains;

        public ATimeController(IGrainFactory grains)
        {
            _grains = grains;
        }

        [HttpGet()]
        [Route("Time")]
        public IList<string> Index()
        {
            var items = new List<string>();
            // ↓↓　一般的にはデータベースから取得する
            // SELECT * FROM AccountItem;
            items.Add("日本");
            items.Add("アメリカ");
            items.Add("イギリス");
            // ↑↑　
            return items;
        }

        [HttpGet()]
        [Route("{id}")]

        public async Task<IActionResult> Get(String id)
        {
            // グレインの呼び出し
            var accountGrain = _grains.GetGrain<IAccountItemGrain>(id);
            // 指定グレインのGETメソッドを実行して結果を取得する
            var accountItem = await accountGrain.Get();
            if (accountItem == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(accountItem);
            }
        }



    }
}

