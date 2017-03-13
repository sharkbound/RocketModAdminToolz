using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdminToolz.DataStorage;
using SDG.Unturned;

namespace AdminToolz.Helpers
{
    public class ItemHelper
    {
        public static ItemStats GetItemStatsFromAsset(ItemAsset i)
        {
            if (i == null)
                return new ItemStats { itemName = "NULL" };
            else
                return new ItemStats { itemName = i.itemName, id = i.id, desc = i.itemDescription };
        }
    }
}
