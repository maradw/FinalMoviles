using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

public class NotificationSystem : MonoBehaviour
{

    private void Start()
    {
#if UNITY_ANDROID
        RequestAuthorization();
        RegisterChannel();
#endif
    }

#if UNITY_ANDROID
    public void RequestAuthorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }


    public void RegisterChannel()
    {
        AndroidNotificationChannel channel = new AndroidNotificationChannel();
        channel.Id = "channel";
        channel.Name = "normal";
        channel.Importance = Importance.Default;
        channel.Description = "Notifications";
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    

    public void SetNotify(string title, string text, int fireTimeInHours)
    {
        AndroidNotificationCenter.CancelAllScheduledNotifications();
        AndroidNotification imageNotification = new AndroidNotification();
        imageNotification.Title = title;
        imageNotification.Text = text;
        imageNotification.FireTime = DateTime.Now.AddHours(fireTimeInHours);
        imageNotification.SmallIcon = "small";
        imageNotification.LargeIcon = "large";

        AndroidNotificationCenter.SendNotification(imageNotification, "high_score");

    }
    public void SimpleNotification(string title, string text, int fireTimeInSeconds = 5, string channelId = "normal_score")
    {
        AndroidNotification notification = new AndroidNotification()
        {
            Title = title,
            Text = text,
            FireTime = DateTime.Now.AddSeconds(fireTimeInSeconds),
        };

        AndroidNotificationCenter.SendNotification(notification, channelId);
    }
    
#endif
}
