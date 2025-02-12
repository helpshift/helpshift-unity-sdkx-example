package com.helpshift.unity.sdkx.helpshiftexamplenativehandler;

import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.os.Build;
import android.util.Log;

import androidx.core.app.NotificationCompat;

import org.json.JSONException;

import java.util.HashMap;
import java.util.Map;

public class HelpshiftNotificationUtil {

    private static final String TAG = "HelpshiftEx_Notif";

    /**
     * Utility method to show notification.
     * @param context
     * @param contentText
     * @param outboundUrl
     * @throws JSONException
     */
    public static void showProactiveOutboundNotification(Context context, String contentText, String outboundUrl) {

        /**
         * Set ProactiveOutboundNotificationClickActivity as the handler activity for this notification.
         */
        Intent notificationIntent = new Intent(context, ProactiveOutboundNotificationClickActivity.class);
        Map<String, String> contentMap = new HashMap<>();

        contentMap.put("intentKey", "helpshift_proactive_url");
        contentMap.put("intentValue", outboundUrl);
        contentMap.put("contentText", contentText);

        createNotification(context, notificationIntent, contentMap);

    }

    public static void showCloseHelpshiftSessionNotification(Context context, String contentText) {
        /**
         * Set CloseSessionNotificationClickActivity as the handler activity for this notification.
         */
        Intent notificationIntent = new Intent(context, CloseSessionNotificationClickActivity.class);

        Map<String, String> contentMap = new HashMap<>();
        contentMap.put("intentKey", "close_helpshift_session");
        contentMap.put("intentValue", "true");
        contentMap.put("contentText", contentText);

        createNotification(context, notificationIntent, contentMap);
    }

    private static void createNotification(Context context, Intent notificationIntent, Map<String, String> content) {

        String contentTitle = context.getApplicationInfo().name;

        Log.d(TAG, "Creating notification :" + "\n Title : " + contentTitle);

        int notificationIcon = context.getApplicationInfo().icon;

        /*
         * Embed key-value string data in the Intent to be used later when the user clicks on this notification.
         */
        notificationIntent.putExtra(content.get("intentKey"), content.get("intentValue"));

        notificationIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

        int pendingIntentFlag = Build.VERSION.SDK_INT < 23 ? 0 : PendingIntent.FLAG_IMMUTABLE;
        PendingIntent contentIntent =
                PendingIntent.getActivity(context, 1, notificationIntent, pendingIntentFlag);

        NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(context);
        notificationBuilder.setSmallIcon(notificationIcon);
        notificationBuilder.setContentTitle(contentTitle);
        notificationBuilder.setContentText(content.get("contentText"));
        notificationBuilder.setContentIntent(contentIntent);
        notificationBuilder.setAutoCancel(true);
        notificationBuilder.setChannelId("In-app Support");

        Notification notification = notificationBuilder.build();

        NotificationManager manager = (NotificationManager) context.getSystemService(Context.NOTIFICATION_SERVICE);
        manager.notify("HelpshiftNotificationExample", 1, notification);
    }



}
