using System.Collections.ObjectModel;

namespace PhoneCompany.Common.Utilities.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        public static void AddRangeClear<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            collection.Clear();
            collection.AddRange(items);
        }
    }
}
