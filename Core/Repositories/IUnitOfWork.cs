﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public  interface IUnitOfWork:IAsyncDisposable
    {
       IGenericRepository<Tentity> Repository<Tentity>() where Tentity : class;

         Task<int> Complete();
    }
}
