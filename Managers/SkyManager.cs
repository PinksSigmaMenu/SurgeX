using PinkMenu.Managers;
using StupidTemplate.Classes;
using SurgeX.Helpers;
using UnityEngine;

namespace SurgeX.Managers
{
    internal class SkyManager
    {
        private Renderer _renderer;
        public static void CustomSky()
        {
            Material mat = new Material(Shader.Find("GorillaTag/UberShader"));
            mat.color = Color.Lerp(ColorHelper.ThemeBlue, ColorHelper.ThemeGray, Mathf.PingPong(Time.time, 0.50f));

            GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky/newsky (1)").GetComponent<Renderer>().material = mat;
            GameObject.Find("Environment Objects/LocalObjects_Prefab/Standard Sky").GetComponent<Renderer>().material = mat;
        }
    }
}
  
