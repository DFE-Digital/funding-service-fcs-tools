using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FeatureFileParser
{
    public class CategoryParser
    {
        private const string _CATEGORY_PREFIX = "@";
    
        private List<FileInfo> _featureFiles;
        private Dictionary<string, List<CategoryTag>> _categoryMap = new Dictionary<string, List<CategoryTag>>();

        public CategoryParser(List<FileInfo> featureFiles)
        {
            this._featureFiles = featureFiles;
        }

        public void AddCategoryCollector(string categoryName, List<CategoryTag> uniqueCategoryList)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                throw new ArgumentException("categoryName");
            }

            if (uniqueCategoryList == null)
            {
                throw new ArgumentNullException("uniqueCategoryList");
            }

            _categoryMap.Add(categoryName, uniqueCategoryList);

        }

        public void Parse()
        {
            // Split file into line
            // Ignore list that don't start with @
            // Split remaining line using " " as a delimiter
            // Remove whitespace from the remaining item - That should be the @categories
            var lines = GetLinesContainingCategories(_featureFiles);
            var categories = GetUniqueCategoriesFromLines(lines);

            // Capture categories in lists
            CaptureCategoriesInCollectors(categories);

        }

        private void CaptureCategoriesInCollectors(List<string> categories)
        {
            foreach (var k in _categoryMap.Keys)
            {
                _categoryMap[k].AddRange (
                    categories
                        .Where(c => c.StartsWith(k.ToLower()))
                        .Select(cat => CreateCategoryTag(cat))
                        .ToList());
            }
        }

        private List<String> GetUniqueCategoriesFromLines(List<string> lines)
        {
            return lines
                 .Select(l => l.Split(' '))
                 .SelectMany(s => s)
                 .Where(t => t != "")
                 .Select(i => i.Trim().ToLower())
                 .Distinct()
                 .ToList();                      
        }

        private List<String> GetLinesContainingCategories(List<FileInfo> featureFiles)
        {
           return featureFiles
                .Select(fi => File.ReadAllLines(fi.FullName))               
                .SelectMany(s => s)
                .Where(w => w.StartsWith(_CATEGORY_PREFIX))
                .ToList();
        }

        private CategoryTag CreateCategoryTag(string category)
        {
            return new CategoryTag
            {
                Fullname = category,
                Number = ExtractNumberFromString(category)
            };
        }

        private int ExtractNumberFromString(string source)
        {
            var resultString = Regex.Match(source, @"\d+").Value;
            int result = -1;
            int.TryParse(resultString, out result);
            return result;
        }
    }
}