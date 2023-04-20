using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Data
{
    public class DbContextUser : DbContext
    {
        protected readonly IConfiguration Configuration;

    }
}
