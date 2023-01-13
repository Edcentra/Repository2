Feature: HistorianPerformanceTests


@mytag
Scenario:Calculate loading time
Given I opened EDCENTRA app url 
When I entered 'administrator' and 'toolkit' and clicked login button
When I clicked Device Explorer link
Then I should be navigated to Device Explorer page
When I clicked on add folder/ system icon
And  I Entered folder name and Clicked on Add button
Then I should be able to see Folder Added Successfully message
When I clicked OK button 
Then I should be able to see newly added folder
When I clicked Find Equipment
And deleted all equipments
When Click Historian ->Equipment Data tab
Then Equipment Data tab should be shown
When I Select date range StartDate and mark only Parameter Data check box.Ummark Alerts and Equipment Status.Click Apply
Then Select Device Explorer folder on Systems list
When Expand the folder and Select single Equipment 'OlympiaPerf1' in the tree
Then The Parameter'Combuster' for that equipment'OlympiaPerf1' will be displayed in the parameter's list
#Old Code starts from here
#Given I Opened EDCENTRA app url in browser.
#When I enter username as 'administrator' and password a*******kit' and clicked login button.
When expanded system 'Combuster', selected 'OlympiaPerf1'
Then calculated 'OlympiaPerf1' paramter list loading time for '3 months'.
And calculated 'OlympiaPerf1' paramter list loading time for '1 week'.
And calculated 'OlympiaPerf1' paramter list loading time for '1 month'.
And calculated 'OlympiaPerf1' paramter list loading time for '1 year'.
And calculated adding parameter 'Combustor Temp (35)' in graph timing for '1 week'.
And calculated adding parameter 'Combustor Temp (35)' in graph timing for '3 months'.
And calculated adding parameter 'Combustor Temp (35)' in graph timing for '1 month'.
And calculated adding parameter 'Combustor Temp (35)' in graph timing for '1 year'.
And saved  data in excel sheet 'PerformanceData.xlsx'
