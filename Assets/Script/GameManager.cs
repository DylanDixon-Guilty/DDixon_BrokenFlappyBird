using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Bird bird;
    public PipeSpawner pipeSpawner;
    public UIManager uiManager;
    private int score = 0;

    void Awake()
    {
        Instance = this;
        pipeSpawner.enabled = false;
    }

    void Start()
    {
        uiManager.ShowStart();
        bird.gameObject.SetActive(false);
    }

    public void ResetGame()
    {
        Pipe[] pipes = FindObjectsByType<Pipe>(FindObjectsSortMode.None);
        foreach(Pipe pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }
        score = 0;
        uiManager.UpdateScore(score);

        uiManager.ShowStart();
        pipeSpawner.enabled = false;
        bird.ResetBird();
        bird.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReadyGame()
    {
        uiManager.HideStart();
        uiManager.ShowReady();
        bird.ResetBird();
        bird.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        score = 0;
        uiManager.HideReady();
        pipeSpawner.enabled = true;
        bird.StartGame();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        uiManager.ShowGameOver();
    }

    public void IncreaseScore()
    {
        score++;
        uiManager.UpdateScore(score);
    }
}
