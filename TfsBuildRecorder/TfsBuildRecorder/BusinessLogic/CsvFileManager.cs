using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.TeamFoundation.Build.Client;
using TfsBuildRecorder.Entities;

namespace TfsBuildRecorder.BusinessLogic
{
    public class CsvFileManager : IFileManager
    {
        public string FileLocation
        {
            get
            {
                return ConfigurationManager.AppSettings["FilePath"] +
                       ConfigurationManager.AppSettings["FileName"] +
                       ConfigurationManager.AppSettings["FileExtension"];
            }
        }

        public string ArchiveFileLocation
        {
            get
            {
                return ConfigurationManager.AppSettings["ArchiveFilePath"] +
                       ConfigurationManager.AppSettings["FileName"] + DateTime.Now.ToString("ddMMyyyyHHmm") +
                       ConfigurationManager.AppSettings["FileExtension"];
            }
        }

        public List<TfsBuildDetail> ReadExistingBuildData()
        {
            var existingBuildInformation = new List<TfsBuildDetail>();

            if (File.Exists(FileLocation))
            {
                var existingLines = File.ReadAllLines(FileLocation);

                int count = 0;
                foreach (var line in existingLines)
                {
                    if (count == 0)
                    {
                        count++;
                    }
                    else
                    {
                        var splitInfo = line.Split(',');
                        try
                        {
                            existingBuildInformation.Add(new TfsBuildDetail
                            {
                                DefinitionName = splitInfo[0],
                                StartTime = !string.IsNullOrEmpty(splitInfo[1]) ? (DateTime?)DateTime.Parse(splitInfo[1]) : null,
                                //FinishTime = DateTime.Parse(splitInfo[2]),
                                FinishTime = DateTime.Parse(splitInfo[2], new CultureInfo("en-GB")),
                                FinishTimeAsString = splitInfo[3],
                                Status = (BuildStatus)Enum.Parse(typeof(BuildStatus), splitInfo[4])
                            });
                        }
                        catch (Exception ex)
                        {
                            var currentLine = line;
                            throw;
                        }
                    }
                }
                var list =
                    existingBuildInformation.Select(
                        x => x.FinishTime.ToString("dd MMM yyyy HH:mm:ss", new CultureInfo("en-US")));
                return existingBuildInformation;
            }

            return null;
        }

        public void WriteBuildInformation(IEnumerable<TfsBuildDetail> buildInfo)
        {
            if (buildInfo != null)
            {
                try
                {
                    var buildInfoPiped = GetPipedBuildInfo(buildInfo);
                    File.WriteAllLines(FileLocation, buildInfoPiped);
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                    throw;
                }
            }
        }

        public void WriteEndDates(List<string> endDates)
        {
            File.WriteAllLines(@"C:\Users\cfaulconbridge\Documents\BuildRecorderFiles\TransformedEndDates.csv", endDates);
        }

        public void ArchiveFile()
        {
            File.Copy(FileLocation, ArchiveFileLocation);
        }

        private string[] GetPipedBuildInfo(IEnumerable<TfsBuildDetail> buildInfo)
        {
            var returnList = new List<string> { "DefinitionName,StartTime,FinishTime,FinishTimeAsString,Status" };
            returnList.AddRange(buildInfo.Select(infoLine => infoLine.ToPipedString()).ToList());

            return returnList.ToArray();
        }
    }
}
