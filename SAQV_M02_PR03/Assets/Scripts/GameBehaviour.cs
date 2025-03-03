using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    public string labelText = "Collect all 4 Energy and win your freedom!";
    public int targetEnemies = 6;
    public bool showWinScreen = false;
    public bool showLoseScreen = false;

    private int _energyMax = 30;
    public int MaxEnergy
    {
        get { return _energyMax; }
        set
        {
            _energyMax = value;
            UnityEngine.Debug.LogFormat("MaxEnergy: {0}", _energyMax);
        }
    }

    private int _energyStored = 30;
    public int Energy
    {
        get { return _energyStored; }

        set
        {
            _energyStored = value;
            UnityEngine.Debug.LogFormat("Energy: {0}", _energyStored);
        }
    }

    private int _playerMaxHP = 10;
    public int MaxHP
    {
        get { return _playerMaxHP; }
        set
        {
            _playerMaxHP = value;
            UnityEngine.Debug.LogFormat("MaxLives: {0}", _playerMaxHP);
        }
    }

    private int _playerHP = 10;
    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            if (value <= 0)
            {
                endGame(false);
            }
            UnityEngine.Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    private int _playerShield = 0;
    public int Shields
    {
        get { return _playerShield; }
        set
        {
            _playerShield = value;
            UnityEngine.Debug.LogFormat("Shields: {0}", _playerShield);
        }
    }

    private int _targetsEliminated = 0;
    public int TargetsEliminated
    {
        get { return _targetsEliminated; }
        set
        {
            _targetsEliminated = value;
            if (_targetsEliminated >= targetEnemies)
            {
                labelText = "You've cleared the Area!";
                endGame(true);
            }
            else
            {
                labelText = "Enemy taken down, only " + (targetEnemies - _targetsEliminated) + " more to go!";
            }
        }
    }

    void endGame(bool winLose)
    {
        if (winLose)
        {
            showWinScreen = true;
        } else
        {
            showLoseScreen = true;
        }
        Time.timeScale = 0f;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health:" + _playerHP + "/" + _playerMaxHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Shield Charges:" + _playerShield);
        GUI.Box(new Rect(20, 80, 150, 25), "Energy Collected: " + _energyStored + "/" + _energyMax);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);
        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                ResetMap();
            }
        }
        if (showLoseScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU LOSE!"))
            {
                ResetMap();
            }
        }
    }

    private static void ResetMap()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
