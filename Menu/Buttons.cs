using PinkMenu.Managers;
using StupidTemplate.Classes;
using StupidTemplate.Mods;
using StupidTemplate.Mods.Plats;
using SurgeX.Helpers;
using SurgeX.Managers;
using SurgeX.Mods;
using static StupidTemplate.Settings;

namespace StupidTemplate.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "Game Mods", method =() => SettingsMods.GameMods(), isTogglable = false, toolTip = "Opens the projectile settings for the menu."},
                new ButtonInfo { buttonText = "Visuals", method =() => SettingsMods.Visuals(), isTogglable = false, toolTip = "Opens the Visuals settings for the menu."},

            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Next Theme", method =() => ThemeManager.NextTheme(), isTogglable = false, toolTip = "Changes to next theme"},
                new ButtonInfo { buttonText = "Last Theme", method =() => ThemeManager.LastTheme(), isTogglable = false, toolTip = "Changes to last theme"},
                
            },

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Scoreboard Changer", method =() => ScoreboardHelper.UpdateBoardColor(), enabled = true, toolTip = "Updates ScoreBoard Color"},
                new ButtonInfo { buttonText = "Sky Changer", method =() => SkyManager.CustomSky(), enabled = true, toolTip = "Updates ScoreBoard Color"},
                new ButtonInfo { buttonText = "AntiReport", method =() => AntiReport.Check(), enabled = true, toolTip = "its antireport"},

                


            },

            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Platforms", method =() => NormalPlatforms.CreatePlatforms(), isTogglable = true, toolTip = "makes Platforms"},
                new ButtonInfo { buttonText = "Sphere Platforms", method =() => SpherePlatforms.CreatePlatforms(), isTogglable = true, toolTip = "makes sphere Platforms"},
                new ButtonInfo { buttonText = "Trigger Platforms", method =() => TriggerPlatforms.CreatePlatforms(), isTogglable = true, toolTip = "makes trigger Platforms"},
                new ButtonInfo { buttonText = "Sphere Trigger Platforms", method =() => SphereTriggerPlatforms.CreatePlatforms(), isTogglable = true, toolTip = "makes sphere trigger Platforms"},
                new ButtonInfo { buttonText = "NoClip Fly", method =() => Movement.NoClipFly(), isTogglable = true, toolTip = "its noclip fly"},
                new ButtonInfo { buttonText = "Fly", method =() => Movement.Fly(), isTogglable = true, toolTip = "its fly"},
                new ButtonInfo { buttonText = "Trigger Fly", method =() => Movement.TriggerFly(), isTogglable = true, toolTip = "its Trigger fly"},
                new ButtonInfo { buttonText = "Bark Fly", method =() => Movement.BarkFly(), isTogglable = true, toolTip = "its bark fly"},
                new ButtonInfo { buttonText = "WASD Fly", method =() => Movement.WASDFly(), isTogglable = true, toolTip = "its WASD fly"},
                new ButtonInfo { buttonText = "Rotate Head X", method =() => Movement.RotateHeadX(), isTogglable = true, toolTip = "Roates Head By X axis"},
                new ButtonInfo { buttonText = "Rotate Head Y", method =() => Movement.RotateHeadY(), isTogglable = true, toolTip = "Roates Head By Y axis"},
                new ButtonInfo { buttonText = "Rotate Head Z", method =() => Movement.RotateHeadZ(), isTogglable = true, toolTip = "Roates Head By Z axis"},
                new ButtonInfo { buttonText = "Fix Head", method =() => Movement.FixHeadRotation(), isTogglable = true, toolTip = "Fixes Head Rotation"},



            },

            new ButtonInfo[] { // Game Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Bug Orbit", method =() => GameMods.BugHalo(), isTogglable = true, toolTip = "makes bug orbit you"},
                new ButtonInfo { buttonText = "Bat Orbit", method =() => GameMods.BatHalo(), isTogglable = true, toolTip = "makes bat orbit you"},
                new ButtonInfo { buttonText = "BeachBall Orbit", method =() => GameMods.BeachBallHalo(), isTogglable = true, toolTip = "makes beach ball orbit you"},
                new ButtonInfo { buttonText = "Grab Bug", method =() => GameMods.GrabBug(), isTogglable = true, toolTip = "Grabs Bug"},
                new ButtonInfo { buttonText = "Grab Bat", method =() => GameMods.GrabBat(), isTogglable = true, toolTip = "Grabs Bat"},
                new ButtonInfo { buttonText = "Grab BeachBall", method =() => GameMods.GrabBall(), isTogglable = true, toolTip = "Grabs Ball"},
                new ButtonInfo { buttonText = "Grab Monsters", method =() => GameMods.GrabMonsters(), isTogglable = true, toolTip = "Grabs Ball"},
                new ButtonInfo { buttonText = "Make Rain", method =() => GameMods.Rain(), isTogglable = true, toolTip = "Makes Rain"},
                new ButtonInfo { buttonText = "Stop Rain", method =() => GameMods.DisableRain(), isTogglable = true, toolTip = "Makes Rain"},
                new ButtonInfo { buttonText = "Rain Buttons", method =() => GameMods.DisableRain(), isTogglable = true, toolTip = "Makes Rain with right primary btn and stops rain with right secondary btn"},
                new ButtonInfo { buttonText = "Set Day", method =() => GameMods.SetDay(), isTogglable = true, toolTip = "Sets Daytime"},
                new ButtonInfo { buttonText = "Set Night", method =() => GameMods.SetNight(), isTogglable = true, toolTip = "Sets Night"},
                new ButtonInfo { buttonText = "Set Afternoon", method =() => GameMods.SetAfternoon(), isTogglable = true, toolTip = "Sets Afternoon"},








            },

            new ButtonInfo[] { // Visuals Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "BoneESP", method =() => Visuals.BoneESP(), isTogglable = true, toolTip = "Its draws bones on players"},
                new ButtonInfo { buttonText = "Tracers", method =() => Visuals.Tracers(), isTogglable = true, toolTip = "makes tracers"},
                new ButtonInfo { buttonText = "BoxESP", method =() => Visuals.BoxESP(), isTogglable = true, toolTip = "Draws a Box around the players"},
                new ButtonInfo { buttonText = "Hollow BoxESP", method =() => Visuals.HollowBoxESP(), isTogglable = true, toolTip = "Draws a box around the players"},
                new ButtonInfo { buttonText = "HeadESP", method =() => Visuals.SphereESPP(), isTogglable = true, toolTip = "Draws a sphere around the players"},
                new ButtonInfo { buttonText = "CapsuleESP", method =() => Visuals.CapsuleESPP(), isTogglable = true, toolTip = "Draws a capsule around the players"},
                new ButtonInfo { buttonText = "Arrow ESP", method =() => Visuals.AnimatedSphere(), isTogglable = true, toolTip = "Draws a capsule around the players"},


            },
        };
    }
}
