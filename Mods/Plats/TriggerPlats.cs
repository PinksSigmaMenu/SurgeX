using SurgeX.Helpers;
using UnityEngine;
using UnityEngine.XR;

namespace StupidTemplate.Mods
{
    internal class TriggerPlatforms : MonoBehaviour
    {
        private static GameObject rplat;
        private static GameObject lplat;
        private static GameObject platformsL;
        private static GameObject platformsR;
        private const float platformScale = 0.01f;
        private const float platformHeight = 0.25f;
        private const float platformWidth = 0.25f;
        private const float childScale = 0.009f;
        private const float childHeight = 0.26f;
        private const float childWidth = 0.26f;
        private static GameObject currentPlatform;
        private static GameObject currentPlatformParent;
        private static Color platformColor;
        private static Color outlineColor;
        public static void CreatePlatforms()
        {
            float rightTrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand);
            float leftTrigger = ControllerInputPoller.TriggerFloat(XRNode.LeftHand);

            HandlePlatformCreationAndDestruction(ref rplat, ref platformsR, GorillaLocomotion.Player.Instance.rightControllerTransform.position, GorillaLocomotion.Player.Instance.rightControllerTransform.rotation, rightTrigger);
            HandlePlatformCreationAndDestruction(ref lplat, ref platformsL, GorillaLocomotion.Player.Instance.leftControllerTransform.position, GorillaLocomotion.Player.Instance.leftControllerTransform.rotation, leftTrigger);

            UpdateColors();
        }

        private static void HandlePlatformCreationAndDestruction(ref GameObject platform, ref GameObject platformParent, Vector3 position, Quaternion rotation, float triggerValue)
        {
            if (triggerValue > 0.5f)
            {
                CreatePlatform(ref platform, ref platformParent, position, rotation);
            }
            else
            {
                DestroyPlatformIfNotTriggering(ref platform, ref platformParent);
            }
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
                platform.transform.localScale = new Vector3(platformScale, platformHeight, platformWidth);

                platformParent = new GameObject("PlatformParent");
                platformParent.transform.position = position;
                platformParent.transform.rotation = rotation;

                GameObject platformChild = GameObject.CreatePrimitive(PrimitiveType.Cube);
                platformChild.transform.parent = platformParent.transform;
                platformChild.GetComponent<Renderer>().material.color = outlineColor;
                platformChild.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
                platformChild.transform.localPosition = Vector3.zero;
                platformChild.transform.localRotation = Quaternion.identity;
                platformChild.transform.localScale = new Vector3(childScale, childHeight, childWidth);

                CreateOutline(platformParent, Vector3.back * 0.00f, new Vector3(platformScale, childHeight, 0.001f));
                CreateOutline(platformParent, Vector3.back * 0.00f, new Vector3(0.001f, childHeight, childWidth));

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

        private static void DestroyPlatformIfNotTriggering(ref GameObject platform, ref GameObject platformParent)
        {
            if (platform != null)
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
