using UnityEngine;

namespace LevelSystem.Levels
{
    public class Level1 : MonoBehaviour
    {
        enum Events : int
        {
            EVENT_START = 0,
            EVENT_MESSAGE_DEBUG,
        }

        EventSystem _events;

        public void Start()
        {
            // Initialization
            _events = new EventSystem();

            // Your logic
            _events.ScheduleEvent((int)Events.EVENT_START, 2000);
        }

        public void Update()
        {
            // Cycle through any events to be executed.
            while(_events.NextEvent())
            {
                // Switch to see which event it is.
                switch((Events)_events.GetEvent())
                {
                    case Events.EVENT_START:
                    {
                        _events.ScheduleEvent((int)Events.EVENT_MESSAGE_DEBUG, 5000);
                        Debug.Log("Event system started");
                    } break;
                    case Events.EVENT_MESSAGE_DEBUG:
                    {
                        Debug.Log("Event system ended");
                    } break;
                }
            }
        }
    }
}