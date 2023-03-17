﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Requests.PaggedList
{
    public class PaggedListItemResponse
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        //public int TotalCount { get; set; }
        //public int PageSize { get; set; }
        //public int TotalPages { get; set; }
        //public int CurrentPageNumber { get; set; }
        //public List<T> Items { get; set; }
        //public bool HasPreviousPage { get; set; }
        //public bool HasNextPage { get; set; }

    }
}