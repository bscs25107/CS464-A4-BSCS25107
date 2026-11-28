using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused;
    public static bool Blocked;

    [SerializeField] GameObject panel;
    [SerializeField] GameObject firstButton;
    [SerializeField] LevelLoader loader;

    [SerializeField] Button pauseButton;
    [SerializeField] Button resumeButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button quitButton;

    void Awake()
    {
        IsPaused = false;
        Blocked = false;
        if (panel != null) panel.SetActive(false);
    }

    void OnEnable()
    {
        if (pauseButton != null) pauseButton.onClick.AddListener(Pause);
        if (resumeButton != null) resumeButton.onClick.AddListener(Resume);
        if (restartButton != null) restartButton.onClick.AddListener(Restart);
        if (quitButton != null) quitButton.onClick.AddListener(QuitToMenu);
    }

    void OnDisable()
    {
        if (pauseButton != null) pauseButton.onClick.RemoveListener(Pause);
        if (resumeButton != null) resumeButton.onClick.RemoveListener(Resume);
        if (restartButton != null) restartButton.onClick.RemoveListener(Restart);
        if (quitButton != null) quitButton.onClick.RemoveListener(QuitToMenu);
    }

    void Update()
    {
        if (Blocked || !Input.GetKeyDown(KeyCode.Escape)) return;
        if (IsPaused) Resume(); else Pause();
    }

    public void Pause()
    {
        IsPaused = true;
        Time.timeScale = 0f;
        AudioListener.pause = true;
        panel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    public void Resume()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        if (panel != null) panel.SetActive(false);
    }

    public void Restart()
    {
        Resume();
        loader.Reload();
    }

    public void QuitToMenu()
    {
        Resume();
        loader.LoadMenu();
    }
}