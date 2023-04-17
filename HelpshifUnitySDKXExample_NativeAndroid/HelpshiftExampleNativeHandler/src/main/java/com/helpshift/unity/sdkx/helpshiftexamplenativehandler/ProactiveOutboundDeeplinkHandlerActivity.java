package com.helpshift.unity.sdkx.helpshiftexamplenativehandler;

import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.widget.Toast;

import androidx.annotation.Nullable;

import com.helpshift.unityproxy.HelpshiftUnity;

import java.util.List;

/**
 * Proactive Outbound links that are used as deeplinks from any channel will be handled here.
 * Outbound links can be embedded in web content, emails, SMS, FAQs, push notifications etc.
 * You can also shorten the Outbound url and embed it anywhere. When shortened url is clicked, it first
 * opens a browser and then redirects to the original outbound link which in turn acts as a deeplink click
 * which will ultimately open this activity
 *
 * When user clicks on this deeplink, they will be redirected here first and then Helpshift SDK will handle the
 * subsequent flow.
 */
public class ProactiveOutboundDeeplinkHandlerActivity extends Activity {

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Intent intent = getIntent();
        Uri data = intent.getData();

        String scheme = data.getScheme();
        String host = data.getHost();

        // Check for "proactive" path when dealing with Proactive outbound links
        List<String> pathSegments = data.getPathSegments();
        String firstPath = pathSegments != null && pathSegments.size() > 0 ? pathSegments.get(0) : "";

        if (scheme.equals("helpshiftexample") && host.equals("helpshift.com") && "proactive".equals(firstPath)) {
            HelpshiftUnity.handleProactiveLink(this, data.toString());
            finish();
        } else {
            Toast.makeText(this, "Invalid link to handle", Toast.LENGTH_SHORT).show();
        }
    }
}
