using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Core.Repositories;

namespace K_Systems.Data.Persistance.Repositories
{
    class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ERPModel ctx) : base(ctx)
        {

        }

        public IEnumerable<Order> FullSearch(TablePageInfo pageInfo, out int totalPages)
        {
            var context = Ctx as ERPModel;
            SqlParameter outParam = new SqlParameter
            {
                ParameterName = "totalPages",
                Value = 0,
                Direction = System.Data.ParameterDirection.Output
            };
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@employeeName",pageInfo.search ?? string.Empty),
                new SqlParameter("@customerName",""),
                new SqlParameter("@startDate",""),
                new SqlParameter("@endDate",""),
                new SqlParameter("@shipAddress",""),
                new SqlParameter("@orderBy",pageInfo.sortBy),
                new SqlParameter("@order",pageInfo.order),
                new SqlParameter("@items",pageInfo.items),
                new SqlParameter("@page",pageInfo.page),
                outParam
            };
            List<Order> orders = context.Database.SqlQuery<Order>("Exec OrderFullSearch @employeeName , @customerName , @startDate , @endDate, @shipAddress, @orderBy , @order , @items , @page , @totalPages OUTPUT", sqlParameters).ToList();
            totalPages = (int)outParam.Value;
            return orders;
        }
    }
}
