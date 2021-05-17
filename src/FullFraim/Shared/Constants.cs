namespace Shared
{
    public static class Constants
    {
        public static class UserSeed
        {
        }

        public static class RolesSeed
        {
            public const string Admin = "Admin";
            public const string Organizer = "Organizer";
            public const string Jury = "Jury";
            public const string Participant = "Participant";
            public const string PhotoMaster = "PhotoMaster";
        }

        public static class PhasesSeed
        {
            public const string PhaseI = "PhaseI";
            public const string PhaseII = "PhaseII";
            public const string Finished = "Finished";
        }

        public static class ConstestCategorySeed
        {
            public const string Abstract = "Abstract";
            public const string Architecture = "Architecture";
            public const string Conceptual = "Conceptual";
            public const string Fashion_Beauty = "Fashion/Beauty";
            public const string Fine_Art = "Fine Art";
            public const string Landscapes = "Landscapes";
            public const string Nature = "Natrue";
            public const string Nude = "Nude";
            public const string Photojournalism = "Photojournalism";
            public const string Portrait = "Portrait";
            public const string Street = "Street";
            public const string Wildlife = "Wildlife";
        }

        public static class ContestTypeSeed
        {
            public const string Open = "Open";
            public const string Invitational = "Invitational";
        }

        //Exception constants
        public class Exceptions
        {
            public const string ArgumentNull_Content = "BadRequest";
            public const string Server500_Content = "Something went wrong";
        }
    }
}
