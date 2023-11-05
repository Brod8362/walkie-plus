using UnityEngine;
using TMPro;

namespace WalkiePlus.Patches;

public class CompassUpdater
{
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
                directionText.text = (Time.frameCount % 10).ToString();
            }
        }
    }
}