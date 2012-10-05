using Glimpse.Core.Plugin.Assist;
using log4net.Core;

namespace DCCreative.DNOA4Glimpse {
    public static class DCRowExtensions {
        public static TabRow SetErrorLevel(this TabRow tabRow, LoggingEvent loggingEvent) {
            switch (loggingEvent.Level.DisplayName) {
                case "DEBUG":
                    tabRow.Ms();
                    break;
                case "WARNING":
                    tabRow.Warn();
                    break;
                case "ERROR":
                    tabRow.Error();
                    break;
                case "FATAL":
                    tabRow.Fail();
                    break;
                case "INFO":
                    tabRow.Info();
                    break;
                default:
                    tabRow.Quiet();
                    break;
            }
            return tabRow;
        }
    }
}