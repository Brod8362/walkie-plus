extern alias CoreModuleDuplicate;
using System;
using System.Linq;
using CoreModuleDuplicate::UnityEngine;
using GameNetcodeStuff;
using TMPro;

namespace WalkiePlus.Patches;

public class CompassUpdater
{
    private static readonly string[] Directions = { "N", "E", "S", "W" };

    public static void CompassUpdate()
    {
        if (StartOfRound.Instance is null)
            return;
        
        PlayerControllerB playerController = StartOfRound.Instance.localPlayerController;

        if (playerController is null)
            return;
        
        GameObject compassParent = GameObject.Find("Systems/UI/Canvas/IngamePlayerHUD/TopLeftCorner/Compass");
        if (compassParent is null)
            return;

        
        GrabbableObject heldObject = playerController.ItemSlots[playerController.currentItemSlot];
         
        if (heldObject is WalkieTalkie && heldObject.isBeingUsed)
        {
            GameObject textContainer = GameObject.Find(
                "Systems/UI/Canvas/IngamePlayerHUD/TopLeftCorner/Compass/Container/CardinalDirections/North"
            );
            if (textContainer is null)
                return;
            TextMeshProUGUI directionText = textContainer.GetComponent<TextMeshProUGUI>();
            if (directionText is null)
                return;
            
            Vector3 eulerRotation = playerController.playerGlobalHead.rotation.eulerAngles;
            double axisRotation = eulerRotation.y;
            int snappedAngle = (int)(Math.Round(axisRotation / 90.0) * 90.0) % 360;
            //results of this are 0, 90, 180, 270
            int snappedAngleIndex = snappedAngle / 90;
            directionText.text = Directions[snappedAngleIndex];
            compassParent.SetActive(true);
        }
        else
        {
            compassParent.SetActive(false);
        }

    }
}