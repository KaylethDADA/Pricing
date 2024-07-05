using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Application.Dtos.City
{
    public sealed record CityResponse
    (
        Guid Id,
        string Name
    );
    
}
