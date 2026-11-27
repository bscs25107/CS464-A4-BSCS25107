using TMPro;
using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] LevelObjective objective;
    [SerializeField] TMP_Text hint;          // optional
    [SerializeField] EndScreens screens;     // naya field

    public static event Action Reached;
    bool done;

    void OnTriggerEnter(Collider other)
    {
        if (done || !other.CompareTag("Player")) return;

        if (!objective.Complete)
        {
            string msg = $"Collect all spheres first ({objective.Collected}/{objective.Total})";
            Debug.Log(msg);
            if (hint != null) hint.text = msg;
            return;
        }

        done = true;
        Reached?.Invoke();
        Won();
    }

    void Won()
    {
        int level = gameObject.scene.buildIndex;
        float time = Time.timeSinceLevelLoad;
        bool best = SaveData.Record(level, time);
        SaveData.Unlock(level + 1);
        screens.ShowWin(time, best);
    }
}