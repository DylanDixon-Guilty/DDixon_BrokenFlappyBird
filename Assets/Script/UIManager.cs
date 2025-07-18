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
    /// <param name="score"></param>
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

    public void ShowReady()
    {
        StartScreen.SetActive(false);
        ReadyScreen.SetActive(true);
        GameOverScreen.SetActive(false);
    }

    public void HideReady()
    {
        ReadyScreen.SetActive(false);
        ScoreUI.SetActive(true);
    }

    public void ShowGameOver()
    {
        GameOverScreen.SetActive(true);
    }


}
