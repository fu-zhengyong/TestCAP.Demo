using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using TestCAP.Events;

namespace TestCAP.StorageService.Services
{
    public class OrderSubscriberService : IOrderSubscriberService, ICapSubscribe
    {
        private readonly string _connStr;
        
        public OrderSubscriberService(string connStr)
        {
            _connStr = connStr;
        }

        [CapSubscribe(EventConstants.EVENT_NAME_CREATE_ORDER)]
        public void ConsumeOrderMessage(OrderMessage message)
        {
            Console.Write($"[StorageService] Received message : {JsonConvert.SerializeObject(message)}");
            //await UpdateStorageNumberAsync(message);
        }

        private async Task<bool> UpdateStorageNumberAsync(OrderMessage order)
        {
            Console.Out.WriteLineAsync($"[StorageService] StorageNumber - 1");
            return true;
            //using (var conn = new SqlConnection(_connStr))
            //{
            //    string sqlCommand = @"UPDATE [dbo].[Storages] SET StorageNumber = StorageNumber - 1
            //                                                    WHERE StorageID = @ProductID";

            //    int count = await conn.ExecuteAsync(sqlCommand, param: new
            //    {
            //        ProductID = order.ProductID
            //    });

            //    return count > 0;
            //}
        }
    }
}
