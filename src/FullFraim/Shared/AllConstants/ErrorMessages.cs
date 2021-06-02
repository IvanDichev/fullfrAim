namespace Shared.AllConstants
{
    public static class ErrorMessages
    {
        /// <summary>
        /// {0} user id, {1} contest id
        /// </summary>
        public static string AlreadyInContest = $"User with id: {0} already in contest with id: {1}!";
        public static string ReviewOutsidePhaseTwo = $"Rewiev option not available outside Phase Two.";
        public static string ReviewAlreadyGiven = $"The photo has already been reviewed.";
    }
}
