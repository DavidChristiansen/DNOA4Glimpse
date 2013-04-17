Glimpse for DotNetOpenAuth
https://github.com/DavidChristiansen/DNOA4Glimpse

Thank you so much for using this DotNetOpenAuth plugin for Glimpse.

#Using it
------------------------------------------------------------------------------------------------------------------------------------------
To use DotNetOpenAuth for Glimpse, all you need to do is:

1. Add a config section declaration into your web.config

    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler" requirePermission="false" />

2. Ensure you have configured log4net to log DotNetOpenAuth events to a MemoryAppender instance. Here is an example

  <log4net>
    <appender name="RollingFileAppender" type="log4net.Appender.RollingFileAppender">
      <file value="teststub.log" />
      <appendToFile value="true" />
      <rollingStyle value="Size" />
      <maxSizeRollBackups value="10" />
      <maximumFileSize value="100KB" />
      <staticLogFileName value="true" />
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date (GMT%date{%z}) [%thread] %-5level %logger - %message%newline" />
      </layout>
    </appender>
    <appender name="MemoryAppender" type="log4net.Appender.MemoryAppender">
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date (GMT%date{%z}) [%thread] %-5level %logger - %message%newline" />
      </layout>
    </appender>
    <root>
      <level value="ALL" />
      <appender-ref ref="RollingFileAppender" />
    </root>
    <logger name="DotNetOpenAuth">
      <level value="ALL" />
      <appender-ref ref="MemoryAppender" />
      <appender-ref ref="RollingFileAppender" />
    </logger>
  </log4net>

3. Be sure to initialise log4net when your application starts.

    log4net.Config.XmlConfigurator.Configure();


Help?
------------------------------------------------------------------------------------------------------------------------------------------

Refer to the two test stubs I have created in the source.

Release Notes
------------------------------------------------------------------------------------------------------------------------------------------

14/04/2013 - 1.3.0
- Update to Glimpse 1.3.0

05/07/2011 - 0.9.0.0
- Initial version
