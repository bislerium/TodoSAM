namespace TodoSAM.Persistence
{
    internal static class GlobalUpdateState
    {
        private static readonly object updateLock = new();

        private static bool isUpdateNeeded;
        public static bool IsUpdateNeeded
        {
            get
            {
                lock (updateLock)
                {
                    return isUpdateNeeded;
                }
            }
            private set
            {
                lock (updateLock)
                {
                    isUpdateNeeded = value;
                }
            }
        }

        public static void ToggleUpdateNeeded()
        {
            lock (updateLock)
            {
                IsUpdateNeeded = !IsUpdateNeeded;
            }
        }
    }
}
