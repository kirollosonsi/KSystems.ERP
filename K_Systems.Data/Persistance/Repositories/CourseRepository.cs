using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K_Systems.Data.Core.Domain;
using K_Systems.Data.Core.Repositories;

namespace K_Systems.Data.Persistance.Repositories
{
    class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ERPModel ctx) : base(ctx)
        {

        }

        public IEnumerable<Course> GetByName(string search, int items, string sortBy, string order, int page, out int totalPages)
        {
            var context = Ctx as ERPModel;
            IEnumerable<Course> courses = context.Courses
                .Where(e => (e.name + " " + e.name)
                .ToLower()
                .Contains(search));
            totalPages = (int)Math.Ceiling((double)courses.Count() / items);

            switch (sortBy)
            {
                case "name":
                    if (order == "dsc")
                        courses = courses.OrderByDescending(e => e.name);
                    else
                        courses = courses.OrderBy(e => e.name);
                    break;
                case "description":
                    if (order == "dsc")
                        courses = courses.OrderByDescending(e => e.description);
                    else
                        courses = courses.OrderBy(e => e.description);
                    break;
                default:
                    if (order == "dsc")
                        courses = courses.OrderByDescending(e => e.ID);
                    else
                        courses = courses.OrderBy(e => e.ID);
                    break;
            }
            courses = courses.Skip((page - 1) * items).Take(items).AsEnumerable();

            return courses;
        }

        public object GetNames(string term)
        {
            var context = Ctx as ERPModel;
            return context
                 .Courses
                 .Where(e => e.name.ToLower().Contains(term.ToLower()))
                 .Take(5)
                 .OrderBy(o => o.name)
                 .Select(e => new { label = e.name, value = e.ID });
        }
    }
}
