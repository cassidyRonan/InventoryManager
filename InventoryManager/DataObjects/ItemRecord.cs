using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.DataObjects
{
    public abstract class ItemRecord
    {
        protected string id;
    }

    public class ConsumableRecord : ItemRecord
    {
        private int amount;

        public ConsumableRecord(int amnt, string iD)
        {
            amount = amnt;
            id = iD;
        }
    }
}
