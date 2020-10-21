using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameControl : MonoBehaviour
{
    FirstPersonController firstPersonController;
    public GameObject levelComplete, levelPaused, consoleLine, timeObject, point;
    Text time, text;
    int gameTime, pauseTime = 0, resumeTime = 0;
    InputField inputField;
    Menus menus;
    bool console = false, pause = false, game = true;
    void Start()
    {
        menus = new Menus();
        time = timeObject.GetComponent<Text>();
        text = point.GetComponent<Text>();
        inputField = consoleLine.GetComponent<InputField>();
        firstPersonController = new FirstPersonController();
    }

    void Update()
    {
        showTime();
        if (Input.GetKeyDown(KeyCode.Tab) && game == true)
        {
            menus.showPanel(consoleLine, 0);
            console = true;
        }
        if(Input.GetKeyDown(KeyCode.Return) && console && game == true)
        {
            menus.showPanel(consoleLine, 0);
            console = false;
            getCheat(inputField.text);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && game == true)
        {
            pauseGame();
        }

    }

    public void showTime()
    {
        time.text = ((int)Time.timeSinceLevelLoad-gameTime).ToString() + "   ";
    }

    public string getTime()
    {
        return time.text;
    }

    public void finishLevel()
    {
        menus.showPanel(levelComplete, 0);
        text.text = getTime() + "Saniye";
        game = false;
        menus.showPanel(timeObject, 0);
    }

    public void pauseGame()
    {
        if(pause)
        {
            menus.showPanel(levelPaused, 0);
            resumeTime += (int)Time.timeSinceLevelLoad;
            gameTime = resumeTime - pauseTime;
            pause = false;
            menus.showPanel(timeObject, 0);
        }
        else
        {
            menus.showPanel(levelPaused, 0);
            pauseTime += (int)Time.timeSinceLevelLoad;
            pause = true;
            menus.showPanel(timeObject, 0);
            menus.showPanel(consoleLine, 2);
        }
    }

    public void getCheat(string cheat)
    {
        if(cheat == "finishLevel")
        {
            finishLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        finishLevel();
    }
}
