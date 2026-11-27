using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject loadingPanel;
    [SerializeField] Image bar;

    const int MenuIndex = 0;
    const int CreditsIndex = 6;

    public void Load(int index) => StartCoroutine(LoadRoutine(index));

    public void LoadNext()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        Load(current == CreditsIndex ? MenuIndex : current + 1);
    }

    public void Reload() => Load(SceneManager.GetActiveScene().buildIndex);
    public void LoadMenu() => Load(MenuIndex);

    IEnumerator LoadRoutine(int index)
    {
        Time.timeScale = 1f;
        if (loadingPanel != null) loadingPanel.SetActive(true);

        AsyncOperation op = SceneManager.LoadSceneAsync(index);
        while (!op.isDone)
        {
            if (bar != null) bar.fillAmount = Mathf.Clamp01(op.progress / 0.9f);
            yield return null;
        }
    }
}