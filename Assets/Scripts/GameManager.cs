using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropDownListLevel;
    // Start is called before the first frame update
    void Start()
    {
        dropDownListLevel = GetComponent<TMP_Dropdown>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene()
    {

        int index = dropDownListLevel.value;
        SceneManager.LoadScene(index + 1);
    }
    public void ApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
