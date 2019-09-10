using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cupertino.Core;
using Cupertino.Core.Models;
using Cupertino.Data.Helpers;

namespace Cupertino.Application.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Data.Entities.Product> repository;

        public ProductService(IRepository<Data.Entities.Product> repository)
        {
            this.repository = repository;
        }

        public async Task<List<Data.Entities.Product>> SearchAsync(string productName)
        {
            var query = this.repository.GetQueryable();

            if (!string.IsNullOrWhiteSpace(productName))
            {
                query = query.Where(row => row.Name.Contains(productName));
            }

            return await query.ToListAsync();
        }

        public async Task<Data.Entities.Product> GetAsync(Guid productId)
        {
            return await this.repository
                .GetQueryable()
                .FirstOrDefaultAsync(product => product.Id == productId);
        }

        public async Task<OperationResult> InsertAsync(Data.Entities.Product product)
        {
            var productValidation = this.ValidateNameAndBrand(product);

            if (productValidation != null)
            {
                return productValidation;
            }

            return await this.repository.InsertAsync(product);
        }

        public async Task<OperationResult> UpdateAsync(Data.Entities.Product product)
        {
            var productValidation = this.ValidateId(product)
                                 ?? this.ValidateNameAndBrand(product);

            if (productValidation != null)
            {
                return productValidation;
            }

            return await this.repository.UpdateAsync(product);
        }

        public async Task<OperationResult> DeleteAsync(Guid productId)
        {
            var product = await this.GetAsync(productId);

            if (product == null)
            {
                return new OperationResult(true);
            }

            return await this.repository.DeleteAsync(product);
        }

        private OperationResult ValidateId(Data.Entities.Product product)
        {
            if ((product?.Id ?? Guid.Empty) == Guid.Empty)
            {
                return new OperationResult("The product id is missing.");
            }

            return null;
        }

        private OperationResult ValidateNameAndBrand(Data.Entities.Product product)
        {
            if (string.IsNullOrWhiteSpace(product?.Name))
            {
                return new OperationResult("The product name is missing.");
            }

            if (string.IsNullOrWhiteSpace(product.Brand))
            {
                return new OperationResult("The product brand is missing.");
            }

            return null;
        }
    }
}
