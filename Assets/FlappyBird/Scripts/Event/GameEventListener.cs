using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [System.Serializable]
    public class EventPair
    {
        public GameEvent Event;
        public UnityEvent Response;
    }
    public List<EventPair> Events = new List<EventPair>();

    private void OnEnable()
    {
        foreach(var e in Events)
        {
            e.Event.RegisterListeners(this);
        }
    }
    private void OnDisable()
    {
        foreach (var e in Events)
        {
            e.Event.UnregisterListener(this);
        }
    }
    public void OnEventRaised(GameEvent e)
    {
        for (int i = 0; i < Events.Count; ++i)
        {
            if (Events[i].Event == e)
            {
                Events[i].Response.Invoke();
                break;
            }
        }
    }
}
