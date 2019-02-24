﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Core.Repositories;

namespace K_Systems.Data.Persistance.Repositories
{
    class OrderDetailRepository:Repository<OrderDetail>,IOrderDetailRepository
    {
        public OrderDetailRepository(ERPModel ctx):base(ctx)
        {

        }
    }
}
