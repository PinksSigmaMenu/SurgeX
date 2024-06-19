using SurgeX.Helpers;
using System.Collections;
using UnityEngine;

namespace StupidTemplate.Mods.Plats
{
    internal class NormalPlatforms
    {
        public static GameObject rplat;
        public static GameObject lplat;
        public static GameObject platformsL;
        public static GameObject platformsR;
        public static bool rplatEnabled = false;
        public static bool lplatEnabled = false;

        private static GameObject currentPlatform;
        private static GameObject currentPlatformParent;
        private static Color platformColor;
        private static Color outlineColor;

        public static void CreatePlatforms()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                CreatePlatform(ref rplat, ref platformsR, GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.rotation);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                CreatePlatform(ref lplat, ref platformsL, GorillaLocomotion.Player.Instance.leftControllerTransform.position, GorillaLocomotion.Player.Instance.leftControllerTransform.rotation);
            }
            DestroyPlatformIfNotTriggering(ControllerInputPoller.instance.rightGrab, ref rplat, ref platformsR);
            DestroyPlatformIfNotTriggering(ControllerInputPoller.instance.leftGrab, ref lplat, ref platformsL);

            UpdateColors(); 
        }

        private static void CreatePlatform(ref GameObject platform, ref GameObject platformParent, Vector3 position, Quaternion rotation)
        {
            if (platform == null)
            {
                platformColor = GetPingPongColor(ColorHelper.ThemeBlue, ColorHelper.ThemeGray);
                outlineColor = ColorHelper.darkBlue;

                platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
                platform.GetComponent<Renderer>().material.color = platformColor;
                platform.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                platform.transform.position = position;
                platform.transform.rotation = rotation;
                platform.transform.localScale = new Vector3(0.01f, 0.25f, 0.25f);

                platformParent = new GameObject("PlatformParent");
                platformParent.transform.position = position;
                platformParent.transform.rotation = rotation;

                GameObject platformChild = GameObject.CreatePrimitive(PrimitiveType.Cube);
                platformChild.transform.parent = platformParent.transform;
                platformChild.GetComponent<Renderer>().material.color = outlineColor;
                platformChild.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                platformChild.transform.localPosition = Vector3.zero;
                platformChild.transform.localRotation = Quaternion.identity;
                platformChild.transform.localScale = new Vector3(0.009f, 0.26f, 0.26f);

                CreateOutline(platformParent, Vector3.back * 0.00f, new Vector3(0.01f, 0.26f, 0.001f));
                CreateOutline(platformParent, Vector3.back * 0.00f, new Vector3(0.001f, 0.26f, 0.26f));

                currentPlatform = platform;
                currentPlatformParent = platformParent;
            }
        }

        private static void CreateOutline(GameObject parent, Vector3 localPosition, Vector3 localScale)
        {
            GameObject outline = GameObject.CreatePrimitive(PrimitiveType.Cube);
            outline.transform.parent = parent.transform;
            outline.GetComponent<Renderer>().material.color = outlineColor;
            outline.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
            outline.transform.localPosition = localPosition;
            outline.transform.localRotation = Quaternion.identity;
            outline.transform.localScale = localScale;
        }

        private static void DestroyPlatformIfNotTriggering(bool isTriggering, ref GameObject platform, ref GameObject platformParent)
        {
            if (!isTriggering && platform != null)
            {
                GameObject.Destroy(platform);
                GameObject.Destroy(platformParent);
                platform = null;
                platformParent = null;
                currentPlatform = null;
                currentPlatformParent = null;
            }
        }

        private static Color GetPingPongColor(Color color1, Color color2)
        {
            float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
            return Color.Lerp(color1, color2, pingPongValue);
        }

        private static void UpdateColors()
        {
            if (currentPlatform != null)
            {
                platformColor = GetPingPongColor(ColorHelper.ThemeBlue, ColorHelper.ThemeGray);
                outlineColor = ColorHelper.darkBlue;

                currentPlatform.GetComponent<Renderer>().material.color = platformColor;
                currentPlatformParent.transform.GetChild(0).GetComponent<Renderer>().material.color = outlineColor;
            }
        }
    }
}
