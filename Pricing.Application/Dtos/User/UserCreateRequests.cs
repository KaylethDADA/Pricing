using Pricing.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Application.Dtos.User
{
    public sealed record UserCreateRequests(
        FullName FullName,
        string Email,
        string password
        );
}
