using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> listeners = new List<GameEventListener>();

    public void TriggerEvent()
    {
        foreach (GameEventListener listener in listeners)
        {
            listener.OnEventTriggered();
        }
    }

    public void AddListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
    public void ListSubs()
    {
        foreach (var item in listeners)
        {
            Debug.Log(item.gameObject.name);
        }
    }
}
