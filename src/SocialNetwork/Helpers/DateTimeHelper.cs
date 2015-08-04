namespace SocialNetwork.Helpers
{
    using System;

    public static class DateTimeHelper
    {
        const int SECOND = 1;

        const int MINUTE = 60 * SECOND;

        public static string GetFriendlyRelativeTime(TimeSpan timespan)
        {
            var delta = timespan.TotalSeconds;

            if (delta < 1 * MINUTE)
            {
                return timespan.Seconds == 1 ? "1 second ago" : $"{timespan.Seconds} seconds ago";
            }
            if (delta < 2 * MINUTE)
            {
                return "1 minute ago";
            }
            if (delta < 45 * MINUTE)
            {
                return timespan.Minutes + " minutes ago";
            }
            return string.Empty;
        }
    }
}