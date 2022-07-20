using AutoMapper;
using Curso.ComercioElectronico.Aplicacion.Dtos;
using Curso.ComercioElectronico.Aplicacion.Dtos.Create;
using Curso.ComercioElectronico.Aplicacion.Exceptions;
using Curso.ComercioElectronico.Aplicacion.Services;
using Curso.ComercioElectronico.Dominio.Entities;
using Curso.ComercioElectronico.Dominio.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Aplicacion.ServicesImpl
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IGenericRepository<Order> orderRepository;
        private readonly IGenericRepository<OrderLine> orderLineRepository;
        private readonly IGenericRepository<Product> productRepository;
        private readonly IGenericRepository<DeliveryMethod> deliveryMethodRepository;
        private readonly IMapper mapper;
        private readonly IValidator<CreateOrderDto> orderValidator;
        private readonly IValidator<CreateOrderLineDto> orderLineValidator;

        public OrderAppService(
            IGenericRepository<Order> orderRepository, 
            IGenericRepository<OrderLine> orderLineRepository,
            IGenericRepository<Product> productRepository,
            IGenericRepository<DeliveryMethod> deliveryMethodRepository,
            IMapper mapper,
            IValidator<CreateOrderDto> orderValidator,
            IValidator<CreateOrderLineDto> orderLineValidator
            )
        {
            this.orderRepository = orderRepository;
            this.orderLineRepository = orderLineRepository;
            this.productRepository = productRepository;
            this.deliveryMethodRepository = deliveryMethodRepository;
            this.deliveryMethodRepository = deliveryMethodRepository;
            this.mapper = mapper;
            this.orderValidator = orderValidator;
            this.orderLineValidator = orderLineValidator;
        }

        public async Task<ResultPagination<OrderDto>> GetAllAsync(string? search = "", int offset = 0, int limit = 10, string sort = "Client", string order = "asc")
        {
            var query = orderRepository.GetQueryable();
            query = query.Where(x => x.IsDeleted == false);
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(
                    x => x.ClientName.ToUpper().Contains(search.ToUpper()) ||
                    x.ClientAddress.ToUpper().Contains(search.ToUpper())
                );
            }
            var total = await query.CountAsync();
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToUpper())
                {
                    case "CLIENT":
                        query = query.OrderBy(x => x.ClientName);
                        break;
                    case "DELIVERYMETHOD":
                        query = query.OrderBy(x => x.DeliveryMethod.Name);
                        break;
                    default:
                        throw new NotFoundException($"The parameter sort {sort} not support");
                }
            }
            query = query.Skip(offset).Take(limit);

            var ordersDto = query.Select(x => new OrderDto()
            {
                Id = x.Id,
                ClientAddress = x.ClientAddress,
                ClientName = x.ClientName,
                DeliveryMethod = x.DeliveryMethod.Name,
                Subtotal = x.Subtotal,
                Taxes = x.Taxes,
                Discount = x.Discount,
                Total = x.Total
            }).ToList();
            foreach (var item in ordersDto)
            {
                var lines = orderLineRepository.GetQueryable().Where(x => x.OrderId == item.Id);
                var linesDto = await lines.Select(x => new OrderLineDto()
                {
                    Id = x.Id,
                    Product = x.Product.Name,
                    Quantity = x.Quantity,
                    Subtotal = x.Subtotal,
                    TaxeRate = x.TaxRate,
                    Taxes = x.Taxes,
                    DiscountRate = x.DiscountRate,
                    Discount = x.Discount,
                    Total = x.Total
                }).ToListAsync();
                item.OrderLines = linesDto;
            }

            var result = new ResultPagination<OrderDto>();
            result.Total = total;
            result.Items = ordersDto;

            return result;
        }

        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            var query = orderRepository.GetQueryable();
            query = query.Where(x => x.IsDeleted == false && x.Id == id);
            if (query.Count() > 1)
                throw new NotFoundException($"Orden con id {id} no encontrado");
            var orderDto = await query.Select(x => new OrderDto
            {
                Id = x.Id,
                ClientName = x.ClientName,
                ClientAddress = x.ClientAddress,
                DeliveryMethod = x.DeliveryMethod.Name,
                Subtotal = x.Subtotal,
                Taxes = x.Taxes,
                Discount = x.Discount,
                Total = x.Total
            }).SingleOrDefaultAsync();

            var lines = orderLineRepository.GetQueryable().Where(x => x.OrderId == orderDto.Id);
            var linesDto = await lines.Select(x => new OrderLineDto()
            {
                Id = x.Id,
                Product = x.Product.Name,
                Quantity = x.Quantity,
                Subtotal = x.Subtotal,
                TaxeRate = x.TaxRate,
                Taxes = x.Taxes,
                DiscountRate = x.DiscountRate,
                Discount = x.Discount,
                Total = x.Total
            }).ToListAsync();
            orderDto.OrderLines = linesDto;
            return orderDto;
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await orderRepository.GetByIdAsync(id);
            if (order == null || order.IsDeleted == true)
                throw new NotFoundException($"Orden con codigo {id} no encontrado.");
            order.IsDeleted = true;
            order.ModifiedDate = DateTime.Now;
            await orderRepository.UpdateAsync(order);
        }

        public async Task UpdateAsync(Guid id, CreateOrderDto orderDto)
        {
            await orderValidator.ValidateAndThrowAsync(orderDto);
            var order = await orderRepository.GetByIdAsync(id);
            if (order == null || order.IsDeleted == true)
                throw new NotFoundException($"Orden con codigo {id} no encontrado.");
            order.ClientName = orderDto.ClientName;
            order.ClientAddress = orderDto.ClientAddress;
            order.ModifiedDate = DateTime.Now;
            order.DeliveryMethodId = orderDto.DeliveryMethodId;
            await orderRepository.UpdateAsync(order);
        }

        public async Task CreateAsync(CreateOrderDto orderDto)
        {
            await orderValidator.ValidateAndThrowAsync(orderDto);
            
            var deliveryMethod = await deliveryMethodRepository.GetByIdAsync(orderDto.DeliveryMethodId);
            if (deliveryMethod == null || deliveryMethod.IsDeleted)
                throw new NotFoundException($"Metodo de entrega con codigo {orderDto.DeliveryMethodId} no encontrado.");
            
            var orderId = new Guid();
            var order = new Order()
            {
                Id = orderId,
                ClientName = orderDto.ClientName,
                ClientAddress = orderDto.ClientAddress,
                DeliveryMethodId = orderDto.DeliveryMethodId,
                CreationDate = DateTime.Now
            };

            var lines = new List<OrderLine>();
            if(orderDto.OrderLines.Count > 0)
            {
                foreach (var line in orderDto.OrderLines)
                {
                    await orderLineValidator.ValidateAndThrowAsync(line);
                    var product = await productRepository.GetByIdAsync(line.ProductId);
                    if (product == null || product.IsDeleted == true)
                        throw new NotFoundException($"Producto con codigo {line.ProductId} no encontrado.");
                    
                    var subtotal = line.Quantity * product.Price;
                    var tax = subtotal * (line.TaxRate / 100);
                    var discount = subtotal * (line.DiscountRate / 100);

                    var orderLine = new OrderLine()
                    {
                        Id = new Guid(),
                        ProductId = line.ProductId,
                        Quantity = line.Quantity,
                        TaxRate = line.TaxRate,
                        DiscountRate = line.DiscountRate,
                        Subtotal = subtotal,
                        Taxes = tax,
                        Discount = discount,
                        Total = subtotal - discount + tax,
                        CreationDate = DateTime.Now
                    };
                    lines.Add(orderLine);
                }
            }

            order.Subtotal = lines.Sum(x => x.Subtotal);
            order.Taxes = lines.Sum(x => x.Taxes);
            order.Discount = lines.Sum(x => x.Discount);
            order.Total = lines.Sum(x => x.Total);


            await orderRepository.CreateAsync(order);

            foreach (var line in lines)
                line.OrderId = order.Id;
            await orderLineRepository.CreateRangeAsync(lines);            
        }
    }
}
