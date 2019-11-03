namespace Taurit.Toolkit.KindleMateBacklogMonitor
{
    internal class Stats
    {
        public Stats(in int numClippingsLeftToProcess, int numWordLeftToLearn)
        {
            NumClippingsLeftToProcess = numClippingsLeftToProcess;
            NumWordLeftToLearn = numWordLeftToLearn;
        }

        public int NumClippingsLeftToProcess { get; }
        public int NumWordLeftToLearn { get; }
    }
}