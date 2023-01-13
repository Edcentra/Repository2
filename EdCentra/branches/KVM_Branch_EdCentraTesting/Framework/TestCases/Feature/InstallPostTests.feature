Feature: InstallPostTests

@SingleServer
@ApplicationServer
Scenario: Installer - Installed Components in Single and Application Server
When I open the Programs and Features in the Control Panel
Then I see the components '<Components>' installed in the system
| Components                                          |
#  Microsoft .NET Framework 4 { Client Profile & Extended } | - - x86 9.0.30729.6161 - - 10.0.40219 |
| Microsoft .NET Framework 4.5.1 Multi-Targeting Pack |
| Microsoft ASP.NET 2.0 AJAX Extensions 1.0           |
| Microsoft SQL Server 2016                           |
| Microsoft SOAP Toolkit 2.0 SP2                      |
| Microsoft Visual C++ 2008 Redistributable           |
| Microsoft Visual C++ 2010  x86 Redistributable      |
| Microsoft XML Parser and SDK                        |
| System.Data.SQLite                                  |

@DatabaseServer
Scenario: Installer - Installed Components in Database Server
When I open the Programs and Features in the Control Panel
Then I see the components '<Components>' installed in the system
| Components                                          |
| Microsoft .NET Framework 4.5.1 Multi-Targeting Pack |
| Microsoft SQL Server 2016                           |
| Microsoft Visual C++ 2008 Redistributable           |
| Microsoft Visual C++ 2010  x86 Redistributable      |
| System.Data.SQLite                                  |



@SingleServer
@ApplicationServer
Scenario: Installer - Active Edwards Scada Services
Then I see the following services installed in the system
	| ServiceName                             |
	| Edwards Scada Agent Framework           |
	| Edwards Scada Agent Framework WatchDog  |
	| Edwards Scada Agent Manager             |
	| Edwards Scada Application Logging       |
	| Edwards Scada Autopager                 |
	| Edwards Scada Current State Provisioner |
	| Edwards Scada Data Extraction           |
	| Edwards Scada Data Logger               |
	| Edwards Scada Data Provisioner          |
	| EdwardsScadaIssueManager                |
	| Edwards Scada Multi Lingual Pooler      |
	| Edwards Scada NetworkBridge             |
	| Edwards Scada PlugIn Tunneller          |
	| Edwards Scada Predictive Diagnostics    |
	| Edwards Scada Protection                |
	| Edwards Scada SECS GEM                  |
	| Edwards Scada Session Manager           |
	| Edwards Scada Software Generated Events |
	| Edwards Scada System HealthMonitor      |
	| Edwards Scada Task Scheduler            |
	| Edwards Scada XML Repository            |

@DatabaseServer
Scenario: Installer - Active Edwards Scada Services for Database Server
Then I see the following services installed in the system
	| ServiceName                        |
	| Edwards Scada Application Logging  |
	| Edwards Scada Data Extraction      |
	| Edwards Scada Multi Lingual Pooler |
	| Edwards Scada System HealthMonitor |

@SingleServer
@ApplicationServer
Scenario: Installer - Windows Firewall
Then I check whether Symantec is installed in the system
When I open Windows Firewall Advnace Settings and click on the Inbound Rules tree node
Then I see exceptions starting with Edwards
| InboundRuleExceptions                       |
| Edwards WebAgentUDP                         |
| Edwards Agent HMI Frame                     |
| Edwards Agent Service                       |
| Edwards Agent_Framework_Heartbeat           |
| Edwards AgentFrameworkTCP                   |
| Edwards AgentFrameworkTCP # 2               |
| Edwards AgentFrameworkTCP # 3               |
| Edwards AgentFrameworkTCP # 4               |
| Edwards AgentFrameworkTCP # 5               |
| Edwards AgentFrameworkWCF                   |
| Edwards Application Logging                 |
| Edwards AutoPagerTCP                        |
| Edwards DataExtractionTCP                   |
| Edwards DataProvisionerTCP                  |
| Edwards DCOM_TCP135                         |
| Edwards EADS CallbackTCP                    |
| Edwards EADS Coordinator CallbackTCP        |
| Edwards EADS Coordinator Event ConsumerTCP  |
| Edwards EADS Coordinator Trace Ts StoreTCP  |
| Edwards EADS ModelBuilder Event ConsumerTCP |
| Edwards EADS Processing Node Ts StoreTCP    |
| Edwards EADS UI WebApiTCP                   |
| Edwards EtherNIMAgentTCP                    |
| Edwards EtherNIMAgentUDP                    |
| Edwards Fleet Management Agent MQTT         |
| Edwards Fleet Management HTTP               |
| Edwards Fleet Management RSYNC              |
| Edwards Fleet Management Server MQTT        |
| Edwards GEMSECSIIDefaultPort                |
| Edwards GEMSECSIITCP                        |
| Edwards IGateWayAgentUDP                    |
| Edwards IGateWayAgentUDP                    |
| Edwards Model Builder WCF Endpoint          |
| Edwards Model Builder WCF Endpoint          |
| Edwards MultilingualPoolerTCP               |
| Edwards Network Bridge Service              |
| Edwards NetworkBridgeTCP                    |
| Edwards PluginTunnellerTCP                  |
| Edwards PredictiveDiagnosticsSGETCP         |
| Edwards ProtectionRemotingTCP               |
| Edwards RSSTCP                              |
| Edwards SessionPoolerTCP                    |
| Edwards SEV Provisioner                     |
| Edwards SHM_Console_Service_Heartbeat       |
| Edwards SHM_Heartbeats                      |
| Edwards SystemHealthMonitor ConsoleWindow   |
| Edwards WebAgentUDP                         |  

