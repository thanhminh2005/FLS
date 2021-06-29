using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLS.Contracts.Queries
{
    public class GetAllBlogQuery
    {
        public int BlogCategoryId { get; set; }
        public int DepartmentId { get; set; }
    }
}
