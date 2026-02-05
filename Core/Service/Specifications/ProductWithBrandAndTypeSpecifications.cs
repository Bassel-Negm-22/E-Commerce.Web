using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;
using Shared;

namespace Services.Specifications
{
    class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product, int>
    {
        // Get All Products With Types And Brands
        public ProductWithBrandAndTypeSpecifications(ProductQueryParams queryParams) 
            :base(P => (!queryParams.BrandId.HasValue || P.BrandId ==queryParams.BrandId)
            &&(!queryParams.TypeId.HasValue || P.TypeId == queryParams.TypeId) && (string.IsNullOrWhiteSpace(queryParams.SearchValue) ||P.Name.ToLower().Contains(queryParams.SearchValue.ToLower())))
        {
            AddInclude(includeExpression: P => P.ProductBrand);
            AddInclude(includeExpression: P => P.ProductType);
            switch (queryParams.SortingOption)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(orderByExp: P => P.Name);
                    break;

                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(orderByDescExp: P => P.Name);
                    break;

                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(orderByExp: P => P.Price);
                    break;

                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(orderByDescExp: P => P.Price);
                    break;

                default:
                    break;
            }

            ApplyPagination(queryParams.PageSize, queryParams.PageIndex);

        }

        public ProductWithBrandAndTypeSpecifications(int id) : base(p=>p.Id == id)
        {
            AddInclude(includeExpression: P => P.ProductBrand);
            AddInclude(includeExpression: P => P.ProductType);
        }


    }

}
