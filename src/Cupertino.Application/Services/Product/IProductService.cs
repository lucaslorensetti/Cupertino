using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cupertino.Core.Common;
using Cupertino.Core.Models;

namespace Cupertino.Application.Services.Product
{
    public interface IProductService : IService
    {
        Task<List<Data.Entities.Product>> SearchAsync(string productName);
        Task<Data.Entities.Product> GetAsync(Guid productId);
        Task<OperationResult> InsertAsync(Data.Entities.Product product);
        Task<OperationResult> UpdateAsync(Data.Entities.Product product);
        Task<OperationResult> DeleteAsync(Guid productId);
    }
}
