using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText, livesText;

    void Start() => ShowScore();

    void OnEnable() => Pickup.Collected += OnPickup;
    void OnDisable() => Pickup.Collected -= OnPickup;

    void OnPickup(Pickup p) => ShowScore();

    void ShowScore()
    {
        if (scoreText != null) scoreText.text = $"Score {Pickup.Score}";
    }

    public void SetLives(int lives)
    {
        if (livesText != null) livesText.text = $"Lives {lives}";
    }
}