using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Queries
{
    public class GetAllBlogQuery
    {
        [FromQuery(Name = "categoryId")]
        public int BlogCategoryId { get; set; }
    }
}
