using JSWSample.Domain.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTSample.Application
{
    public interface IApplicationDbContext
    {
        User User { get; set; }
    }
}
