using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Core.Repositories;
using System.Data.Entity;

namespace K_Systems.Data.Persistance.Repositories
{
    class TrainingHistoryRepository : Repository<TrainingHistory>, ITrainingHistoryRepository
    {
        public TrainingHistoryRepository(ERPModel ctx) : base(ctx)
        {

        }

        public IEnumerable<TrainingHistory> GetByName(string search, int items, string sortBy, string order, int page, out int totalPages)
        {
            var context = Ctx as ERPModel;

            IEnumerable<TrainingHistory> trainingHistories;
            if (string.IsNullOrEmpty(search))
            {
                trainingHistories = context.TrainingHistories.Include(e => e.Employee).Include(c => c.Course);
            }
            else
            {
                trainingHistories = context.TrainingHistories
                .Include(t => t.Employee)
                .Include(c => c.Course)
                .Where(e => (string.Concat(e.Employee.fName.ToLower(), " ", e.Employee.lName.ToLower()))
                .Contains(search.ToLower()));
            }

            int ct = trainingHistories.Count();
            totalPages = (int)Math.Ceiling((double)trainingHistories.Count() / items);

            switch (sortBy)
            {
                case "cName":
                    if (order == "dsc")
                        trainingHistories = trainingHistories.OrderByDescending(e => e.Course.name);
                    else
                        trainingHistories = trainingHistories.OrderBy(e => e.Course.name);
                    break;
                case "eName":
                    if (order == "dsc")
                        trainingHistories = trainingHistories.OrderByDescending(e => e.Employee.fName);
                    else
                        trainingHistories = trainingHistories.OrderBy(e => e.Employee.fName);
                    break;
                case "result":
                    if (order == "dsc")
                        trainingHistories = trainingHistories.OrderByDescending(e => e.result);
                    else
                        trainingHistories = trainingHistories.OrderBy(e => e.result);
                    break;
                default:
                    if (order == "dsc")
                        trainingHistories = trainingHistories.OrderByDescending(e => e.trainingDate);
                    else
                        trainingHistories = trainingHistories.OrderBy(e => e.trainingDate);
                    break;
            }
            trainingHistories = trainingHistories.Skip((page - 1) * items).Take(items).AsEnumerable();

            return trainingHistories;
        }


    }
}



//.Join(employees, t => t.employeeID, ee => ee.ID, (th, te) => new TrainingHistory { Employee = te, courseID = th.courseID, result = th.result, trainingDate = th.trainingDate })