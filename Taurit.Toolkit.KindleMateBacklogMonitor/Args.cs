using System;
using CommandLine;

namespace Taurit.Toolkit.KindleMateBacklogMonitor
{
    public class Args
    {
        [Option('d', "directory", Required = false, HelpText = "Path to a KindleMate app's directory")]
        public String KindleMateDirectory { get; set; }
    }
}