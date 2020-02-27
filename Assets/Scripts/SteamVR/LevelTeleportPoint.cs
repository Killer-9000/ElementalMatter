using UnityEngine;
using Valve.VR.InteractionSystem;

public abstract class LevelTeleportPoint : TeleportPoint
{
    // Constructor called as soon as added
    public LevelTeleportPoint()
    {
        base.locked = true;

        base.title = "Level {0} Teleport Point";

        //Dividing by 255 to make it go from 0 to 1 insead of 0 to 255
        base.titleVisibleColor = new Color(35, 166, 201, 128) / 255;
        base.titleHighlightedColor = new Color(35, 116, 201, 128) / 255;
        base.titleLockedColor = new Color(201, 141, 35, 128) / 255;
    }

    public abstract void DealWithTeleport();
}
