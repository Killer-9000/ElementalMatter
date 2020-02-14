using UnityEngine;
using Valve.VR.InteractionSystem;

namespace LevelSystem
{
    public abstract class LevelBase : MonoBehaviour
    {
        /// <summary>
        /// This is called when the player teleports to the teleport point.
        /// </summary>
        public abstract void OnPlayerTeleport();

        /// <summary>
        /// This will be called when the level starts to load.
        /// </summary>
        public abstract void OnLoadLevel();

        /// <summary>
        /// Going to do some basic logic.
        /// </summary>
        public virtual void Start()
        {
            if (!this.GetComponent<TeleportPoint>())
                Debug.LogError("\b<LevelSystem\b>This script is supposed to be placed onto a teleport point");
        }

        public virtual void Update()
        {

        }
    }
}