using MediatR;
using POS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.Application.Queries
{
    public class GetProductById
    {
        public class Request : IRequest<Response>
        {
            public int Id { get; set; }
        }

        public class Response
        {
            public string Name { get; set; } = string.Empty;

            [Column(TypeName = "decimal(18, 2)")]
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
    }

    
}
