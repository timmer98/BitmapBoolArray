﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace MemorySavingBoolArray
{
    public interface IMemorySavingBoolArray
    {
        public int Length { get; }

        public bool this[int index] { get; set; }
    }
}
