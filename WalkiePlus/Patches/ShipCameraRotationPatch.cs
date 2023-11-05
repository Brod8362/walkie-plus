using UnityEngine;

namespace WalkiePlus.Patches;

public class ShipCameraRotationPatch
{
    public static void Update()
    {
        GameObject camera = GameObject.Find("Systems/GameSystems/ItemSystems/MapCamera");
        if (camera is not null)
        {
            camera.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }
}