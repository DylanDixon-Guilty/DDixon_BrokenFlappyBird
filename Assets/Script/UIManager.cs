using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    public GameObject StartScreen;
    public GameObject ReadyScreen;
    public GameObject GameOverScreen;
    public GameObject ScoreUI;

    /// <summary>
    /// When passing through a Pipe, the score will update by 1.
    /// </summary>
    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
    }

    /// <summary>
    /// When game begins, show the the Start screen and no other screen
    /// </summary>
    public void ShowStart()
    {
        StartScreen.SetActive(true);
        ReadyScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        ScoreUI.SetActive(false);
    }

    /// <summary>
    /// When player presses Start show the ReadyScreen and no other screen
    /// </summary>
    public void ShowReady()
    {
        StartScreen.SetActive(false);
        ReadyScreen.SetActive(true);
        GameOverScreen.SetActive(false);
    }

    /// <summary>
    /// When player presses the Tap button, show ScoreUI and no other screen
    /// </summary>
    public void HideReady()
    {
        ReadyScreen.SetActive(false);
        ScoreUI.SetActive(true);
    }

    /// <summary>
    /// When player dies, show GameOver Screen
    /// </summary>
    public void ShowGameOver()
    {
        GameOverScreen.SetActive(true);
    }


}
