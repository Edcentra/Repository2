Feature: InstallEdcentra
	
@Install
Scenario: Install Edcentra application
	Given Go to Installer folder and Launch Edwards.Installer.Launcher.exe file
	When Scroll down to accept the software license and support agreement and click on “I Accept”.
	And Select all three servers option like Agent PC, Application and Database server and Click on Install 

@ConfigureAgent
@SingleServer
Scenario: Configure Agents
	When Run Agent Configuration (shortcut on desktop)
	When Set pin value '9110'
	And added 'Turbo' 'Web' 'Modbus' agents 
	And Selected PC Interface Network Id card under Relay tab

#@Remote
#Scenario: Remote Connection
#Given connected to remote agent

@CleanVM
Scenario: Restore VM
Given Go to VM url
When Logged in by username 'root' and password 'root@123'
Then I should be navigated to VMWare ESXi page
When I selected Slave VM
And Selected Manage Snapshot option under Snapshots
Then Manage snapshots pop up should be opened 'Manage snapshots - SSISINAS172'
When Selected Restore VM
And clicked Restore snapshot
And clicked Restore button
And clicked close button
Then after few minutes VM should restore 


@RunScenariosUnderConsole
Scenario: Run Scenarios under console
Given Go to VM url
When Logged in by username 'root' and password 'root@123'
Then I should be navigated to VMWare ESXi page
When I selected VM Shalu Automation VM
And Open browser Console

@ConfigurationHandlerSetUp
@SplitServer
@SingleServer
Scenario: Open up SQL Manager / Log In and go to scada_production and add the number 17 to the row ApplicationID
Given Find the table fst_SEC_InstalledApplication and choose edit. Add the number to the row ApplicationID, save and close table.

@DataBaseInstall
Scenario: Install Edcentra application In Database Server
Given Go to Installer folder and Launch Edwards.Installer.Launcher.exe file
When Scroll down to accept the software license and support agreement and click on “I Accept”.
And Select servers option Database server and give Application ServerName 'ShaluVM2' Click on Install

@AgentInstall
Scenario: Install Edcentra application In Agent Server
Given Go to Installer folder and Launch Edwards.Installer.Launcher.exe file
When Scroll down to accept the software license and support agreement and click on “I Accept”.
And Select servers option Database server and give Application serverName 'ShaluVM2' and Database serverName 'EDC2' Click on Install

@ApplicationInstall
Scenario: Install Edcentra application In Application Server
Given Go to Installer folder and Launch Edwards.Installer.Launcher.exe file
When Scroll down to accept the software license and support agreement and click on “I Accept”.
And Select servers option Database server and give Database serverName 'EDC2' Click on Install

@CleanSplitServers
Scenario Outline: Restore Servers
Given Go to VM url
When Logged in by username 'root' and password 'root@123'
Then I should be navigated to VMWare ESXi page
When I select VMNames '<vmName>' '<snapShotName>' '<vmName1>' '<snapShotName1>' '<vmName2>' '<snapShotName2>' and restore the VM's

Examples: 
| vmName     | snapShotName      |   vmName1  |    snapShotName1      | vmName2    |      snapShotName2          |
| Edc2_Simbu | CleanUp Server DB | Edc3_Simbu |  CleanUp Server Agent | ShaluVM2   |  CleanUp Server Application |

@SplitServer
@ConfigureAgentSplit
Scenario: Configure Agents on split server
When Run Agent Configuration (shortcut on desktop)
And I click server 'S14' 'S16' lookup IP
When Set pin value '9110'
And added 'Turbo' 'Web' 'Modbus' agents
And Selected PC Interface Network Id card under Relay tab

