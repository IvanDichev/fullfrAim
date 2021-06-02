using System;

namespace Shared.AllConstants
{
    public static class LogMessages
    {
        /// <summary>
        /// {0} ServiceName, {1} MethodName
        /// </summary>
        public static string NullModel = $"{DateTime.UtcNow} - {0}.{1} received null model for input.";
        
        /// <summary>
        /// {0} ServiceName, {1} MethodName, {2} id, {3} for model
        /// </summary>
        public static string InvalidId = $"{DateTime.UtcNow} - {0}.{1} received invalid id: {2}, for {3}.";

        /// <summary>
        /// {0} ServiceName, {1} MethodName, {2} id
        /// </summary>
        public static string NotFound = $"{DateTime.UtcNow} - {0}.{1} didn't find any mathing elements for id: {2}.";
    }

}
