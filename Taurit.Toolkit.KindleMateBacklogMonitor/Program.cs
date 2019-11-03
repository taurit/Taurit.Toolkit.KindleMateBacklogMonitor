using System;
using System.IO;
using CommandLine;
using Microsoft.Extensions.Logging;

namespace Taurit.Toolkit.KindleMateBacklogMonitor
{
    /// <summary>
    ///     Registers number of items in KindleMate backlog every once in a while. This allows to gather some long-term stats
    ///     of productivity.
    /// </summary>
    internal class Program
    {
        private readonly StatsReader _statsReader;
        private readonly ILogger _logger;

        private Program()
        {
            // poor man's DI
            _statsReader = new StatsReader();
            _logger = LoggerFactory.Create(x => x.AddConsole()).CreateLogger(nameof(Program));
        }

        private static void Main(String[] args)
        {
            Parser.Default.ParseArguments<Args>(args).WithParsed(o => { new Program().Run(o); });
        }

        private void Run(Args args)
        {
            if (args.KindleMateDirectory is null)
            {
                args.KindleMateDirectory = "/KindleMate"; // expected mount point of a volume within the container
            } else
            {
                // we still might want to allow to pass it as args to allow debugging on Windows (without containers)
            }

            if (!Directory.Exists(args.KindleMateDirectory))
            {
                throw new FileNotFoundException("Specified database file does not exist", args.KindleMateDirectory);
            }

            var dbFilePath = Path.Combine(args.KindleMateDirectory, "KM2.dat");
            _logger.Log(LogLevel.Information, "Reading stats from the database...");
            Stats currentStats = _statsReader.ReadStats(dbFilePath);
            
            _logger.Log(LogLevel.Information, "Appending stats to an output file...");
            _logger.Log(LogLevel.Information, $"> NumClippingsLeftToProcess = {currentStats.NumClippingsLeftToProcess}"); // just to test, temporary
            // todo

            _logger.Log(LogLevel.Information, "Done :)");
        }
    }
}