using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreEvent : MonoBehaviour
{
    public UnityEvent scoreEvent;

    public void RaiseScoreEvent()
    {
        scoreEvent.Invoke();
    }
}
