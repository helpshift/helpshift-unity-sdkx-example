package com.helpshift.unity.sdkx.helpshiftexamplenativehandler;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;

import androidx.annotation.Nullable;

import com.helpshift.unityproxy.HelpshiftUnity;

/**
 * This activity is started when user clicks on the notification generated via {@link HelpshiftNotificationUtil}
 * This is sample code for how to handle click on a notification which has Helpshift proactive outbound URL
 * embedded in it as a key-value pair.
 */
public class ProactiveOutboundNotificationClickActivity extends Activity {

    private static final String TAG = "HelpshiftEx_OutboundAct";

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Log.d(TAG, "Proactive outbound notification clicked");

        Intent intent = getIntent();
        if (intent != null) {
            Bundle extras = intent.getExtras();
            String proactiveUrl = extras.getString("helpshift_proactive_url");
            if (proactiveUrl != null && proactiveUrl.length() != 0) {
                Log.d(TAG, "Handling proactive outbound notification click with url: " + proactiveUrl);
                HelpshiftUnity.handleProactiveLink(this.getApplicationContext(), proactiveUrl);
            } else {
                Log.d(TAG, "Error handling proactive outbound notification: No url in key  helpshift_proactive_url");
            }
        } else {
            Log.d(TAG, "Error handling proactive outbound notification click: no Intent");
        }

        finish();
    }
}
