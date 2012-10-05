using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Extensibility;
using Glimpse.Core.Plugin.Assist;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace DCCreative.DNOA4Glimpse {
    public class DotNetOpenAuthPlugin : TabBase<HttpContextBase>, ITab {
        private MemoryAppender _memoryAppender;
        private MemoryAppender MemoryAppender {
            get {
                if (_memoryAppender == null) {
                    Hierarchy h = LogManager.GetRepository() as Hierarchy;
                    var logger = h.GetLogger("DotNetOpenAuth");
                    if (logger == null)
                        return null;
                    var appenders = logger.Repository.GetAppenders().Where(x => x.Name == "MemoryAppender");
                    if (appenders.Any()) {
                        _memoryAppender = appenders.SingleOrDefault() as MemoryAppender;
                    }
                }
                return _memoryAppender;
            }
        }
        public override object GetData(ITabContext context) {
            // Validate parameters
            if (context == null)
                return null;

            if (MemoryAppender == null)
                return null;


            var events = MemoryAppender.GetEvents().Where(x => x.LoggerName.ToLower().Contains("dotnetopenauth"));
            if (!events.Any())
                return null;

            var plugin = Plugin.Create("TimeStamp", "Level", "LoggerName", "Message", "Exception");

            foreach (var loggingEvent in events) {

                TabSection exceptionSection = new TabSection();
                if (loggingEvent.ExceptionObject!=null) {
                    exceptionSection = new TabSection("Message", "StackTrace", "Help");
                    exceptionSection.AddRow()
                        .Column(loggingEvent.ExceptionObject.Source).Quiet()
                        .Column(loggingEvent.ExceptionObject.Message).Strong()
                        .Column(loggingEvent.ExceptionObject.HelpLink).Underline()
                        .Column(loggingEvent.ExceptionObject.StackTrace).Raw();
                }

                plugin.AddRow()
                    .Column(loggingEvent.TimeStamp)
                    .Column(loggingEvent.Level.DisplayName)
                    .Column(loggingEvent.LoggerName).Underline()
                    .Column(loggingEvent.RenderedMessage).Emphasis()
                    .Column(exceptionSection)
                    .SetErrorLevel(loggingEvent);
            }

            return plugin;
        }

        public override string Name {
            get { return "DotNetOpenAuth"; }
        }

        public void Setup(ITabSetupContext context) {

        }

        public string HelpUrl {
            get { return "http://www.dotnetopenauth.net/Help/Plugin/Glimpse"; }
        }
    }
}
