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

    [SerializeField] float minLoadTime = 1f;
    IEnumerator LoadRoutine(int index)
    {
        Time.timeScale = 1f;
        if (loadingPanel != null) loadingPanel.SetActive(true);

        AsyncOperation op = SceneManager.LoadSceneAsync(index);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (op.progress < 0.9f || timer < minLoadTime)
        {
            timer += Time.unscaledDeltaTime;
            float real = Mathf.Clamp01(op.progress / 0.9f);
            float shown = Mathf.Clamp01(timer / minLoadTime);
            if (bar != null) bar.fillAmount = Mathf.Min(real, shown);
            yield return null;
        }

        if (bar != null) bar.fillAmount = 1f;
        op.allowSceneActivation = true;
    }
}