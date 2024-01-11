using UnityEngine;

namespace Global
{
    namespace Constants
    {
        public class ChestAnimator
        {
            public const string openChestTrigger = "isChestOpened";
            public const string isKeyShowing = "isKeyShowing";
        }

        public class PlayerPrefs
        {
            public const string bestTime = "BestTime";
        }

        public class ObjectNames {
            public const string bestTimeTxt = "BestTimeText";
            public const string currentTimeTxt = "CurrentTimeText";
        }

        public class StringTemapltes
        {
            public const string bestTime = "Best time: ";
            public const string currentTime = "Current time: ";
        }
    }

    public class Funcs
    {
        public static string FormatSeconds(float secondsRaw)
        {
            int minutes = Mathf.FloorToInt(secondsRaw / 60);
            float secondsAsMiliseconds = secondsRaw % 60 * 1000;
            int seconds = Mathf.FloorToInt(secondsAsMiliseconds / 1000);
            int miliseconds = Mathf.FloorToInt(secondsAsMiliseconds % 1000);

            return string.Format("{0:D2}:{1:D2}:{2:D3}",
                minutes, seconds, miliseconds);
        }
    }
}