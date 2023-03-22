using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBuilder : MonoBehaviour
{
    [SerializeField] List<Scene> _scenes;
    private void Awake()
    {
        /*SceneManager.LoadScene("[2023-03-16] SceneAdditiveTest - Player - 01", LoadSceneMode.Additive);
        Debug.Log(SceneManager.GetSceneByPath("Scenes").name);*/
        /*if (_scenes.Count > 0)
        {
            foreach (Scene scene in _scenes)
            {
                Debug.Log(scene.name);
                SceneManager.LoadScene(scene.name, LoadSceneMode.Additive);
            }
        }*/
    }
}
