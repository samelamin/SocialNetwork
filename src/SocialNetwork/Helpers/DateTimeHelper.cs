using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Helpers
{
    public static class DateTimeHelper
    {
        const int SECOND = 1;

        const int MINUTE = 60 * SECOND;

        const int HOUR = 60 * MINUTE;

        const int DAY = 24 * HOUR;

        const int MONTH = 30 * DAY;

        public static string GetFriendlyRelativeTime(TimeSpan timespan)
        {

            double delta = timespan.TotalSeconds;

            if (delta < 1 * MINUTE)
            {
                return timespan.Seconds == 1 ? "1 second ago" : string.Format("{0} seconds ago", timespan.Seconds);
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
