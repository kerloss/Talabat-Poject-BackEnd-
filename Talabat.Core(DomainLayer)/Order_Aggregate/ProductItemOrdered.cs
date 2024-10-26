using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core_DomainLayer_.Order_Aggregate
{
	public class ProductItemOrdered
	{
        public ProductItemOrdered()
        {
            
        }
        public ProductItemOrdered(int productID, string productName, string productUrl)
		{
			ProductID = productID;
			ProductName = productName;
			ProductUrl = productUrl;
		}

		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string ProductUrl { get; set; }
	}
}
