using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void GameScene()
    {
        SceneManager.LoadScene("Aldea");
        Time.timeScale = 1;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelLoad(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Over()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayerPrefs.DeleteKey("PlayerDamage");
        PlayerPrefs.DeleteKey("PlayerMaxDamage");
        PlayerPrefs.Save();
        if (scene.name == "MainMenu")
        {
            DamageManager.Damage = 3;
        }

    }
}