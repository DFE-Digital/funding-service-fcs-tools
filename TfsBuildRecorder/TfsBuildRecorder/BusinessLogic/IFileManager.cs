using System.Collections.Generic;
using TfsBuildRecorder.Entities;

namespace TfsBuildRecorder.BusinessLogic
{
    public interface IFileManager
    {
        List<TfsBuildDetail> ReadExistingBuildData();

        void WriteBuildInformation(IEnumerable<TfsBuildDetail> buildInfo);

        void WriteEndDates(List<string> endDates);
        void ArchiveFile();
    }
}
