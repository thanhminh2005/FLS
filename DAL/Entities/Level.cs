using System;
using System.Collections.Generic;

#nullable disable

namespace DAL
{
    public partial class Level
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual TeachingLevel IdNavigation { get; set; }
    }
}
