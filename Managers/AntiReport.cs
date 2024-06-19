using Photon.Pun;
using UnityEngine;
using StupidTemplate.Notifications;
using StupidTemplate.Menu;
using System.Collections.Generic;

namespace SurgeX.Managers
{
    internal class AntiReport : MonoBehaviour
    {
        public static List<GorillaScoreBoard> Scoreboards = new List<GorillaScoreBoard>();

        public static void onReported()
        {
            PhotonNetwork.Disconnect();
            Main.RPCProtection();
        }

        public static void Check()
        {
            if (Scoreboards.Count == 0)
            {
                GorillaScoreBoard[] boards = GameObject.FindObjectsOfType<GorillaScoreBoard>();
                Scoreboards.AddRange(boards);
            }

            float maxDistance = 0.35f;

            foreach (GorillaScoreBoard board in Scoreboards)
            {
                foreach (GorillaPlayerScoreboardLine line in board.lines)
                {
                    if (line.linePlayer == NetworkSystem.Instance.LocalPlayer)
                    {
                        foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                        {
                            if (vrrig != GorillaTagger.Instance.offlineVRRig)
                            {
                                if (Vector3.Distance(vrrig.rightHandTransform.position, line.reportButton.transform.position) < maxDistance ||
                                    Vector3.Distance(vrrig.leftHandTransform.position, line.reportButton.transform.position) < maxDistance)
                                {
                                    onReported();
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
