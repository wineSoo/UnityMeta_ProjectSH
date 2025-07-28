using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public GameObject gameOverText;
    public GameObject ReturnMain;

    

    public static GameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0;
    UIManager uiManager;

    public UIManager UIManager
    {
        get { return uiManager; }
    }
    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        ReturnMain.SetActive(false);
        uiManager.UpdateScore(0);
    }

    public void GameOver()
    {
        
        gameOverText.SetActive(true);
        ReturnMain.SetActive(true); 
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);
        Debug.Log("Score: " + currentScore);
    }
    public void SaveScoreAndReturnToMain()
    {
        PlayerPrefs.SetInt("LastMiniGameScore", currentScore);
        PlayerPrefs.Save();

        SceneManager.LoadScene("SampleScene"); 
    }

}