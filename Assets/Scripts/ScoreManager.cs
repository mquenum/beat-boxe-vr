using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager SharedInstance;
    [SerializeField] private TMP_Text _scoreDisplayer;
    private string _scoreText;
    private int _scoreVal;
    private int _hitCounter;
    private int _combo;

    private void Awake()
    {
        // allow access to this script without having to get a component from a GameObject
        SharedInstance = this;
    }

    private void Start()
    {
        ResetCounters();
        ScoreTextUpdate(_scoreVal);
    }

    // set default values
    private void ResetCounters()
    {
        _hitCounter = 0;
        _combo = 0;
        _scoreVal = 0;
    }

    // add points
    public void ScoreUp(int point)
    {
        _hitCounter++;
        _combo++;
        _scoreVal += point;
        _scoreVal = _scoreVal * _combo;
        ScoreTextUpdate(_scoreVal);
    }

    // remove points in case of miss ro contact
    public void ScoreDown(int damage)
    {
        if (_combo > 0)
        {
            _combo--;
        }
        ScoreTextUpdate(_scoreVal);
    }

    // update the score dipslay
    private void ScoreTextUpdate(int score)
    {
        _scoreText = $"Score: {score.ToString()}, nb of hits: {_hitCounter}, combo: {_combo}";
        _scoreDisplayer.text = _scoreText;
    }
}
