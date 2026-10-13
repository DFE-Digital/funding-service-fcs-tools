using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;

namespace FeatureFileParser
{
    public class CategoryTag
    {
        public string Fullname { get; set; }
        public int Number { get; set; }
        public string TfsItemDescription { get; set; }
        public string NormalisedFullName { get; set; }
    }

    public class FeatureDiscovery
    {
        private List<CategoryTag> _featureCategories = new List<CategoryTag>();
        private List<CategoryTag> _storyCategories = new List<CategoryTag>();
        private WorkItemStore _workItemStore;
        private FeatureFileManager _featureFileManager;

        public List<CategoryTag> StoryCategories
        {
            get
            {
                return _storyCategories;
            }
        }

        public List<CategoryTag> FeatureCategories
        {
            get
            {
                return _featureCategories;
            }
        }

        public string Path
        {
            get
            {
                return _featureFileManager.Path;
            }
        }

        public FeatureDiscovery(string path, string tfsProjectName, Uri tfsServerUrl, NetworkCredential tfsCredentials)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("path");
            }
            if (string.IsNullOrEmpty(tfsProjectName))
            {
                throw new ArgumentException("tfsProjectName");
            }
            if (tfsServerUrl == null)
            {
                throw new ArgumentNullException("tfsServerUrl");
            }
            if (tfsCredentials == null)
            {
                throw new ArgumentNullException("tfsCredentials");
            }

            Initialise(path, tfsProjectName, tfsServerUrl, tfsCredentials);
        }

        public void UpdateFeatureFiles()
        {
            var replaceList = _featureCategories
                                    .Union(_storyCategories)
                                    .ToDictionary(r => r.Fullname, r => r.NormalisedFullName);

            _featureFileManager.UpdateFeatureFiles(replaceList);

        }

        private void Initialise(string path, string tfsProjectName, Uri tfsServerUrl, NetworkCredential tfsCredentials)
        {
            _workItemStore = TfsHelper.GetTFSProject(tfsServerUrl, tfsCredentials);
            _featureFileManager = new FeatureFileManager(path);
            var featureFiles = _featureFileManager.FeatureFiles;

            CategoryParser parser = CreateCategoryParser(featureFiles);
            parser.Parse();

            FeatureCategories.ForEach(fc => PopulateDescription(tfsProjectName, fc));
            StoryCategories.ForEach(sc => PopulateDescription(tfsProjectName, sc));
        }

        private CategoryParser CreateCategoryParser(List<FileInfo> featureFiles)
        {
            var parser = new CategoryParser(featureFiles);
            // The casing of this are important. Ensure that the first alpha character is Upper Case
            parser.AddCategoryCollector("@Feature", FeatureCategories);
            parser.AddCategoryCollector("@Story", StoryCategories);
            parser.AddCategoryCollector("@Userstory", StoryCategories);
            return parser;
        }

        private CategoryTag PopulateDescription(string tfsProjectName, CategoryTag categoryTag)
        {
            var workItem = TfsHelper.GetItem(tfsProjectName, categoryTag.Number, _workItemStore);
            if (workItem != null)
            {
                categoryTag.TfsItemDescription = workItem.Title;
                categoryTag.NormalisedFullName = ConstructNormalisedFullname(categoryTag);
            }
            return categoryTag;
        }

        private static string ConstructNormalisedFullname(CategoryTag categoryTag)
        {
            // We want to inject a # after the @ and before the first letter to ensure that the 
            // normalised category is not picked up in subsequent runs
            // Also we want to ensure the first letter is a capitial
            var badChars = @"-!,!+".ToCharArray();

            return string.Format("@#{0}_{1}",
                            CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                                categoryTag.Fullname.Substring(1, categoryTag.Fullname.Length - 1)
                                ),
                            new string(categoryTag.TfsItemDescription
                                .Where(c => !badChars.Contains(c)).ToArray())
                                .Replace(' ', '_')
                        );
        }
    }
}
