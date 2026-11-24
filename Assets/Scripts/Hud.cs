using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hud : MonoBehaviour
{
    [SerializeField] HealthBar bar;
    [SerializeField] TMP_Text scoreText, livesText, spheresText;
    [SerializeField] GameObject gameOverPanel, winPanel;
    [SerializeField] GameObject gameOverFirst, winFirst;
    [SerializeField] LevelLoader loader;

    Health health;
    PlayerLives lives;
    LevelObjective objective;

    void OnEnable()
    {
        health = FindFirstObjectByType<Health>();
        lives = FindFirstObjectByType<PlayerLives>();
        objective = FindFirstObjectByType<LevelObjective>();

        health.Damaged += OnDamaged;
        lives.LivesChanged += OnLives;
        lives.OutOfLives += ShowGameOver;
        objective.Changed += OnSpheres;
        Pickup.Collected += OnPickup;
        Goal.Reached += ShowWin;

        OnDamaged(health.Current, 100);
        OnLives(lives.Lives);
        scoreText.text = "Score " + Pickup.Score;
        spheresText.text = $"Spheres 0/{objective.Total}";
    }

    void OnDisable()
    {
        health.Damaged -= OnDamaged;
        lives.LivesChanged -= OnLives;
        lives.OutOfLives -= ShowGameOver;
        objective.Changed -= OnSpheres;
        Pickup.Collected -= OnPickup;
        Goal.Reached -= ShowWin;
    }

    void OnDamaged(int cur, int max) => bar.Set(cur, max);
    void OnLives(int n) => livesText.text = "Lives " + n;
    void OnSpheres(int c, int t) => spheresText.text = $"Spheres {c}/{t}";
    void OnPickup(Pickup p) => scoreText.text = "Score " + Pickup.Score;

    void ShowGameOver() => Open(gameOverPanel, gameOverFirst);
    void ShowWin() => Open(winPanel, winFirst);

    void Open(GameObject panel, GameObject first)
    {
        PauseMenu.SetFrozen(true);
        PauseMenu.EndShown = true;
        panel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(first);
    }

    // buttons ke liye
    public void Restart() { PauseMenu.SetFrozen(false); loader.Reload(); }
    public void Next() { PauseMenu.SetFrozen(false); loader.LoadNext(); }
    public void MainMenu() { PauseMenu.SetFrozen(false); loader.LoadMenu(); }
}