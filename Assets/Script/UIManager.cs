using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    public GameObject StartScreen;
    public GameObject ReadyScreen;
    public GameObject GameOverScreen;
    public GameObject ScoreUI;

    public void UpdateScore(int score)
    {
        ScoreText.text = "Score: " + score.ToString();
    }

    public void ShowStart()
    {
        StartScreen.SetActive(true);
        ReadyScreen.SetActive(false);
        GameOverScreen.SetActive(false);
        ScoreUI.SetActive(false);
    }

    public void HideStart()
    {
        StartScreen.SetActive(false);
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
