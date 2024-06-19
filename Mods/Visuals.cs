using Photon.Pun;
using PinkMenu.Helpers;
using SurgeX.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SurgeX.Mods
{
    internal class Visuals
    {
        private static readonly List<LineRenderer> activeLineRenderers = new List<LineRenderer>();

        public static void BoneESP()
        {
            foreach (VRRig FullPlayers in GorillaParent.instance.vrrigs)
            {
                if (FullPlayers != GorillaTagger.Instance.offlineVRRig)
                {
                    DrawESPLine(FullPlayers.head.rigTarget.gameObject, FullPlayers.head.rigTarget.transform.position + new Vector3(0f, 0.16f, 0f), FullPlayers.head.rigTarget.transform.position - new Vector3(0f, 0.4f, 0f));

                    for (int i = 0; i < GetBones.bones.Length; i += 2)
                    {
                        DrawESPLine(FullPlayers.mainSkin.bones[GetBones.bones[i]].gameObject, FullPlayers.mainSkin.bones[GetBones.bones[i]].position, FullPlayers.mainSkin.bones[GetBones.bones[i + 1]].position);
                    }
                }
            }

            CleanupLineRenderers();
        }
        private static void DrawESPLine(GameObject target, Vector3 start, Vector3 end)
        {
            LineRenderer lineRenderer = target.GetComponent<LineRenderer>();
            if (lineRenderer == null)
            {
                lineRenderer = target.AddComponent<LineRenderer>();
                lineRenderer.startWidth = 0.025f;
                lineRenderer.endWidth = 0.025f;
                lineRenderer.startColor = ColorHelper.ThemeBlue;
                lineRenderer.endColor = ColorHelper.ThemeGray;
                lineRenderer.material = new Material(Shader.Find("GUI/Text Shader"));
            }

            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);

            activeLineRenderers.Add(lineRenderer);
        }

        private static void CleanupLineRenderers()
        {
            foreach (LineRenderer lineRenderer in activeLineRenderers)
            {
                if (lineRenderer != null)
                {
                    UnityEngine.Object.Destroy(lineRenderer, Time.deltaTime);
                }
            }

            activeLineRenderers.Clear();
        }

        public static void Tracers()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig Trace in GorillaParent.instance.vrrigs)
                {
                    if (Trace != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject SphereObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        SphereObject.transform.position = GorillaTagger.Instance.offlineVRRig.rightHandTransform.position;
                        SphereObject.transform.rotation = GorillaTagger.Instance.offlineVRRig.rightHandTransform.rotation;
                        SphereObject.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
                        UnityEngine.Object.Destroy(SphereObject.GetComponent<Collider>());
                        Shader SphereShader = Shader.Find("GUI/Text Shader");
                        Material SphereMat = new Material(SphereShader);
                        SphereObject.GetComponent<Renderer>().material = SphereMat;
                        float pingPongValue2 = Mathf.PingPong(Time.time / 2f, 1f);
                        SphereMat.color = Color.Lerp(ColorHelper.ThemeBlue, ColorHelper.ThemeGray, pingPongValue2);

                        UnityEngine.Object.Destroy(SphereObject, Time.deltaTime);

                        GameObject Lines = new GameObject("Line");
                        LineRenderer lineRenderer = Lines.AddComponent<LineRenderer>();
                        lineRenderer.startWidth = 0.02f;
                        lineRenderer.endWidth = 0.02f;
                        lineRenderer.SetPositions(new Vector3[]
                        {
                          SphereObject.transform.position,
                          Trace.transform.position
                        });

                        UnityEngine.Object.Destroy(Lines.GetComponent<Collider>());

                        Shader LineShader = Shader.Find("GUI/Text Shader");
                        Material LineMat = new Material(LineShader);
                        Lines.GetComponent<Renderer>().material = LineMat;
                        float pingPongValue1 = Mathf.PingPong(Time.time / 2f, 1f);
                        LineMat.color = Color.Lerp(ColorHelper.ThemeBlue, ColorHelper.ThemeGray, pingPongValue1);

                        UnityEngine.Object.Destroy(Lines, Time.deltaTime);
                    }
                }
            }
        }
        public static void HollowBoxESP()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig fullPlayer in GorillaParent.instance.vrrigs)
                {
                    if (fullPlayer != GorillaTagger.Instance.offlineVRRig)
                    {
                        DrawHollowBox(fullPlayer.transform);
                    }
                }
            }
        }
        private static void DrawHollowBox(Transform targetTransform)
        {
            float halfSize = 0.25f;

            float halfWidth = 0.25f;
            float halfHeight = 0.35f;

            Vector3[] corners = new Vector3[]
            {
        targetTransform.TransformPoint(new Vector3(-halfSize, halfSize, -halfSize)),
        targetTransform.TransformPoint(new Vector3(halfSize, halfSize, -halfSize)),
        targetTransform.TransformPoint(new Vector3(halfSize, -halfSize, -halfSize)),
        targetTransform.TransformPoint(new Vector3(-halfSize, -halfSize, -halfSize)),

        targetTransform.TransformPoint(new Vector3(-halfSize, halfSize, halfSize)),
        targetTransform.TransformPoint(new Vector3(halfSize, halfSize, halfSize)),
        targetTransform.TransformPoint(new Vector3(halfSize, -halfSize, halfSize)),
        targetTransform.TransformPoint(new Vector3(-halfSize, -halfSize, halfSize))
            };
            DrawLine(corners[0], corners[1]);
            DrawLine(corners[1], corners[2]);
            DrawLine(corners[2], corners[3]);
            DrawLine(corners[3], corners[0]);

            DrawLine(corners[4], corners[5]);
            DrawLine(corners[5], corners[6]);
            DrawLine(corners[6], corners[7]);
            DrawLine(corners[7], corners[4]);

            DrawLine(corners[0], corners[4]);
            DrawLine(corners[1], corners[5]);
            DrawLine(corners[2], corners[6]);
            DrawLine(corners[3], corners[7]);
        }
        private static void DrawLine(Vector3 start, Vector3 end)
        {
            GameObject line = new GameObject("Line");
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
            lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
            lineRenderer.startColor = ColorHelper.ThemeBlue;
            lineRenderer.endColor = ColorHelper.ThemeBlue;
            lineRenderer.startWidth = 0.02f;
            lineRenderer.endWidth = 0.02f;
            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);
            UnityEngine.Object.Destroy(line, Time.deltaTime);
        }

        public static void CapsuleESPP()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig FullPlayers in GorillaParent.instance.vrrigs)
                {
                    if (FullPlayers != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject PinksPen = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        PinksPen.transform.position = FullPlayers.transform.position;
                        PinksPen.transform.rotation = FullPlayers.transform.rotation;
                        PinksPen.transform.localScale = new Vector3(0.40f, 0.45f, 0.40f);
                        Shader ESPShader3 = Shader.Find("GUI/Text Shader");
                        Material sphereMaterial1 = new Material(ESPShader3);
                        PinksPen.GetComponent<Renderer>().material = sphereMaterial1;
                        float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                        Color transparentMagenta = new Color(ColorHelper.ThemeBlue.r, ColorHelper.ThemeGray.g, ColorHelper.ThemeBlue.b, 0.5f);
                        Color transparentBlack = new Color(ColorHelper.ThemeGray.r, ColorHelper.ThemeBlue.g, ColorHelper.ThemeGray.b, 0.5f);
                        Color lerpedColor = Color.Lerp(transparentMagenta, transparentBlack, pingPongValue);
                        sphereMaterial1.color = lerpedColor;
                        UnityEngine.Object.Destroy(PinksPen, Time.deltaTime);
                    }
                }
            }
        }
        public static void SphereESPP()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig player in GorillaParent.instance.vrrigs)
                {
                    if (player != GorillaTagger.Instance.offlineVRRig)
                    {
                        GameObject headESP = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        headESP.transform.position = player.transform.position + Vector3.up * 0.1f;
                        headESP.transform.rotation = player.transform.rotation;
                        headESP.transform.localScale = new Vector3(0.20f, 0.20f, 0.20f);
                        UnityEngine.Object.Destroy(headESP.GetComponent<Collider>());
                        Shader espShader = Shader.Find("GUI/Text Shader");
                        Material espMaterial = new Material(espShader);
                        UnityEngine.Object.Destroy(headESP.GetComponent<Collider>());
                        headESP.GetComponent<Renderer>().material = espMaterial;
                        float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                        Color Theme1 = ColorHelper.ThemeBlue;
                        Color Theme2 = ColorHelper.ThemeGray;
                        Color lerpedColor = Color.Lerp(Theme1, Theme2, pingPongValue);
                        espMaterial.color = lerpedColor;
                        UnityEngine.Object.Destroy(headESP, Time.deltaTime);
                    }
                }
            }
        }
        public static void BoxESP()
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig player in GorillaParent.instance.vrrigs)
                {
                    if (player != GorillaTagger.Instance.offlineVRRig)
                    {
                        Vector3 playerPosition = player.transform.position;

                        GameObject boxESP = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        boxESP.transform.position = playerPosition + Vector3.down * 0.1f;
                        boxESP.transform.rotation = player.transform.rotation;
                        boxESP.transform.localScale = new Vector3(0.60f, 0.60f, 0.60f);
                        UnityEngine.Object.Destroy(boxESP.GetComponent<Collider>());
                        Shader espShader = Shader.Find("GUI/Text Shader");
                        Material espMaterial = new Material(espShader);
                        boxESP.GetComponent<Renderer>().material = espMaterial;
                        espMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                        espMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                        espMaterial.SetInt("_ZWrite", 0);
                        espMaterial.DisableKeyword("_ALPHATEST_ON");
                        espMaterial.EnableKeyword("_ALPHABLEND_ON");
                        espMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                        espMaterial.renderQueue = 3000;
                        float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
                        Color Theme1 = new Color(ColorHelper.ThemeBlue.r, ColorHelper.ThemeBlue.g, ColorHelper.ThemeBlue.b, 0.5f);
                        Color Theme2 = new Color(ColorHelper.ThemeGray.r, ColorHelper.ThemeGray.g, ColorHelper.ThemeGray.b, 0.5f);
                        Color lerpedColor = Color.Lerp(Theme1, Theme2, pingPongValue);
                        espMaterial.color = lerpedColor;
                        UnityEngine.Object.Destroy(boxESP, Time.deltaTime);
                    }
                }
            }
        }
        public static void AnimatedSphere(float height = DefaultHeight)
        {
            if (PhotonNetwork.InRoom || PhotonNetwork.InLobby)
            {
                foreach (VRRig fullPlayer in GorillaParent.instance.vrrigs)
                {
                    if (fullPlayer != GorillaTagger.Instance.offlineVRRig)
                    {
                        DrawAnimatedSphere(fullPlayer.transform, height);
                    }
                }
            }
        }
        private const float DefaultHeight = 0.5f;
        private const float PulseDuration = 0.15f;
        private const float PulseScaleFactor = 0.1f;
        private static void DrawAnimatedSphere(Transform targetTransform, float height)
        {
            float radius = 0.1f;
            int rings = 8;
            int segments = 16;

            float heightIncrement = height / rings;

            float pulseAmount = Mathf.PingPong(Time.time, PulseDuration) / PulseDuration;

            for (int r = 0; r < rings; r++)
            {
                float normalizedRadius = radius * (float)(r + 1) / rings;
                float currentHeight = heightIncrement * (r + 1);

                float animatedRadius = normalizedRadius + normalizedRadius * pulseAmount * PulseScaleFactor;

                Vector3 center = targetTransform.position + Vector3.up * currentHeight;
                DrawSphere(center, animatedRadius, segments);
            }
        }
        private static void DrawSphere(Vector3 center, float radius, int segments)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = center;
            sphere.transform.localScale = new Vector3(radius * 2, radius * 2, radius * 2);
            sphere.GetComponent<Renderer>().material.shader = Shader.Find("GUI/Text Shader");

            float pingPongValue = Mathf.PingPong(Time.time / 2f, 1f);
            Color sphereColor = Color.Lerp(ColorHelper.ThemeBlue, ColorHelper.ThemeGray, pingPongValue);
            sphere.GetComponent<Renderer>().material.color = sphereColor;

            UnityEngine.Object.Destroy(sphere, Time.deltaTime);
        }
    }
}






