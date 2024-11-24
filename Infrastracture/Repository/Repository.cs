using Core;
using Infrastracture.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Repository
{
    public class Repository:IRepository
    {
        public Task AddAsync(Balance balance)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "ErrorLogs");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (StreamWriter writer = System.IO.File.AppendText($"{path}/errorLogs.txt"))
            {
                writer.WriteLine("-----------------------------------");
                writer.WriteLine(balance);
            }
            return Task.CompletedTask;
        }

        public Task AddRangeAsync(List<Balance> balances)
        {
            // Build a text document in root of project

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Database");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (StreamWriter writer = System.IO.File.AppendText($"{path}/BalanceTbl.txt"))
            {
                writer.WriteLine("-----------------------------------");
                foreach (var balance in balances)
                {
                    writer.WriteLine(JsonConvert.SerializeObject(balance));
                }
            }
            return Task.CompletedTask;
        }
    }
}
