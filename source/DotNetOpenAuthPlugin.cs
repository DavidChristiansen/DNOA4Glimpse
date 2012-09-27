using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glimpse.Core.Extensibility;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace DCCreative.DNOA4Glimpse {
	[GlimpsePlugin]
	public class DotNetOpenAuthPlugin : IGlimpsePlugin, IProvideGlimpseHelp {
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
		public object GetData(HttpContextBase context) {
			// Validate parameters
			if (context == null)
				return null;

			if (MemoryAppender == null)
				return null;


			var events = MemoryAppender.GetEvents().Where(x => x.LoggerName.ToLower().Contains("dotnetopenauth"));
			if (!events.Any())
				return null;

			var data = new List<object[]>
			           	{
			           		new object[]
			           			{
			           				"TimeStamp",
			           				"Level",
			           				"LoggerName",
			           				"Message",
			           				"Exception"
			           			}
			           	};

			// Create the data rows
			data.AddRange(events.Select(
				entry => new object[]
				         	{
				         		entry.TimeStamp,
				         		entry.Level.DisplayName,
				         		entry.LoggerName,
				         		entry.RenderedMessage,
				         		entry.ExceptionObject!=null ? entry.ExceptionObject.Message : null
				         	}));

			return data;
		}

		public void SetupInit() {

		}

		public string Name {
			get { return "DotNetOpenAuth"; }
		}

		public string HelpUrl {
			get { return "http://www.dotnetopenauth.net/Help/Plugin/Glimpse"; }
		}
	}
}
