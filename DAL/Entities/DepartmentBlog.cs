using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Entities
{
    public partial class DepartmentBlog
    {
        public int DepartmentId { get; set; }
        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
        public virtual Department Department { get; set; }
    }
}
