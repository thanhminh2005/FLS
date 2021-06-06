using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Blog
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ModifiledDate { get; set; }
        public string BlogCategoryId { get; set; }
        public string DepartmentId { get; set; }

        public virtual BlogCategory BlogCategory { get; set; }
        public virtual Department Department { get; set; }
    }
}
