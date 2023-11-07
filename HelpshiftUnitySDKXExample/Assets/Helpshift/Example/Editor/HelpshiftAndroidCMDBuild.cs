using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/**
 Build script for Android commandline build of sample app.
 This script is to be used with Helpshift's custom sample app build only.
**/
public class HelpshiftAndroidCMDBuild 
{
    static void PerformBuild()
    {
        string[] defaultScene = { 
            "Assets/Helpshift/Example/HelpshiftExample.unity"};

        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel22;
        PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevel28;

        BuildPipeline.BuildPlayer(defaultScene, "UnityAndroidSDKX.apk" ,
            BuildTarget.Android, BuildOptions.Development);
    }

}