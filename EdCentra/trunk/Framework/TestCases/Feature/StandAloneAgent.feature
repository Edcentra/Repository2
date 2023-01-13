Feature: StandAloneAgent
	
@Install
Scenario: Install StandAlone Agent Server
Given Go to Installer folder and Launch Standalone Agent Setup.exe file
Then user finds the Run Agent Configuration (shortcut on desktop)
@Install
Scenario: Renaming DLL
When Check C:\Program Files (x86)\Edwards\DataLogger\TsStorePlugins\Edwards.TsStore.Plugin.Cumulocity.dll
Then rename the plugin to Edwards.TsStore.Plugin.Cumulocity
When Check C:\Program Files (x86)\Edwards\DataLogger\TsStorePlugins\TsStorePluginTemplate.dll.DISABLED
Then rename the plugin to TsStorePluginTemplate.dll

@Install
Scenario: Changing the IP in Log
When I open the services in the system
Then I see the following services installed in the system
	| ServiceName                             |
	|Edwards Scada Agent Framework           |
	|Edwards Scada Data Logger				  |
	|Edwards Scada Fleet Management Standalone Agent	  |
	|Edwards Scada XML Repository			  |
When I check whether localstorageEquipment.config file exists 
Then there should be '1.1.1.1' value needs to be displayed in config file
And replace the IP with the current System IP

@Install
Scenario: simulator check
When Launched Eissa on winpro and started simulator
#When Run Agent Configuration
#And Set pin value '9110'
#And added 'Web' agents 
#And Selected PC Interface Network Id card under Relay tab
When Check the specified log file is displayed under the path C:\TS_STORE_TEMPLATE.log
Then there should be 'STARTED' keywords in the log
And there should be 'INITIALISED' keywords in the log

@Install
Scenario: Alert Check
When Launched Eissa on winpro and started simulator
And Raised Alert on parameters '35          (TE406 Combustor Temperature)'
#Then there should be 'ALERT_0|True|1|0|OverTrigger|MajorAlarm|35|1007' keywords in the log
When Cleared Alert from simulator  '35          (TE406 Combustor Temperature)'
#Then there should be 'ALERT_0|False|1|0|OverTrigger|MajorAlarm|35|1007' keywords in the log

