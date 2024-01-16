using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class BookAuthor
    {
        public int Baid { get; set; }
        public int? Aid { get; set; }

        public virtual Author? AidNavigation { get; set; }
    }
}
