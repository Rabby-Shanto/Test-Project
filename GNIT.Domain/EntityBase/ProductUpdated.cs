﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNIT.Domain.EntityBase
{
    public class ProductUpdated
    {
        public string Error { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
