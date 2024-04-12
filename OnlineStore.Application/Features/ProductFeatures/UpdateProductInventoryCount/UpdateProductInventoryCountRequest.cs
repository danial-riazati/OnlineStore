using System;
using MediatR;

namespace OnlineStore.Application.Features.ProductFeatures.UpdateProductInventoryCount
{
    public class UpdateProductInventoryCountRequest : IRequest<UpdateProductInventoryCountResponse>
    {
        public string Title { get; set; }
        public int InventoryCount { get; set; }
    }
}

