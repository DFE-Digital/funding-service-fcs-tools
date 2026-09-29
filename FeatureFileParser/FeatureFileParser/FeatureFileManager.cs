using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FeatureFileParser
{
    internal class FeatureFileManager
    {
        private const string _FEATURE_FILE_SEARCH_PATTERN = "*.feature";

        private string _path;
        private List<FileInfo> _featureFileList;

        public FeatureFileManager(string path)
        {
            Path = path;
        }

        public string Path { get; internal set; }

        public List<FileInfo> FeatureFiles
        {
            get
            {
                if (_featureFileList == null)
                {
                    _featureFileList = new DirectoryInfo(Path)
                            .GetFiles(_FEATURE_FILE_SEARCH_PATTERN, SearchOption.AllDirectories)
                            .ToList<FileInfo>();
                }
                return _featureFileList;
            }
        }

        public void UpdateFeatureFiles(Dictionary<string, string> replace)
        {
            FeatureFiles.ForEach(f =>
            {
                using (var input = File.OpenText(f.FullName))
                using (var output = new StreamWriter(f.FullName + ".tmp"))
                {
                    string line;
                    while (null != (line = input.ReadLine()))
                    {
                        foreach (var r in replace)
                        {
                            if (line == null) break;
                            if (line.ToLower().Contains(r.Key.ToLower()))
                            {
                                line = r.Value;
                            }                    
                        }
                        output.WriteLine(line);
                    }
                }

                File.Delete(f.FullName);
                File.Move(f.FullName + ".tmp", f.FullName);
            });
        }
    }
}
