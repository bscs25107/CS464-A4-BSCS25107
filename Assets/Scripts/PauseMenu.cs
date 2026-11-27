using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused;
    public static bool Blocked;      // end screens isse true karte hain

    [SerializeField] GameObject panel;
    [SerializeField] GameObject firstButton;
    [SerializeField] LevelLoader loader;

    void Awake()
    {
        IsPaused = false;
        Blocked = false;
        panel.SetActive(false);
    }

    void Update()
    {
        if (Blocked || !Input.GetKeyDown(KeyCode.Escape)) return;
        if (IsPaused) Resume(); else Pause();

    }
    public static bool EndShown;

    public static void SetFrozen(bool frozen)
    {
        Time.timeScale = frozen ? 0f : 1f;
        AudioListener.pause = frozen;
        IsPaused = frozen;
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
        panel.SetActive(false);
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