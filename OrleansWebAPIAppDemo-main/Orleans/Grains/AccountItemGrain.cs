using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Orleans.Runtime;
using OrleansWebAPI7AppDemo.Models.Accounting;
using OrleansWebAPI7AppDemo.Orleans.Abstractions;

namespace OrleansWebAPI7AppDemo.Orleans.Grains
{
    public class AccountItemGrain : Grain , IAccountItemGrain
    {
        private AccountItem? _model { get; set; }

        public AccountItemGrain()
        {
        }

        /// <summary>
        /// グレイン有効化時の処理
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnActivateAsync(CancellationToken cancellationToken)
        {

            string primaryKey = this.GetPrimaryKeyString(); //Grain IDを取得

            // ↓　本来はデータベースから取得する
            switch(primaryKey)
            {
                case "日本":
                    {
                        _model = new AccountItem
                        {
                            首都 = "東京",

                        };
                        
                    }
                    break;
                case "アメリカ":
                    {
                        _model = new AccountItem
                        {
                            首都 = "ワシントンD.C.",
                        };
                    }
                    break;
                case "イギリス":
                    {
                        _model = new AccountItem
                        {
                            首都 = "ロンドン",


                        };
                    }
                    break;
                case "フランス":
                    {
                        _model = new AccountItem
                        {
                            首都 = "パリ",


                        };
                    }
                    break;


                default:

                    break;
            }

            return base.OnActivateAsync(cancellationToken);
        }

        public Task<AccountItem?> Get()
        {
            return Task.FromResult(_model);
        }

        public Task Set(AccountItem company)
        {
            // UPDATE company SET 住所1 = '**** ;
            _model = company;
            return Task.CompletedTask;
        }

        public Task Remove()
        {
            // DELETE FROM company where ID = '****' ;
            _model = null;
            return Task.CompletedTask;
        }



    }


}
