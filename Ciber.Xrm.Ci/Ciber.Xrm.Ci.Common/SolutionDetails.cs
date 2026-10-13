namespace Ciber.Xrm.Ci.Common
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class SolutionDetails
    {
        public string SolutionFile { get; private set; }

        public string SolutionName
        {
            get
            {
                var xelement = SolutionNode.Descendants("UniqueName").First();
                if (xelement == null)
                {
                    throw new InvalidOperationException("UniqueName element not found");
                }

                return xelement.Value;
            }
        }

        public string SolutionVersion
        {
            get
            {
                var xelement = SolutionNode.Descendants("Version").First();
                if (xelement == null)
                {
                    throw new InvalidOperationException("Version element not found");
                }

                return xelement.Value;
            }
            set
            {
                Contract.Requires(value != null);

                var xelement = SolutionNode.Descendants("Version").First();
                if (xelement == null)
                    throw new Exception(string.Format("Version element not found"));
                xelement.Value = value;
            }
        }

        private XElement SolutionNode { get; set; }

        private SolutionDetails(string solutionFile)
        {
            SolutionFile = solutionFile;
            Init();
        }

        public static SolutionDetails Create(string solutionFile)
        {
            return new SolutionDetails(solutionFile);
        }

        private void Init()
        {
            if (!File.Exists(SolutionFile))
                throw new Exception(string.Format("{0} does not exist.", SolutionFile));
            SolutionNode = XElement.Load(SolutionFile);
        }

        public void Save()
        {
            Contract.Requires(!string.IsNullOrEmpty(SolutionFile));

            SolutionNode.Save(SolutionFile);
        }
    }
}
