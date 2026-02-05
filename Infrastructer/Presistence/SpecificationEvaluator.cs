using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Presistence
{
        static class SpecificationEvaluator
        {
            // Create Query
            // _dbContext.Products.where(P=>P.id == id).Include(P=>P.productBrand).Include(P=>P.ProductType)

            public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(  IQueryable<TEntity> InputQuery, ISpecifications<TEntity, TKey> specifications) where TEntity : BaseEntity<TKey>
            {
                var Query = InputQuery;

                if (specifications.Criteria is not null)
                {
                    Query = Query.Where(specifications.Criteria);
                }

                if (specifications.OrderBy is not null)
                {
                    Query = Query.OrderBy(keySelector: specifications.OrderBy);
                }

                if (specifications.OrderByDescending is not null)
                {
                    Query = Query.OrderByDescending(keySelector: specifications.OrderByDescending);
                }


                 if (specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Count > 0)
                {
                    Query = specifications.IncludeExpressions.Aggregate(Query,(CurrentQuery, IncludeExp) =>
                            CurrentQuery.Include(IncludeExp));
                }

                 if (specifications.IsPaginated)
            {
                Query = Query.Skip(count: specifications.Skip)
                             .Take(count: specifications.Take);
            }


            return Query;
            }
        }

    
}
