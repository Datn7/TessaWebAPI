﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TessaWebAPI.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;


        private int pageSize = 6;

        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get => pageSize;
            set => pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }

    }
}
