using PinkMenu.Helpers;
using SurgeX.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using Valve.VR;

namespace SurgeX.Mods
{
    internal class Movement
    {
        public static float flyingSpeed = 15f;
        public static float noCollisionRadius = 5f;
        private static bool isFlying = false;
        private static Vector3 OPOS;
        private static float baseSpeed = 10f;
        private static float sprintMultiplier = 2.5f;
        private static float mouseSensitivity = 0.9f;
        private static float smoothTime = 0.1f;
        private static Vector3 velocity = Vector3.zero;
        private static Vector3 rotationVelocity = Vector3.zero;

        public static void NoClipFly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                isFlying = true;

                GorillaTagger.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * flyingSpeed;
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;

                Collider[] allColliders = GameObject.FindObjectsOfType<Collider>();
                foreach (Collider collider in allColliders)
                {
                    collider.enabled = false;
                }
            }
            else if (isFlying)
            {
                isFlying = false;

                Collider[] allColliders = GameObject.FindObjectsOfType<Collider>();
                foreach (Collider collider in allColliders)
                {
                    collider.enabled = true;
                }
            }
        }
        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaTagger.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
        public static void BarkFly()
        {
            Rigidbody rb = GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody;

            rb.AddForce(Vector3.up * 9.81f, ForceMode.Acceleration);

            Vector2 leftJoystickInput = SteamVR_Actions.gorillaTag_LeftJoystick2DAxis.axis;
            float rightJoystickVerticalInput = SteamVR_Actions.gorillaTag_RightJoystick2DAxis.axis.y;

            Vector3 playerForward = GorillaLocomotion.Player.Instance.bodyCollider.transform.forward;
            playerForward.y = 0;
            Vector3 playerRight = GorillaLocomotion.Player.Instance.bodyCollider.transform.right;
            playerRight.y = 0;

            Vector3 targetVelocity = leftJoystickInput.x * playerRight +
                                     rightJoystickVerticalInput * Vector3.up +
                                     leftJoystickInput.y * playerForward;
            float GodHelpMePlease = 5f;
            targetVelocity *= GorillaLocomotion.Player.Instance.scale * GodHelpMePlease;

            float smoothness = 0.12875f;
            rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, smoothness);
        }

        public static void TriggerFly()
        {
            float Ltrigger = ControllerInputPoller.TriggerFloat(XRNode.LeftHand);

            if (Ltrigger > 0.5f)
            {
                GorillaTagger.Instance.transform.position += GorillaTagger.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
                GorillaTagger.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        
        public static void WASDFly()
        {
            Transform bodyTransform = Camera.main.transform;
            Rigidbody playerRigidbody = GorillaTagger.Instance.rigidbody;
            playerRigidbody.useGravity = false;
            playerRigidbody.velocity = Vector3.zero;

            float currentSpeed = baseSpeed * (Keyboard.current.leftShiftKey.isPressed ? sprintMultiplier : 1f);

            Vector3 direction = Vector3.zero;
            if (Keyboard.current.wKey.isPressed) direction += bodyTransform.forward;
            if (Keyboard.current.aKey.isPressed) direction += -bodyTransform.right;
            if (Keyboard.current.sKey.isPressed) direction += -bodyTransform.forward;
            if (Keyboard.current.dKey.isPressed) direction += bodyTransform.right;
            if (Keyboard.current.spaceKey.isPressed) direction += bodyTransform.up;
            if (Keyboard.current.leftCtrlKey.isPressed) direction += -bodyTransform.up;

            if (direction != Vector3.zero)
            {
                direction.Normalize();
                bodyTransform.position += direction * currentSpeed * Time.deltaTime;
            }

            if (Mouse.current.rightButton.isPressed)
            {
                Vector3 mouseDelta = (Vector3)Mouse.current.position.ReadValue() - OPOS;
                Vector3 targetRotation = bodyTransform.localEulerAngles + new Vector3(-mouseDelta.y * mouseSensitivity, mouseDelta.x * mouseSensitivity, 0f);
                bodyTransform.localEulerAngles = Vector3.SmoothDamp(bodyTransform.localEulerAngles, targetRotation, ref rotationVelocity, smoothTime);
            }

            OPOS = Mouse.current.position.ReadValue();
        }
        public static void RotateHeadY()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.y += 150f * Time.deltaTime;
        }

        public static void RotateHeadX()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.x += 150f * Time.deltaTime;
        }

        public static void RotateHeadZ()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset.z += 150f * Time.deltaTime;
        }
        public static void FixHeadRotation()
        {
            GorillaTagger.Instance.offlineVRRig.head.trackingRotationOffset = UnityEngine.Vector3.zero;
        }
    }
}

