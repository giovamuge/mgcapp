using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Mugelli.Software.It.Mgc.Extensions
{
	public static class ObservableCollectionExtension
	{
		public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> value)
		{
			var result = new ObservableCollection<T>();
			foreach (var item in value) result.Add(item);
			return result;
		}

		public static List<T> ToList<T>(this ObservableCollection<T> value)
		{
			return Enumerable.ToList(value);
		}
	}
}