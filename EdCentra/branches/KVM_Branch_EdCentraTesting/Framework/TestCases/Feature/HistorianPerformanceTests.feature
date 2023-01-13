Feature: HistorianPerformanceTests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario:Calculate loading time
Given I Opened EDCENTRA app url in browser.
When I enter username as 'administrator' and password a*******kit' and clicked login button.
And expanded system 'Combuster', selected 'OlympiaPerf1'
Then calculated 'OlympiaPerf1' paramter list loading time for '3 months'.
And calculated 'OlympiaPerf1' paramter list loading time for '1 week'.
And calculated 'OlympiaPerf1' paramter list loading time for '1 month'.
And calculated 'OlympiaPerf1' paramter list loading time for '1 year'.
And calculated adding parameter 'Combustor Temp (35)' in graph timing for '1 week'.
And calculated adding parameter 'Combustor Temp (35)' in graph timing for '3 months'.
And calculated adding parameter 'Combustor Temp (35)' in graph timing for '1 month'.
And calculated adding parameter 'Combustor Temp (35)' in graph timing for '1 year'.
And saved  data in excel sheet 'PerformanceData.xlsx'
