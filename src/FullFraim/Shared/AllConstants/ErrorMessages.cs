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

        public static string NameMustBeUnique = $"Name must be unique.";
        public static string CannotSendBothUrlAndImage = $"Cannot send both url and image file.";
        public static string ContestCoverRequired = $"Contest cover is *Required";
        public static string CannotEnroll = $"You are not allowed to enroll!";
    }
}
