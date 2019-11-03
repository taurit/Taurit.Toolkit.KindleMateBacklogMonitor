namespace Taurit.Toolkit.KindleMateBacklogMonitor
{
    internal class Stats
    {
        public Stats(in int numClippingsLeftToProcess)
        {
            NumClippingsLeftToProcess = numClippingsLeftToProcess;
        }

        public int NumClippingsLeftToProcess { get; }
    }
}