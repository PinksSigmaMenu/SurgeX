using PinkMenu.Managers;
using StupidTemplate.Classes;
using UnityEngine;

namespace SurgeX.Helpers
{
    internal class ScoreboardHelper
    {
        private static bool disableBoardColor = false;

        public static void UpdateBoardColor(Theme theme = null)
        {
            try
            {
                if (theme == null)
                    theme = ThemeManager.GetTheme();

                ExtGradient boardGradient = theme.GetBoard(true);

                Material pinkMaterial = new Material(Shader.Find("GorillaTag/UberShader"));

                if (!disableBoardColor)
                    pinkMaterial.color = GetBGColor(boardGradient);
                else
                    pinkMaterial.color = new Color32(0, 53, 2, 255);

                UpdateBoardMaterials("TreeRoom", "forestatlas", 1, pinkMaterial);
                UpdateBoardMaterials("Forest", "forestatlas", 8, pinkMaterial);

                UpdateChildObjectMaterial("TreeRoom", "CodeOfConduct_Group/StaticUnlit/screen", pinkMaterial);
                UpdateChildObjectMaterial("TreeRoom", "StaticUnlit/motdscreen", pinkMaterial);

                string[] wallMonitorNames = { "canyon", "cosmetics", "cave", "forest", "skyjungle" };
                foreach (string name in wallMonitorNames)
                {
                    UpdateWallMonitorMaterial(name, pinkMaterial);
                }

                UpdateChildObjectMaterial("TreeRoom", "GorillaComputerObject/ComputerUI/monitor/monitorScreen", pinkMaterial);
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Error updating board colors: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private static void UpdateChildObjectMaterial(string parentName, string childPath, Material material)
        {
            GameObject parentObject = GameObject.Find($"Environment Objects/LocalObjects_Prefab/{parentName}");
            if (parentObject != null)
            {
                Transform childTransform = parentObject.transform.Find(childPath);
                if (childTransform != null)
                {
                    Renderer childRenderer = childTransform.GetComponent<Renderer>();
                    if (childRenderer != null)
                    {
                        childRenderer.material = material;
                    }
                    else
                    {
                        Debug.LogWarning($"Renderer component not found on child object: {childPath}");
                    }
                }
                else
                {
                    Debug.LogWarning($"Child object not found under parent: {parentName}/{childPath}");
                }
            }
            else
            {
                Debug.LogWarning($"Parent object not found: {parentName}");
            }
        }

        private static void UpdateBoardMaterials(string parentName, string childNameContains, int index, Material material)
        {
            GameObject parentObject = GameObject.Find($"Environment Objects/LocalObjects_Prefab/{parentName}");
            if (parentObject != null)
            {
                bool found = false;
                int count = 0;
                for (int i = 0; i < parentObject.transform.childCount; i++)
                {
                    Transform childTransform = parentObject.transform.GetChild(i);
                    if (childTransform.name.Contains(childNameContains))
                    {
                        count++;
                        if (count == index)
                        {
                            Renderer childRenderer = childTransform.GetComponent<Renderer>();
                            if (childRenderer != null)
                            {
                                childRenderer.material = material;
                                found = true;
                                break;
                            }
                        }
                    }
                }
                if (!found)
                {
                    Debug.LogWarning($"Child object matching criteria not found under parent: {parentName}/{childNameContains}");
                }
            }
            else
            {
                Debug.LogWarning($"Parent object not found: {parentName}");
            }
        }

        private static void UpdateWallMonitorMaterial(string name, Material material)
        {
            GameObject wallMonitor = GameObject.Find($"Environment Objects/LocalObjects_Prefab/TreeRoom/TreeRoomInteractables/Wall Monitors Screens/wallmonitor{name}");
            if (wallMonitor != null)
            {
                Renderer wallRenderer = wallMonitor.GetComponent<Renderer>();
                if (wallRenderer != null)
                {
                    wallRenderer.material = material;
                    try
                    {
                        GorillaLevelScreen levelScreen = wallMonitor.GetComponent<GorillaLevelScreen>();
                        if (levelScreen != null)
                        {
                            levelScreen.goodMaterial = material;
                            levelScreen.badMaterial = material;
                        }
                    }
                    catch (System.Exception ex)
                    {
                        Debug.LogWarning($"Error setting GorillaLevelScreen materials: {ex.Message}");
                    }
                }
                else
                {
                    Debug.LogWarning($"Renderer component not found on wall monitor: {name}");
                }
            }
            else
            {
                Debug.LogWarning($"Wall monitor object not found: {name}");
            }
        }

        private static Color GetBGColor(ExtGradient boardGradient)
        {
            return boardGradient.colors[0].color;
        }
    }
}
