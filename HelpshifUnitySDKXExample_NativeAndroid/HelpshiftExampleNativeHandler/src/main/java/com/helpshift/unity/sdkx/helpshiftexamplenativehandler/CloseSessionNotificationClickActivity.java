package com.helpshift.unity.sdkx.helpshiftexamplenativehandler;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;

import androidx.annotation.Nullable;

import com.helpshift.unityproxy.HelpshiftUnity;

import java.util.Objects;

/**
 * This activity is started when user clicks on the notification generated via {@link HelpshiftNotificationUtil}
 * This is sample code for how to handle click on a notification which has Helpshift proactive outbound URL
 * embedded in it as a key-value pair.
 */
public class CloseSessionNotificationClickActivity extends android.app.Activity {

    private static final String TAG = "HS_EX_CloseSsnAct";

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Log.d(TAG, "Close Session notification clicked");

        Intent intent = getIntent();
        if (intent != null) {
            Bundle extras = intent.getExtras();
            String closeSession = extras.getString("close_helpshift_session");
            if (Objects.equals(closeSession, "true")) {
                Log.d(TAG, "Handling Close Session notification click");
                HelpshiftUnity.closeSession();
            } else {
                Log.e(TAG, "Error handling notification");
            }
        } else {
            Log.e(TAG, "Error handling notification");
        }
        finish();
    }
}
