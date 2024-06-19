using SurgeX.Helpers;
using UnityEngine;

namespace SurgeX.Managers
{
    internal class UiManager
    {
        private static string displayText = "SurgeX.BBX";
        private static GUIStyle style;
        private static Color startColor = ColorHelper.ThemeBlue;
        private static Color endColor = ColorHelper.ThemeGray;

        static UiManager()
        {
            style = new GUIStyle();
            style.fontSize = 30;
            style.fontStyle = FontStyle.Bold;
            style.normal.textColor = startColor;
        }

        public static void OnGUI()
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            float textWidth = 200;
            float textHeight = 50;
            float padding = 10;
            Rect labelRect = new Rect(screenWidth - textWidth - padding, padding, textWidth, textHeight);

            float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);

            Color lerpedColor = Color.Lerp(startColor, endColor, pingPongValue);
            style.normal.textColor = lerpedColor;

            GUI.Label(labelRect, displayText, style);
        }
    }
}
