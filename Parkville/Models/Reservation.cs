﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Parkville.Models
{
    public class Reservation
    {
        public int Qty { get; set; }
        public int Price { get; set; }
        public string IsPaid { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string IsUsed { get; set; }
    }
}
