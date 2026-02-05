using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DomainLayer.Contracts;
using Service;
using ServiceAbstraction;

namespace Services
{
    public class ServiceManger(IUnitOfWork unitOfWork , IMapper mapper) : IServiceManger
    {
        private readonly Lazy<IProductService> _LazyProductService = new Lazy<IProductService>(() => new ProductService(unitOfWork,mapper));
        public IProductService ProductService => _LazyProductService.Value;
    }
}
