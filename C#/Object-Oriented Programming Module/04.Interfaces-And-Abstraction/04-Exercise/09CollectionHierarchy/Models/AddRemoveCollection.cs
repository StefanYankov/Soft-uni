﻿using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : Collection, IAddRemoveCollection
    {
        public string Remove()
        {
            string item = base.Data[base.Data.Count - 1];
            base.Data.RemoveAt(base.Data.Count - 1);

            return item;
        }
    }
}
