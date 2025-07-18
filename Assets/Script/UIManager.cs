using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TMP_Text sText;
    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject sUI;

    public void UpdateScore(int score)
    {
        sText.text = score.ToString();
    }

    public void ShowStart()
    {
        screen1.SetActive(true);
        screen2.SetActive(false);
        screen3.SetActive(false);
        sUI.SetActive(false);
    }

    public void HideStart()
    {
        screen1.SetActive(false);
    }

    public void ShowReady()
    {
        screen1.SetActive(false);
        screen2.SetActive(true);
        screen3.SetActive(false);
    }

    public void HideReady()
    {
        screen2.SetActive(false);
        sUI.SetActive(true);
    }

    public void ShowGameOver()
    {
        screen3.SetActive(true);
    }


}
