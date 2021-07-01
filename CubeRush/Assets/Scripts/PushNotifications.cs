using UnityEngine;
using Unity.Notifications.Android;

public class PushNotifications : MonoBehaviour
{

    private void Awake()
    {

        AndroidNotificationChannel channel = new AndroidNotificationChannel()
        {
            Name = "Reward",
            Description = "Notifications about available bonuses",
            Id = "reward",
            Importance = Importance.Default 
        };
        AndroidNotificationChannel channel1 = new AndroidNotificationChannel()
        {
            Name = "Reminder",
            Description = "Remind about game activities",
            Id = "reminder",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        AndroidNotificationCenter.RegisterNotificationChannel(channel1);
    }

    private void Start()
    {
        SendNotification();
    }

    public void SendNotification()
    {
        AndroidNotification notification = new AndroidNotification()
        {
            Title = "Reward Awailable!",
            Text = "Take your bonus - 50 coins!",
            FireTime = System.DateTime.Now.AddHours(16),
            LargeIcon = "large_icon",
            SmallIcon = "small_icon"
        };

        AndroidNotification notification1 = new AndroidNotification()
        {
            Title = "Someone broke your record!",
            Text = "Open the game and improve your record!",
            FireTime = System.DateTime.Now.AddHours(9),
            LargeIcon = "large_icon",
            SmallIcon = "small_icon"
        };

        AndroidNotification notification2 = new AndroidNotification()
        {
            Title = "Someone broke your record!",
            Text = "Open the game and improve your record!",
            FireTime = System.DateTime.Now.AddHours(48),
            LargeIcon = "large_icon",
            SmallIcon = "small_icon"
        };

        AndroidNotification notification3 = new AndroidNotification()
        {
            Title = "Someone broke your record!",
            Text = "Open the game and improve your record!",
            FireTime = System.DateTime.Now.AddMinutes(90),
            LargeIcon = "large_icon",
            SmallIcon = "small_icon"
        };

        AndroidNotificationCenter.SendNotification(notification, "reward");
        AndroidNotificationCenter.SendNotification(notification1, "reminder");
        AndroidNotificationCenter.SendNotification(notification2 , "reminder");
        AndroidNotificationCenter.SendNotification(notification3, "reminder");
    }
}