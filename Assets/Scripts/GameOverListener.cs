using UnityEngine;

public class GameOverListener : MonoBehaviour
{
    [SerializeField] PlayerLives lives;
    [SerializeField] EndScreens screens;

    void OnEnable() => lives.OutOfLives += OnOutOfLives;
    void OnDisable() => lives.OutOfLives -= OnOutOfLives;
    void OnOutOfLives() => screens.ShowGameOver();
}