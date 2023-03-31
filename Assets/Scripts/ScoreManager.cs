using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager SharedInstance;
    [SerializeField] private TMP_Text _scoreDisplayer;
    [SerializeField] private CameraShake _cameraShake;

    private string _scoreText;
    private int _scoreVal;
    private int _hitCounter;
    private int _combo;
    private int _miss;
    private Vibrate _vibrate;


    private void Awake()
    {
        // allow access to this script without having to get a component from a GameObject
        SharedInstance = this;
    }

    private void Start()
    {
        ResetCounters();
        ScoreTextUpdate(_scoreVal);
        _vibrate = Vibrate.SharedInstance;
    }

    // set default values
    private void ResetCounters()
    {
        _hitCounter = 0;
        _combo = 0;
        _scoreVal = 0;
        _miss = 0;
    }

    // add points
    public void ScoreUp(int point)
    {
        _hitCounter++;
        _combo++;
        _scoreVal += point;

        _vibrate.VibrateControllers(0.5f, 0.1f);

        ScoreTextUpdate(_scoreVal);
    }

    // remove points in case of miss ro contact
    public void ScoreDown(int damage, int combo)
    {
        if (_combo > 0) { _combo -= combo; }
        if (_scoreVal > 0) { _scoreVal -= damage; }
        _miss++;

        _vibrate.VibrateControllers(0.9f, 0.25f);
        _cameraShake.ShakeCamera(0.25f, 0.07f);
        ScoreTextUpdate(_scoreVal);
    }

    // update the score dipslay
    private void ScoreTextUpdate(int score)
    {
        _scoreText = $"Score: {score.ToString()}, nb of hits: {_hitCounter}, combo: {_combo}, misses: {_miss}";
        _scoreDisplayer.text = _scoreText;
    }
}
