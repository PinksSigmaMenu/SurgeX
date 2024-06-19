using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SurgeX.Mods
{
    internal class GameMods
    {
        public static void BatHalo()
        {
            float offset = 360f / 3f;
            GameObject caveBat = GameObject.Find("Cave Bat Holdable");
            if (caveBat)
            {
                caveBat.GetComponent<ThrowableBug>().WorldShareableRequestOwnership();
                caveBat.transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(MathF.Cos(offset + ((float)Time.frameCount / 30)), 1, MathF.Sin(offset + ((float)Time.frameCount / 30)));
            }
        }

        public static void BeachBallHalo()
        {
            float offset = (360f / 3f) * 2f;
            GameObject.Find("BeachBall").transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(MathF.Cos(offset + ((float)Time.frameCount / 30)), 1f, MathF.Sin(offset + ((float)Time.frameCount / 30)));
        }

        public static void BugHalo()
        {
            float offset = 0;
            GameObject.Find("Floating Bug Holdable").GetComponent<ThrowableBug>().WorldShareableRequestOwnership();
            GameObject.Find("Floating Bug Holdable").transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(MathF.Cos(offset + ((float)Time.frameCount / 30)), 1f, MathF.Sin(offset + ((float)Time.frameCount / 30)));
        }

        public static void GrabBug()
        {
            try
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    GameObject bug = GameObject.Find("Floating Bug Holdable");
                    if (bug)
                    {
                        bug.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error in GrabBug: {ex.Message}");
            }
        }

        public static void GrabBat()
        {
            try
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    GameObject bat = GameObject.Find("Cave Bat Holdable");
                    if (bat != null)
                    {
                        bat.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error in GrabBat: {ex.Message}");
            }
        }

        public static void GrabBall()
        {
            try
            {
                if (ControllerInputPoller.instance.rightGrab)
                {
                    GameObject ball = GameObject.Find("BeachBall");
                    if (ball)
                    {
                        ball.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error in GrabBall: {ex.Message}");
            }
        }

        public static void GrabMonsters()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                MoveAllMonkeysToRightHand();
            }
        }

        private static void MoveAllMonkeysToRightHand()
        {
            Vector3 rightHandPosition = GorillaTagger.Instance.rightHandTransform.position;

            MonkeyeAI[] monkeys = UnityEngine.Object.FindObjectsOfType<MonkeyeAI>();

            foreach (MonkeyeAI monkey in monkeys)
            {
                MoveMonkeyToPosition(monkey, rightHandPosition);
            }
        }

        private static void MoveMonkeyToPosition(MonkeyeAI monkey, Vector3 position)
        {
            monkey.gameObject.transform.position = position;
        }

        public static void Rain()
        {
            var rainingArray = Enumerable.Repeat(BetterDayNightManager.WeatherType.Raining, BetterDayNightManager.instance.weatherCycle.Length - 1).ToArray();

            Enumerable.Range(1, BetterDayNightManager.instance.weatherCycle.Length - 1)
                      .Zip(rainingArray, (index, weatherType) => new { index, weatherType })
                      .ToList()
                      .ForEach(pair =>
                      {
                          BetterDayNightManager.instance.weatherCycle[pair.index] = pair.weatherType;
                      });
        }

        public static void DisableRain()
        {
            bool isRainActive = false;
            for (int i = 1; i < BetterDayNightManager.instance.weatherCycle.Length; i++)
            {
                if (BetterDayNightManager.instance.weatherCycle[i] == BetterDayNightManager.WeatherType.Raining)
                {
                    isRainActive = true;
                    break;
                }
            }
            if (isRainActive)
            {
                for (int i = 1; i < BetterDayNightManager.instance.weatherCycle.Length; i++)
                {
                    BetterDayNightManager.instance.weatherCycle[i] = BetterDayNightManager.WeatherType.None;
                }
            }
        }
        public static void SetNight()
        {
            BetterDayNightManager.instance.SetTimeOfDay(0);
        }

        public static void SetAfternoon()
        {
            BetterDayNightManager.instance.SetTimeOfDay(1);
        }

        public static void SetDay()
        {
            BetterDayNightManager.instance.SetTimeOfDay(3);
        }
    }
}
