using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Image fader;
    public Toggle GlobalVolumeToogle;
    public static SceneController Instance;

    public void ToogleFader(bool b) => fader.gameObject.SetActive(b);

    void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //AudioListener.pause = GlobalVolumeToogle.isOn;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        var buffer = 20;
        fader.rectTransform.sizeDelta = new Vector2(Screen.width + buffer, Screen.height + buffer);
        ToogleFader(false);
        DontDestroyOnLoad(gameObject);
    }

    public void Hello(int x)
    {
        Debug.Log("Hello " + x);
    }

    public async UniTask LoadScene(int index, float duration = 1, float waitTime = 2)
    {
        await FadeScene(index, duration, waitTime);
    }

    async UniTask FadeScene(int index, float duration, float waitTime)
    {
        ToogleFader(true);

        await LerpFader(0, 1);

        await UniTask.Delay(TimeSpan.FromSeconds(waitTime), ignoreTimeScale: false);

        var ao = SceneManager.LoadSceneAsync(index);
        while (!ao.isDone)
            await UniTask.Yield();

        await LerpFader(1, 0);

        ToogleFader(false);

        async UniTask LerpFader(int from, int to)
        {
            for (float t = 0; t < 1; t += Time.deltaTime / duration)
            {
                fader.color = new Color(0, 0, 0, Mathf.Lerp(from, to, t));
                await UniTask.Yield();
            }
        }
    }
}
