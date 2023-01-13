Feature: WelcomeScreenFeature

@SplitServer
@SingleServer
@WelcomeScreeen
@RegressionPass1
Scenario: Login scenario for invalid credentials
	Given I opened EDCENTRA url
	When I entered wrong 'testuser_1' and '' and clicked login button
	Then A message stating 'Invalid login details entered' should be displayed on the Welcome screen
	When  I entered wrong 'administrator' and 'test123' and clicked login button
	Then A message stating 'Invalid login details entered' should be displayed on the Welcome screen
	When I entered wrong 'testuser_1' and 'test123' and clicked login button
	Then A message stating 'Invalid login details entered' should be displayed on the Welcome screen
	When I entered wrong 'administrator' and 'toolkit' and clicked login button
	Then I should be navigated to home page.

@SplitServer
@SingleServer
@WelcomeScreeen
@RegressionPass1
Scenario: Welcome Screen - Displays
	When I Launched browser and visited the URL [SERVER IP]/EdwardsScada
	Then The EdCentra Welcome Screen should be displayed

@SplitServer
@SingleServer
@WelcomeScreeen
@RegressionPass1
Scenario: Welcome Screen - Help Displays
	Given I opened EDCENTRA url
	When On the welcome screen, click on [Help]
	Then The help screen should be displayed.

@SplitServer
@SingleServer
@WelcomeScreeen
@RegressionPass1
Scenario:Welcome Screen - License Agreement Displays
	Given I opened EDCENTRA url
	When On the welcome screen, clicked on license agreement
	Then The license agreement screen should be displayed.

@SplitServer
@SingleServer
@WelcomeScreeen
@RegressionPass1
Scenario:  Home Screen - About Displays
	Given I opened EDCENTRA url
	When On the welcome screen, click on [About]
	Then The about screen should be displayed.

@SplitServer
@SingleServer
@WelcomeScreeen
@RegressionPass1
Scenario: Welcome Screen - Reset Password
	Given I opened EDCENTRA url
	When I entered wrong 'administrator' and 'test' and clicked login button
	Then A message stating 'Invalid login details entered' should be displayed on the Welcome screen
	When clicked forget password link
	Then Forgotten Password pop up should open
	When Entered an invalid Memorable Answer 'Test123' and click [Apply]
	Then The message 'Failed to reset password, check your memorable answer' should be displayed.
	When Entered a valid Memorable Answer 'Atlas Copco' and click [Apply] 
	Then message 'Password has been set to password123. Please change this as soon as possible' should be displayed.
	When Clicked [Ok]
	Then The Welcome Screen should be displayed.

	#Ensure that the administrator password has been reset via the test 'Welcome Screen - Reset Password'.
@SplitServer
@SingleServer
@WelcomeScreeen
@RegressionPass1
 Scenario: Welcome Screen - Revert Administrator Password
	Given I opened EDCENTRA url
	When I entered wrong 'administrator' and 'test' and clicked login button
	And clicked forget password link
	And Entered a valid Memorable Answer 'Atlas Copco' and click [Apply] 
	Then message 'Password has been set to password123. Please change this as soon as possible' should be displayed.
	When Clicked [Ok]
	And Login with updated password 'administrator' and 'password123'.
	And Opened the User Manager application
	And In User Manager application click on Current User tab.
	Then User details displayed with details 'administrator', 'Admin', 'user@domain.com'.
	When I click Change Password Link.
	Then The 'Change password' dialog should be displayed.
	When entered current password 'pwd123', new password 'toolkit', confirm new password 'toolkit' fields and clicked Apply button.
	Then the message 'Failed to update, check your password' will display.
	When entered current password 'password123', new password 'toolkit1', confirm new password 'toolkit' fields and clicked Apply button.
    Then 'Passwords do not match' will display.
	When entered current password 'password123', new password 'toolkit', confirm new password 'toolkit' fields and clicked Apply button.
	Then the message 'Your Password was changed successfully' should display.
	When logged out.
	And Login with updated password 'administrator' and 'toolkit'.
	Then Logon successful.