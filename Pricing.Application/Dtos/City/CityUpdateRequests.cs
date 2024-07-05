using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Application.Dtos.City
{
    public sealed record CityUpdateRequests
    (
        Guid Id,
        string Name
    );
    
}
