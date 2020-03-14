using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class MyList : Collection, IAddRemoveCollection, IMylist
    {
        public string Remove()
        {
            string item = base.Data[0];
            base.Data.RemoveAt(0);

            return item;
        }

        public string Used()
        {
            return string.Join(" ", base.Data);
        }
    }
}
