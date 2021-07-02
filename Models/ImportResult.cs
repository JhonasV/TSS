﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSS.Models
{
    public class ImportResult
    {
        public string Name { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
    }
}
