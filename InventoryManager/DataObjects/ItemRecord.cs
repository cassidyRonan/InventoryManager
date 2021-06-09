using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.DataObjects
{
    public abstract class ItemRecord
    {
        public long ID
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        protected long id;
    }
}
