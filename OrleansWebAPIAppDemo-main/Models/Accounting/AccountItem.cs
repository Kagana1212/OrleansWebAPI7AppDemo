namespace OrleansWebAPI7AppDemo.Models.Accounting
{
    [GenerateSerializer]
    public class AccountItem
    {
        // 勘定科目コード
        [Id(0)]
        public string 首都 { get; set; } = String.Empty;
        public string 観光地 { get; set; } = String.Empty;

    }




}
