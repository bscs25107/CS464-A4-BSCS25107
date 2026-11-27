using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EndScreens : MonoBehaviour
{
    [SerializeField] GameObject winPanel, gameOverPanel;
    [SerializeField] Button winFirst, overFirst;
    [SerializeField] TMP_Text winText;
    [SerializeField] AudioClip winClip, loseClip;
    [SerializeField] LevelLoader loader;

    void Awake()
    {
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    public void ShowWin(float time, bool newBest)
    {
        winText.text = $"Time: {time:0.0}s" + (newBest ? "\nNew best!" : "");
        SFXplayer.Instance.Play(winClip);
        Open(winPanel, winFirst);
    }

    public void ShowGameOver()
    {
        SFXplayer.Instance.Play(loseClip);
        Open(gameOverPanel, overFirst);
    }

    void Open(GameObject panel, Button first)
    {
        PauseMenu.Blocked = true;
        PauseMenu.IsPaused = true;
        Time.timeScale = 0f;
        panel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(first.gameObject);
    }

    public void NextLevel() => loader.LoadNext();
    public void Restart() => loader.Reload();
    public void MainMenu() => loader.LoadMenu();
}