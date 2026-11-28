using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] LevelLoader loader;
    [SerializeField] Button[] buttons;    // 5, order Level1..Level5
    [SerializeField] TMP_Text[] labels;   // 5, har button ka label

    void OnEnable()
    {
        int unlocked = SaveData.GetUnlocked();

        for (int i = 0; i < buttons.Length; i++)
        {
            int level = i + 1;
            bool open = level <= unlocked;

            buttons[i].interactable = open;

            string best = SaveData.HasBest(level)
                ? $"Best {SaveData.GetBest(level):0.0}s"
                : "No time yet";
            labels[i].text = open ? $"Level {level}\n{best}" : $"Level {level}\nLocked";

            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => loader.Load(level));
        }

        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
    }
}