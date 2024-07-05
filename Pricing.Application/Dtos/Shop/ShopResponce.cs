using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Application.Dtos.Shop
{
    public sealed record ShopResponce
    (
        Guid Id,
        string Name,
        string Address
    );
}
