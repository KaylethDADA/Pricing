using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Application.Dtos.Category
{
    public sealed record CategoryUpdateRequests
    (
    Guid Id,
    string Name
    );
}
