using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.TeamFoundation.Build.Client;
using TfsBuildRecorder.BusinessLogic;
using TfsBuildRecorder.Entities;
using TfsBuildRecorder.Helpers;

namespace TfsBuildRecorder
{
    class BuildRecorder
    {
        public IFileManager FileManager = new CsvFileManager();
        private readonly ILogManager _logger = new TextFileLogManager();

        private ILogManager Logger
        {
            get { return _logger; }
        }

        public void Start()
        {
            try
            {
                FileManager.ArchiveFile();
                var buildInfoMgr = new BuildInformationManager();

                //returns all existing info or null if file does not exist.
                List<TfsBuildDetail> existingInfo = FileManager.ReadExistingBuildData();

                var buildInfo = new BuildInformation();
                Logger.WriteLog("Getting build definitions for last 28 days");
                buildInfoMgr.SetKeyBuildInfo(buildInfo);

                Logger.WriteLog("Merging Build Information");
                var mergedBuildInfo = CreateMergedBuildInfo(existingInfo, buildInfo.KeyBuildList).ToArray();

                Logger.WriteLog("Writing build information to file.");
                FileManager.WriteBuildInformation(mergedBuildInfo);

                Logger.WriteLog("Process Complete." + Environment.NewLine + "------------------------");
            }
            catch (Exception ex)
            {
                Logger.WriteError(ex);
            }
        }

        private static IEnumerable<TfsBuildDetail> CreateMergedBuildInfo(List<TfsBuildDetail> existingInfo, List<TfsBuildDetail> keyBuildList)
        {
            var newEntries = new List<TfsBuildDetail>();

            //existing info would be null firstTime round
            if (existingInfo == null)
            {
                existingInfo = new List<TfsBuildDetail>();
            }

            var orderedBuilds = keyBuildList.OrderByDescending(x => x.FinishTime);
            foreach (var buildDetail in orderedBuilds)
            {
                if (buildDetail.Status != BuildStatus.InProgress)
                {
                    if (existingInfo.FirstOrDefault(x =>
                                x.DefinitionName.Equals(buildDetail.DefinitionName)
                                && x.FinishTimeAsString.Equals(buildDetail.FinishTime.ToString("ddMMMyyyyhhmm"))) == null)
                    {
                        newEntries.Add(buildDetail);
                    }
                }
            }

            return existingInfo.Concat(newEntries);
        }
    }
}