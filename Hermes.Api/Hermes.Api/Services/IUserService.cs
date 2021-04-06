using Hermes.Api.Models;
using Hermes.Api.Models.Request;
using Hermes.Api.Models.Response;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hermes.Api.Helpers
{
    public interface IUserService
    {
        UserResponse Auth(AuthRequest model);

    }

}
