﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core_DomainLayer_.Enitities_Models_
{
	public class CustomerBasket
	{
        public CustomerBasket(string id)
        {
            Id = id;
			Items = new List<BasketItem>();
		}
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}
