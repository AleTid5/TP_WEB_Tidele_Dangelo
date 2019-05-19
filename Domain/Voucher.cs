﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Voucher
    {
        public int Id { set; get; }
        public String Code { set; get; }
        public String Status { set; get; }
        public User User { set; get; }
        public Product Product { set; get; }
    }
}
