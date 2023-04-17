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

public class HelpshiftNotificationUtil {

    private static final String TAG = "HelpshiftEx_Notif";

    /**
     * Utility method to show notification.
     * @param context
     * @param contentText
     * @param outboundUrl
     * @throws JSONException
     */
    public static void showNotification(Context context, String contentText, String outboundUrl) {
        String contentTitle = context.getApplicationInfo().name;

        Log.d(TAG, "Creating notification :" + "\n Title : " + contentTitle);

        int notificationIcon = context.getApplicationInfo().icon;

        /**
         * Set ProactiveOutboundNotificationClickActivity as the handler activity for this notification.
         */
        Intent notificationIntent = new Intent(context, ProactiveOutboundNotificationClickActivity.class);

        /**
         * Embed key-value string data in the Intent to be used later when the user clicks on this notification.
          */
        notificationIntent.putExtra("helpshift_proactive_url", outboundUrl);

        notificationIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);

        int pendingIntentFlag = Build.VERSION.SDK_INT < 23 ? 0 : PendingIntent.FLAG_IMMUTABLE;
        PendingIntent contentIntent =
                PendingIntent.getActivity(context, 1, notificationIntent, pendingIntentFlag);

        NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(context);
        notificationBuilder.setSmallIcon(notificationIcon);
        notificationBuilder.setContentTitle(contentTitle);
        notificationBuilder.setContentText(contentText);
        notificationBuilder.setContentIntent(contentIntent);
        notificationBuilder.setAutoCancel(true);

        Notification notification = notificationBuilder.build();

        NotificationManager manager = (NotificationManager) context.getSystemService(Context.NOTIFICATION_SERVICE);
        manager.notify("HelpshiftOutboundExample", 1, notification);
    }


}
