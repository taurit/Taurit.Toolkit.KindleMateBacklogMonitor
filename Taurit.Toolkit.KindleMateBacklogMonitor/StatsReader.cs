using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Taurit.Toolkit.KindleMateBacklogMonitor.Database;

namespace Taurit.Toolkit.KindleMateBacklogMonitor
{
    internal class StatsReader
    {
        public Stats ReadStats(String databasePath)
        {
            var optionsBuilder = new DbContextOptionsBuilder<KindleMateDatabaseContext>();
            optionsBuilder.UseSqlite($"Filename={databasePath}");
            using var context = new KindleMateDatabaseContext(optionsBuilder.Options);
            
            Int32 numClippingsLeftToProcess = context.Clippings.Count();
            Int32 numWordLeftToLearn = context.Vocab.Count(x => x.Category == 0); // category 0 means 'Learning' (not mastered), 100 means mastered

            return new Stats(numClippingsLeftToProcess, numWordLeftToLearn);
        }
    }
}