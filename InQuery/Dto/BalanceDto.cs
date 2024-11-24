using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InQuiry.Dto
{
    public class JsonData
    {
        public List<BalanceDto> data { get; set; }
    }
    public class BalanceDto
    {
        public string token_url { get; set; }
        public string token_name { get; set; }
        public decimal balance { get; set; }
    }
}
