
# Helpshift SDK X Unity Example App

Sample Unity project demonstrating the integration of Helpshift Unity SDK X

## Requirements

* See Helpshift SDK X requirements:
    * [Android - Getting Started](https://developers.helpshift.com/sdkx-unity/getting-started-android/)
    * [iOS - Getting Started](https://developers.helpshift.com/sdkx-unity/getting-started-ios/)

## Import project

1. Clone the repositiory.
2. Open `HelpshiftUnitySDKXExample` project in Unity IDE 2018.3 and above.
3. Download Firebase unity SDK (11.7.0) zip file from [here]https://dl.google.com/firebase/sdk/unity/firebase_unity_sdk_11.6.0.zip).(11.6.0 is the minimum version needed to run succesfully )
   * Import `FirebaseMessaging.unitypackage` only.
   * This package comes with unity jar resolver, use this to resolve all Android related dependencies.

## Building the project

Please follow these steps to build the app:
* Update your Helpshift App credentials in `HelpshiftUnitySDKXExample/Assets/Helpshift/Example/HelpshiftExampleScript.cs` file. 
    * Replace domain name in `<your-domain>.helpshift.com` and appId in `<your-app-android-app-id>` string placeholders in this file.
    * To get your Helpshift app credentials please check [here](https://developers.helpshift.com/sdkx-unity/getting-started-android/).

---

**FOR ANDROID**

FCM push notification is already integrated in the example app but we have provided a dummy `google-services.json` file.

* You can configure FCM by providing your own `google-services.json` file at `HelpshiftUnitySDKXExample/Assets/google-services.json`.
* You can then provide the FCM API Key in Helpshift Dashboard as mentioned [here](https://developers.helpshift.com/sdkx-unity/notifications-android#push-via-helpshift)
* Make sure to have same package name for the app in Unity's Build Settings as you use in this google-services.json file

---

**FOR iOS**

- Ensure correct bundle Identifier, Signing Team ID and Provisioning Profile is set in Unity Player Settings
- For push notifications support, enable the "Push Notifications" capability in generated Xcode project
- The bundle identifier of the app should match the bundle identifier of the push certificate you have uploaded on Helpshift admin dashboard

---

Build the project in Unity and Run on your device.


## Example feature implementations

### Initializing Helpshift SDK via `Install`

* Refer to `Assets/Helpshift/Example/HelpshiftExampleScript.cs` class, `Awake()` method.
* Notice that we have initialized the SDK as soon as the app is launched.


NOTE: `HelpshiftSdk.GetInstance().Install()` must be called before invoking any other api in the Helpshift SDK. 


### User Management

* Refer to the following functions in `Assets/Helpshift/Example/HelpshiftExampleScript.cs` for User related integration and example code: [User Management](/HelpshiftUnitySDKXExample/Assets/Helpshift/Example/HelpshiftExampleScript.cs)
    * `Login`
    * `Logout`
* Developer Documentation: 
    * Android: [User](https://developers.helpshift.com/sdkx-unity/users-android/)
    * iOS: [User](https://developers.helpshift.com/sdkx-unity/users-ios/)

### SDK Configurations

* Refer to the following function in `Assets/Helpshift/Example/HelpshiftExampleScript.cs` for SDK configurations: [Configurations](/HelpshiftUnitySDKXExample/Assets/Helpshift/Example/HelpshiftExampleScript.cs)
    * `GetConversationConfig`: This function reads config as set by you from UI and constructs a Dictionary as expected by the SDK. 
* It contains custom example for CIF, please modify according to your needs.
* Many other configurations are picked from the example app UI.
* Developer Documentation: 
    * Android: [Configurations](https://developers.helpshift.com/sdkx-unity/sdk-configuration-android/)
    * iOS: [Configurations](https://developers.helpshift.com/sdkx-unity/sdk-configuration-ios/)

### Showing Conversation/FAQ screens, Breadcrumbs, Logs, setting Language etc

* For example code of various other features please refer to code examples in [HelpshiftExampleScript](/HelpshiftUnitySDKXExample/Assets/Helpshift/Example/HelpshiftExampleScript.cs)
    * `ShowConversation`
    * `ShowFAQs`
    * `ShowFAQSection`
    * `AddDebugLog`
    * `SetSDKLanguage`
    * `LeaveBreadCrumb`
    * `ClearBreadCrumb`
    * `RequestUnreadCount`
    * many others...
* The code is easy to interpret since each button on UI has been linked with a feature.
* For example if you need example code for showing Conversation Screen, refer function `ShowConversation` in the HelpshiftExampleScript.cs script.
* Developer Documentation:
    * Android: [Helpshift APIs](https://developers.helpshift.com/sdkx-unity/support-tools-android/)
    * iOS: [Helpshift APIs](https://developers.helpshift.com/sdkx-unity/support-tools-ios/)

### Android: Handling push notifications from Helpshift

* To handle push notifications from Helpshift, refer the following code example: [Helpshift Push Notification](/HelpshiftUnitySDKXExample/Assets/Helpshift/Example/FirebaseIntegration.cs)
* Notice that we have checked "origin" as "helpshift" before calling `HandlePush` with the SDK.
* Developer Documentation: [Notifications](https://developers.helpshift.com/sdkx-unity/notifications-android/)

### Proactive Outbound Support

* To show Proactive Outbound notification on device when receiving push notifications in Unity check the code sample here: [Outbound Push Notification](/HelpshiftUnitySDKXExample/Assets/Helpshift/Example/FirebaseIntegration.cs)

* For this example app, notification is generated from Java layer via [HelpshiftNotificationUtil](/HelpshifUnitySDKXExample_NativeAndroid/HelpshiftExampleNativeHandler/src/main/java/com/helpshift/unity/sdkx/helpshiftexamplenativehandler/HelpshiftNotificationUtil.java)

For this example app, we handle the click of this notification in Java layer itself via [ProactiveOutboundNotificationClickActivity](/HelpshifUnitySDKXExample_NativeAndroid/HelpshiftExampleNativeHandler/src/main/java/com/helpshift/unity/sdkx/helpshiftexamplenativehandler/ProactiveOutboundNotificationClickActivity.java)

* Handling Proactive Outbound links as deep links
   * Proactive Outbound links can be embedded in any channel like push notifications, email, sms, web etc
   * To handle these deeplinks we need to create an Activity that will open when such links are clicked.
   * Check Activity code here: [ProactiveOutboundDeeplinkHandlerActivity](/HelpshifUnitySDKXExample_NativeAndroid/HelpshiftExampleNativeHandler/src/main/java/com/helpshift/unity/sdkx/helpshiftexamplenativehandler/ProactiveOutboundDeeplinkHandlerActivity.java)
      
   * Check the AndroidManifest to declare the deeplink pattern and protocol here: [AndroidManifest Deeplink](/HelpshifUnitySDKXExample_NativeAndroid/HelpshiftExampleNativeHandler/src/main/AndroidManifest.xml)

* Developer documentation:
   * Android: [Outbound Support](https://developers.helpshift.com/sdkx-unity/outbound-support-android/)
   * iOS: [Outbound Support](https://developers.helpshift.com/sdkx-unity/outbound-support-ios/)


### Event Delegates
 
* Refer class [HSEventsListener.cs](/HelpshiftUnitySDKXExample/Assets/Helpshift/Example/HSEventsListener.cs)

### Android: Custom notification icon and sound

* To modify notification icons and sound, we need to declare the resource names in `Install` configuration when initializing the SDK
    * Refer function `GetInstallConfig` in [HelpshiftExampleScript](/HelpshiftUnitySDKXExample/Assets/Helpshift/Example/HelpshiftExampleScript.cs)
* Refer to the following android library added as an example to hold these files:
    * [HelpshiftExample.androidlib](/HelpshiftUnitySDKXExample/Assets/Plugins/Android/HelpshiftExample.androidlib)
    * Icon and sound files are included in the `res` directory

## Resources
* Android Documentation: https://developers.helpshift.com/sdkx-unity/getting-started-android/
* iOS Documentation: https://developers.helpshift.com/sdkx-unity/getting-started-ios/
* Release Notes: https://developers.helpshift.com/sdkx-unity/release-notes-unity/

## License

```
Copyright 2021, Helpshift, Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
```
