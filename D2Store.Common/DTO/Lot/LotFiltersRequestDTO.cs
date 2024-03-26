using D2Store.Domain.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Store.Common.DTO.Lot
{
    public class LotFiltersRequestDTO
    {
        public double? MinPrice { get; set; }

        public double? MaxPrice { get; set;}

        public Rarity? Rarity { get; set; }

        public string? HeroName { get; set; }

        public string? ItemName { get; set; }
    }
}
