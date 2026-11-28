using UnityEngine;

public class MenuActions : MonoBehaviour
{
    [SerializeField] LevelLoader loader;

    void Start()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        PauseMenu.IsPaused = false;
    }

    public void Play() => loader.Load(1);
    public void LoadLevel(int buildIndex) => loader.Load(buildIndex);
    public void Credits() => loader.Load(6);

    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}