Feature: 1GetStarted

@SplitServer
@SingleServer
@RegressionPass1
Scenario: Initial Tests - Logon
Given opened EDCENTRA app 
When entered username as 'administrator' and password as 'toolkit' 
Then should be navigated to home page.
When Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link.
And added new User with details 'testuser' 'Test@123' 'Test@123' '' '' 'test' 'user' and 'testuser@atlascopco.com' in Create user form.
And I logged out.
Then Login screen should be displayed
When entered username as 'testuser1' and password as 'test@123' 
Then The message 'Invalid login details entered' should be displayed
When entered username as 'testuser' and password as 'Test@123' 
And If the memorable question and answer screen is shown, entered the details 'What is the name of this company?' 'Edwards' 'Test@123' and continued
Then Your details should be stored and you should continue through the login process and should login in. 
And After successfull log-in, currently logged in user will be displayed on bottom right corner of the screen 'testuser'
When Hover over user name
Then A Logout link should be displayed on hover menu.
When clicked over it
Then it results in logging out for the current user.

@SplitServer
@SingleServer
@RegressionPass1
Scenario: Initial Tests - Password Recovery
Given opened EDCENTRA app 
When entered username as 'administrator' and password as 'toolkit' 
Then should be navigated to home page.
When Opened the User Manager application, and click on the ‘Maintain Users’ tab.Click on Create User link.
And added new User with details 'testuser' 'Test@123' 'Test@123' 'What is the name of this company?' 'Edwards' 'test' 'user' and 'testuser@atlascopco.com' in Create user form.
And I logged out.
Then Login screen should be displayed
When Login to Ed Centra with a correct user 'testuser', But Incorrect password	'toolkit1'
Then Red message denying access will display 'Invalid login details entered' and Forgotten Passwork Link
When Click on the Forgotten Password Link Request for memorable password
And Answer the users memorable question 'Edwards' 
Then This should then reset your password.(The message displayed is 'Password has been set to password123. Please change this as soon as possible')
When Retry to login with the reset password 'password123'. 
Then Login possible WITH CORRECT DETAILS

@SplitServer
@SingleServer
@RegressionPass1
Scenario: Initial Tests - Application Selection Screen
Given opened EDCENTRA app 
When entered username as 'administrator' and password as 'toolkit'  
Then should be navigated to home page.
And It should show a list of Applications along with the options at the foot of the screen : About,Options, Logged in User Name(Log Off should display as Hover menu on Logged in User)
When Go to Configure ->User Manager->Current User tab
Then A window should show containing information about the current user 'FabWorks','Admin', 'user@domain.com'
When If logged in as administrator and clicked on Options
Then The current gambit of General Options should be displayed
When Selected Any single application.
Then The Selected application screen should display and other select applications should display at top of the page as horizontal list. 
And The user should able to switch between certain other applications without going to the Home screen of the EdCentra.
When Repeated the App selection for different applications	
Then Each selected application should display
When mouse hover on the Logged-in Username displayed at the bottom-right cornor of the page.
And I logged out.
Then Login screen should be displayed
When entered username as 'administrator' and password as 'toolkit'  
Then The App Select screen(Home Screen) should be shown again

@SplitServer
@SingleServer
@GetStarted
Scenario: Application Activation
Given opened EDCENTRA app 
When entered username as 'administrator' and password as 'toolkit' 
Then should be navigated to home page.
When I launch the Code Generator and activate license for all required modules
When Selected 'Historian' application and activate the license
And entered username as 'administrator' and password as 'toolkit' 
And Navigated to 'Historian' page 
Then Historian fields should be displayed
When Selected 'Reports' application and activate the license
And entered username as 'administrator' and password as 'toolkit' 
When Navigated to 'Reports' page
Then Reports fields should be displayed
And I should be able to see all reports under Report page
And should be navigated to home page.
When Selected 'PTM' application and activate the license
And entered username as 'administrator' and password as 'toolkit' 
And Navigated to 'PTM' page 
#Then PTM fields should be displayed
When I clicked on Home Icon in top navigation menubar
When Selected 'Predictive Maintenance' application and activate the license
And entered username as 'administrator' and password as 'toolkit' 
And Navigated to 'Predictive Maintenance' page
When I clicked on Home Icon in top navigation menubar
When Selected 'Fingerprint' application and activate the license
And entered username as 'administrator' and password as 'toolkit' 
And Navigated to 'Fingerprint' page
When I clicked on Home Icon in top navigation menubar
When Selected 'SECS/GEM Agent (Host)' application and activate the license
And entered username as 'administrator' and password as 'toolkit' 
When Selected 'SECS/GEM Service (Equipment)' application and activate the license
And entered username as 'administrator' and password as 'toolkit' 
Then I should be navigated to Home page

@SplitServer
@SingleServer
@RegressionPass1
Scenario: Initial Tests - Activation
Given opened EDCENTRA app 
And Review the Activation Days Remaining information displayed on top of the page.
When If an INSTALL, then choose 'EdCentraWebSite' from the App to license drop down list and Activate EdCentra to have '50' devices.
Then 'EdCentra has been sucessfully activated. Please log in.' message should display.

@SplitServer
@SingleServer
@AcceptSoftwareLicense
Scenario: Accept Software License and Support agreement
Given opened EDCENTRA app 
When Selected Accept the agreement chcekbox and click Ok button
Then user should be navigated to Login page
When entered username as 'administrator' and password as 'toolkit'  
And I entered Memorable question 'What is Client Name?', Memorable answer 'Atlas Copco' and Reentered password 'toolkit'.
When I clicked Apply button.
Then  Successful message 'Your Memorable Question has been updated' should appear on screen.




