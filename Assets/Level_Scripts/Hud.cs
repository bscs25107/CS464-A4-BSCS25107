using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText, livesText;
    int score;

    void Start() => AddScore(0);

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = $"Score {score}";
    }

    public void SetLives(int lives) => livesText.text = $"Lives {lives}";
}