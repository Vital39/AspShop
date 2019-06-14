using Shop.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LinqKit;

namespace Shop.ConsoleTestService
{
    class GoodFilter
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }

        public string GoodName { get; set; }
        public Expression<Func<GoodDTO, bool>> Predicate
        {
            get
            {
                var predicate = PredicateBuilder.New<GoodDTO>(true);
                if(!string.IsNullOrEmpty(GoodName))
                {
                    predicate = predicate.And(g => g.GoodName.Contains(GoodName));
                }
                if (MinPrice>0)
                {
                    predicate = predicate.And(g => g.Price >= MinPrice);
                }

                if (MaxPrice > 0)
                {
                    predicate = predicate.And(g => g.Price <= MaxPrice);
                }
                return predicate;
            }
        }
    }
}
