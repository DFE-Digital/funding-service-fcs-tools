namespace VelocityCalculator.Persistence
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class CsvWriter<T> where T : class
    {
        private readonly PropertyInfo[] _typePropertyInfos;

        public CsvWriter()
        {
            _typePropertyInfos = typeof(T).GetProperties();

            //_typePropertyInfos = _typePropertyInfos.OrderBy(pi => (GetOrderAttributeForProperty(pi)).Order).ToArray();
        }

        public string CreateCsv(IEnumerable<T> items)
        {
            List<string> csvLines = new List<string>();
            csvLines.Add(GetHeaderFileLine());
            csvLines.AddRange(GetItemsInCsvFormat(items));

            StringWriter writer = new StringWriter();
            csvLines.ForEach(writer.WriteLine);

            return writer.ToString();
        }

        private string GetHeaderFileLine()
        {
            return string.Join(",", _typePropertyInfos.Select(pi => pi.Name));
        }

        private IList<string> GetItemsInCsvFormat(IEnumerable<T> items)
        {
            return items.Select(i => string.Join(",", _typePropertyInfos.Select(pi => pi.GetValue(i)))).ToList();
        }

        private static OrderAttribute GetOrderAttributeForProperty(MemberInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttribute<OrderAttribute>() ?? new OrderAttribute(1);
        }
    }
}
