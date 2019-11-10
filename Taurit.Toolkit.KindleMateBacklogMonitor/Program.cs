using System;
using System.IO;
using System.Threading;
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
        private readonly ILogger _logger;
        private readonly StatsReader _statsReader;
        private readonly StatsWriter _statsWriter;

        private Program()
        {
            // poor man's DI
            _statsReader = new StatsReader();
            _statsWriter = new StatsWriter();
            _logger = LoggerFactory.Create(x => x.AddConsole(
                c => { c.TimestampFormat = "[HH:mm:ss] "; }
            )).CreateLogger(nameof(Program));
        }

        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Args>(args).WithParsed(o => { new Program().Run(o); });
        }

        private void Run(Args args)
        {
            while (true) // for now it's designed to run on my Linux vm in an endless loop
            {
                if (args.KindleMateDirectory is null)
                    args.KindleMateDirectory = "/KindleMate"; // expected mount point of a volume within the container
                // otherwise we still might want to allow to pass it as args to allow debugging on Windows (without containers)

                if (!Directory.Exists(args.KindleMateDirectory))
                    throw new FileNotFoundException("Specified database file does not exist", args.KindleMateDirectory);

                var dbFilePath = Path.Combine(args.KindleMateDirectory, "KM2.dat");
                var statsFilePath = Path.Combine(args.KindleMateDirectory, "backlog-stats.csv");

                _logger.Log(LogLevel.Information, "Reading stats from the database...");
                var currentStats = _statsReader.ReadStats(dbFilePath);

                _logger.Log(LogLevel.Information, "Appending stats to an output file...");
                _statsWriter.AppendStats(statsFilePath, currentStats);

                var sleepTime = TimeSpan.FromHours(1);
                _logger.Log(LogLevel.Information, $"Done, now I'm going to sleep for {sleepTime}");
                Thread.Sleep(sleepTime);
            }
        }
    }
}