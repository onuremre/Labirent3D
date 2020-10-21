using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    public AudioSource buttonClick;
    string[] scenes = { "MainMuenu", "Levels", "Level1", "Level2" };
    int activeScene;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
    }

    public void levels(string levelName)
    {
        buttonClick.Play();
        SceneManager.LoadScene(levelName);
        print("hi");
    }

    public void Quit()
    {
        buttonClick.Play();
        Application.Quit();
    }

    public int currentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void nextLevel()
    {
        activeScene = currentLevel();

        try
        {
            buttonClick.Play();
            SceneManager.LoadScene(scenes[activeScene + 1]);
        }
        catch (System.IndexOutOfRangeException)
        {
            SceneManager.LoadScene(scenes[1]);
        }
    }

    public void showPanel(GameObject panel, int mode)
    {   if(panel.activeInHierarchy == false && mode == 0)
        {
            panel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(panel.activeInHierarchy == true && mode == 0)
        {
            panel.SetActive(false);
            Cursor.visible = false;
        }
        else if(mode == 1)
        {
            panel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(mode == 2)
        {
            panel.SetActive(false);
            Cursor.visible = false;
        }
    }
}
