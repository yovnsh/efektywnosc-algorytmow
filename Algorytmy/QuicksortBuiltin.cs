﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy
{
    public class QuicksortBuiltin : ISortingAlgorithm
    {
        public void Sort(int[] array)
        {
            Array.Sort(array);
        }
    }
}