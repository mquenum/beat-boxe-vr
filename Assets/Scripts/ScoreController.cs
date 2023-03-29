using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private ScoreEvent _scoreEvent;

    void Start()
    {
        _scoreEvent.scoreEvent.AddListener(OnScoreEvent);
    }

    private void OnScoreEvent()
    {
        Debug.Log("Custom event raised!");
    }
}
