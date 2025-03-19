# Overview
This project demonstrates the integration of the Helpshift SDK in example app, providing functionalities such as user management, showing Conversation and Helpcenter, adding debug logs, breadcrumb tracking, miscellaneous APIs, etc.

# User Management
## User Identification & Management ( Old Login System )
For using old login system, you can enter user details like userId, email, username, auth-token in the input box provided before clicking Login Button.
- Keep input fields empty to skip particular keys
- You can also chose to clear anonymous user on login by checking the `Clear Current Anon User` checkbox and clicking Clear Anon User button befor `Login`

## User Hub ( New Login System )
If you can have opt-in to User Hub, click the `Identity button` to open identity screen

### Login With Identity and Add User Identities
This API expects loginConfig, identitiesJwt and login callback.
Login Config can be passed by adding config key and value using `Add Config` button.
Once you have paste identitiesJwt in the input box click login button to call loginWithIdentity API. 
If you want to login anonymous User with identity press `Login With Anon Identity` button.

Similarly, AddUserIdentities can be called after providing the new identities jwt and hitting the `Add User Identity` button.

### Update master and app attributes
Master/App attribute keys and values can be added in same way using key/value fields.
For adding CUFs, again there is separate CUF key/value fields in particular section.

At the bottom of this page, there is clear data button which clear all the properties.
Please note, all the delegates and login callback events are logged which can be viewed from `Event Logger` button.
Also, all the config that is passed in APIs can be verified from the debug logs which gets logged in console or logcat.

# Helpshift Events
Click on `Event Logger` button which shows all the events received through Helpshift Delegate and Identity login callback.
All the events are stored in in-memory of app session.

# Config for ShowConversation and Show FAQ
There are multiple options to add different config while using ShowConversation and Show FAQs. They are
- Add comma seaparated TAGs
- Enable/Disable full privacy using checkbox
- Select Contact Us option
- Add multiple Cifs
- Add multiple custom config like `initialUserMessage`, etc.
- Add FAQ Section ID or FAQ ID

Please note this config has to be added before calling APIs like Show Conversation and FAQs. This config is stored in-memory and can be confirmed from the debug logs which is shown enableLogging is enabled.

- `Open Chat` button stands for `ShowConversation` API and `Open Helpcenter` button stands for `ShowFAQs`

# Push Token ( Android )
If you have enabled FCM, then Push Token input will display the token received from Firebase.

# Miscellaneous APIS

## Request Unread Message Count
`Unread Message Count` button will call RequestUnreadMessageCount API with shouldFetchFromServer value depend on `From Remote` checkbox

## Debug Logs
You can use HelpshiftLog by selecting the debug level, tag and message from input box and then clicking Add Log Button in Debug Logs section

## Breadcrumbs
For tracking the end-user events, add the Breadcrumb message and click `Leave Breadcrumb` button.
Similarly, `Clear Breadcrumb` will clear all breadcrumbs.

## Plugin Version
This button will return the version of plugin you are using.


Refer to Helpshift's latest documentation for updated integration steps https://developers.helpshift.com/sdkx-unity/. 