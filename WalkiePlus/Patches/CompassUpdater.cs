extern alias CoreModuleDuplicate;
using System;
using CoreModuleDuplicate::UnityEngine;
using GameNetcodeStuff;
using TMPro;

namespace WalkiePlus.Patches;

public class CompassUpdater
{
    private static readonly string[] Directions = { "N", "E", "S", "W" };

    public static void CompassUpdate()
    {
        GameObject compassParent = GameObject.Find("Systems/UI/Canvas/IngamePlayerHUD/TopLeftCorner/Compass");
        compassParent.SetActive(true);
        GameObject textContainer = GameObject.Find(
            "Systems/UI/Canvas/IngamePlayerHUD/TopLeftCorner/Compass/Container/CardinalDirections/North"
        );

        if (textContainer != null)
        {
            TextMeshProUGUI directionText = textContainer.GetComponent<TextMeshProUGUI>();
            if (directionText != null)
            {
                if (StartOfRound.Instance != null)
                {
                    PlayerControllerB playerController = StartOfRound.Instance.localPlayerController;
                    if (playerController != null)
                    {
                        Vector3 eulerRotation = playerController.playerGlobalHead.rotation.eulerAngles;
                        double axisRotation = eulerRotation.y;
                        int snappedAngle = (int)(Math.Round(axisRotation / 90.0) * 90.0) % 360;
                        //results of this are 0, 90, 180, 270
                        int snappedAngleIndex = snappedAngle / 90;
                        directionText.text = Directions[snappedAngleIndex];
                    }
                    
                }
            }
        }
    }
}