@SingleServer
@ApplicationServer
Scenario: Installer - Check IIS
Given I launch the Server Manager app
When I click on Add roles and Features and click on next until get to Server Roles
And I expand Web Server (IIS) -> Web Server -> Application Development
Then 'ASP.NET 4.6' and 'ISAPI Filters' should be installed
When I click on cancel button on the wizard
And I click on Tools menu and open 'Internet Information Services (IIS) Manager'
And I expand Default Sites
Then I should see the following two virtual directories
	| Directories        |
	| EdwardsScada       |
	| LoggingCoordinator |
When I navigate to 'http://localhost/' in the browser
Then Edcentra login screen should appear


Scenario: Agent Framework needs longer service start delay
When On the agent PC, open eventvwr.msc
Then Event Viewer opens
When Go to the Scada event log, and check for the entries labled Agent Framework
Then Agent Framework event log should state "Agent Framework deferred start for '60' seconds."


@SingleServer
@ApplicationServer
Scenario: Installer - Firewall Rules may not be in correct Place
When I open Allow an app or feature through Windows Firewall
Then I should see list of Edwards labelled rules with Public and Private checked
| AllowedAps                                  |
| Edwards WebAgentUDP                         |
| Edwards Agent HMI Frame                     |
| Edwards Agent Service                       |
| Edwards Agent_Framework_Heartbeat           |
| Edwards AgentFrameworkTCP                   |
| Edwards AgentFrameworkTCP # 2               |
| Edwards AgentFrameworkTCP # 3               |
| Edwards AgentFrameworkTCP # 4               |
| Edwards AgentFrameworkTCP # 5               |
| Edwards AgentFrameworkWCF                   |
| Edwards Application Logging                 |
| Edwards AutoPagerTCP                        |
| Edwards DataExtractionTCP                   |
| Edwards DataProvisionerTCP                  |
| Edwards DCOM_TCP135                         |
| Edwards EADS CallbackTCP                    |
| Edwards EADS Coordinator CallbackTCP        |
| Edwards EADS Coordinator Event ConsumerTCP  |
| Edwards EADS Coordinator Trace Ts StoreTCP  |
| Edwards EADS ModelBuilder Event ConsumerTCP |
| Edwards EADS Processing Node Ts StoreTCP    |
| Edwards EADS UI WebApiTCP                   |
| Edwards EtherNIMAgentTCP                    |
| Edwards EtherNIMAgentUDP                    |
| Edwards Fleet Management Agent MQTT         |
| Edwards Fleet Management HTTP               |
| Edwards Fleet Management RSYNC              |
| Edwards Fleet Management Server MQTT        |
| Edwards GEMSECSIIDefaultPort                |
| Edwards GEMSECSIITCP                        |
| Edwards IGateWayAgentUDP                    |
| Edwards IGateWayAgentUDP                    |
| Edwards Model Builder WCF Endpoint          |
| Edwards Model Builder WCF Endpoint          |
| Edwards MultilingualPoolerTCP               |
| Edwards Network Bridge Service              |
| Edwards NetworkBridgeTCP                    |
| Edwards PluginTunnellerTCP                  |
| Edwards PredictiveDiagnosticsSGETCP         |
| Edwards ProtectionRemotingTCP               |
| Edwards RSSTCP                              |
| Edwards SessionPoolerTCP                    |
| Edwards SEV Provisioner                     |
| Edwards SHM_Console_Service_Heartbeat       |
| Edwards SHM_Heartbeats                      |
| Edwards SystemHealthMonitor ConsoleWindow   |
| Edwards WebAgentUDP                         |  
| Edwards WebAgentUDP                         |

Scenario: Installer - Check Database
When Check D:\Edwards\Scada\Database - { Installation | Upgrade }x.y\schema.manifest.log for errors.
Then There should be no substantive errors.
When Run SQL Management Studio and try to access the scada_Production database using Windows Authentication
Then This should fail.
When Still using SQL Management Studio, log on using SQL Authentication and the fsu_user and sa accounts.
And Ensure that 'Databases' have 'scada_Production' under the list
When Ensure that 'ReportServer$FABWORKS' and 'ReportServer$FABWORKSTempDB' also exist.
And Ensure that table 'dbo.fst_INS_Parameters' exists in the master database.
When Check that with names like ‘fsj_’ exist under SQL Server Agent\Jobs.
|                 AgentJobs                |
| fsj_ALE_ParameterAlertMappingMaintenance |
| fsj_ARC_Import                           |
| fsj_Data_Logging                         |
| fsj_DBA_AlignAlert                       |
| fsj_DBA_KillLeadBlockerProcesses         |
| fsj_DBA_TableRowCountSnapshot            |
| fsj_GEN_CalculateAvailabilityByDate      |
| fsj_GEN_CalculateConsumptionByDate       |
| fsj_GEN_GenerateSystemSerialNumber       |
| fsj_GEN_ParentGroupDailyTotalsCatchup    |
| fsj_GEN_ParentGroupDailyTotalsTrigger    |
| fsj_GEN_UptimeDataCount                  |
| fsj_MAIN_DailyDBMaintenance              |
| fsj_MAIN_WeeklyDataMaintenance           |
| fsj_MAIN_WeeklyDBMaintenance             |
| fsj_REP_ConsumptionDataBackLoad          |
When Check server by right-clicking the server name and select Properties
And Check database by right-clicking scada_Production and select Properties
Then The collations should match.
When Check file system security permissions
Then MSSQL$FABWORKS has full access to the files
When check file If they exists
Then check file system security permissions

Scenario: Ensure RELEASE assemblies are deployed
When Copy ScanAssemblyBuildType.exe to D drive.
Then pen a command window and ensure that the present working directory is D
When Run ScanAssemblyBuildType.exe and await the results.
Then There to be '0' matches, once those marked as exceptions have been accounted for.
