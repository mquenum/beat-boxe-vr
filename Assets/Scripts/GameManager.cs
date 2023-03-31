using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropDownListLevel;
    /*[SerializeField] private InputActionReference menuInputActionReference;
    [SerializeField] private GameObject _OptionMenu;
    private bool _menuIsShown = false;

    private void OnEnable()
    {
        menuInputActionReference.action.started += MenuPressed;
    }

    private void OnDisable()
    {
        menuInputActionReference.action.started -= MenuPressed;

    }*/

    /*private void MenuPressed(InputAction.CallbackContext context)
    {
        Debug.Log("MenuPressed!");

        if (!_menuIsShown)
        {
            PauseGame();
            _OptionMenu.SetActive(true);
            _menuIsShown = true;
        } else
        {
            _OptionMenu.SetActive(false);
            ResumeGame();
            _menuIsShown = false;
        }
    }*/

    public void LoadScene()
    {
        int index = dropDownListLevel.value;
        SceneManager.LoadScene(index);
    }

    public void LoadSceneAt(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    /*public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }*/
}
