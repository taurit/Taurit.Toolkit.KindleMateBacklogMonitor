using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Taurit.Toolkit.KindleMateBacklogMonitor
{
    internal class StatsWriter
    {
        private const string StatsFileCsvHeaderLine = "dateUtc;numClippings;numWords\n";

        public void AppendStats(string statsFilePath, [NotNull] Stats stats)
        {
            if (!File.Exists(statsFilePath))
                File.WriteAllText(statsFilePath, StatsFileCsvHeaderLine);

            var line = $"{DateTime.UtcNow:u};{stats.NumClippingsLeftToProcess};{stats.NumWordLeftToLearn}\n";
            File.AppendAllText(statsFilePath, line);
        }
    }
}