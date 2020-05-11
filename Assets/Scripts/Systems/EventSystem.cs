using System;
using System.Collections.Generic;

public class EventSystem
{
    // A store of events times
    private List<KeyValuePair<int, DateTime>> _events;
    private KeyValuePair<int, DateTime>? _currentEvent;

    /// <summary>
    /// Currently only initialises the variables.
    /// </summary>
    public EventSystem()
    {
        _events = new List<KeyValuePair<int, DateTime>>();
        _currentEvent = null;
    }

    /// <summary>
    /// Simple returns the amount of events stored.
    /// </summary>
    /// <returns>The count of events stored</returns>
    public int EventCount()
    {
        return _events.Count;
    }

    /// <summary>
    /// Gets the next event ready, if there is no event it will return false.
    /// </summary>
    /// <returns>If there is another event ready</returns>
    public bool NextEvent()
    {
        _currentEvent = null;
        if (EventCount() == 0)
            return false;

        bool foundEvent = false;

        for (int i = 0; i < EventCount(); i++)
        {
            if (_events[i].Value < DateTime.Now)
            {
                _currentEvent = _events[i];
                foundEvent = true;
                break;
            }
        }

        if (!foundEvent)
            return false;

        return true;
    }

    /// <summary>
    /// Adds a new event to the queue.
    /// </summary>
    /// <param name="id">The id of the event.</param>
    /// <param name="delay">The delay in milliseconds until event is executed.</param>
    public void ScheduleEvent(int id, double delay)
    {
        DateTime time = DateTime.Now + TimeSpan.FromMilliseconds(delay);

        _events.Add(new KeyValuePair<int, DateTime>(id, time));
    }

    /// <summary>
    /// Gets the current event to be executed.
    /// </summary>
    /// <returns>Id of event being executed.</returns>
    public int GetEvent()
    {
        if (!_currentEvent.HasValue)
            return int.MinValue;

        int id = _currentEvent.Value.Key;

        for(int i = 0; i < EventCount(); i++)
            if(_events[i].Key == id)
                _events.RemoveAt(i);

        _currentEvent = null;

        return id;
    }
}
