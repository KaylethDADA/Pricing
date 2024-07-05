using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Application.Dtos.Shop
{
    public sealed record ShopCreateRequests
    (
        string Name,
        string Address,
        Guid CityId
    );
}
