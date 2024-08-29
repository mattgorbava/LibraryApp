﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Model.Entities
{
    [PrimaryKey("PersonId", "BookId")]
    public class SubscriberBook
    {
        public int PersonId { get; set; }
        public virtual Subscriber Subscriber { get; set; }
        public string BookId { get; set; }
        public virtual Book Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public bool IsActive { get; set; }
    }
}
