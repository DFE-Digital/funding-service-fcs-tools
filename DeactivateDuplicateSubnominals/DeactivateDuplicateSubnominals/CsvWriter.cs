namespace DeactivateDuplicateSubnominals
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class CsvWriter<T> where T : class
    {
        private readonly string _fileName;
        private readonly List<string> _fileLines = new List<string>();
        private PropertyInfo[] _typePropertyInfos = null;

        public CsvWriter(string fileName)
        {
            _fileName = fileName;
        }

        public void SaveItems(IEnumerable<T> items)
        {
            _fileLines.Add(GetHeaderFileLine());

            // now add the data lines
            _fileLines.AddRange(GetItemsInCsvFormat(items));

            // now output the file
            CreateFile();
        }

        private IList<string> GetItemsInCsvFormat(IEnumerable<T> items)
        {
            return items.Select(i => string.Join(",", PropertyInfos.Select(pi => pi.GetValue(i)))).ToList();
        }

        private PropertyInfo[] PropertyInfos
        {
            get
            {
                if (_typePropertyInfos == null)
                {
                    _typePropertyInfos = typeof(T).GetProperties();

                    _typePropertyInfos = _typePropertyInfos.OrderBy(
                        pi => (GetOrderAttributeForProperty(pi)).Order).ToArray();
                }

                return _typePropertyInfos;
            }
        }

        private OrderAttribute GetOrderAttributeForProperty(PropertyInfo propertyInfo)
        {
            OrderAttribute order = propertyInfo.GetCustomAttribute<OrderAttribute>();

            return order ?? new OrderAttribute(1);
        }

        private string GetHeaderFileLine()
        {
            return string.Join(",", PropertyInfos.Select(pi => pi.Name));
        }

        private void CreateFile()
        {
            using (StreamWriter writer = new StreamWriter(_fileName))
            {
                _fileLines.ForEach(writer.WriteLine);
            }
        }
    }
}
