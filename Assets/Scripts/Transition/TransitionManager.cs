using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public string startSceneName = string.Empty;
    private CanvasGroup fadeCanvasGroup;
    private bool isFade;
    //Transition
    public const float fadeDuration = 1.5f;

    private void Start()
    {
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        //LoadSaveDataScene("Home");
        //EventHandler.CallAfterSceneLoadedEvent();
        //GameObject.FindWithTag("BoundsConfiner").GetComponent<SwitchBounds>().SwitchConfinerShape(none);
    }


    private void OnTransitionEvent(string sceneToGo, Vector3 positionToGo)
    {
        if (!isFade)
            StartCoroutine(Transition(sceneToGo, positionToGo));
    }

    /// <summary>
    /// �����л�
    /// </summary>
    /// <param name="sceneName">Ŀ�곡��</param>
    /// <param name="targetPosition">Ŀ��λ��</param>
    /// <returns></returns>
    private IEnumerator Transition(string sceneName, Vector3 targetPosition)
    {
        EventHandler.CallBeforeSceneUnloadEvent();
        yield return Fade(1);

        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

        yield return LoadSceneSetActive(sceneName);

        EventHandler.CallAfterSceneLoadedEvent();
        yield return Fade(0);
    }

    /// <summary>
    /// ���س���������Ϊ����
    /// </summary>
    /// <param name="sceneName">������</param>
    /// <returns></returns>
    private IEnumerator LoadSceneSetActive(string sceneName)
    {
        EventHandler.CallBeforeSceneUnloadEvent();
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);

        SceneManager.SetActiveScene(newScene);
            
    }
    /// <summary>
    /// ���뵭������
    /// </summary>
    /// <param name="targetAlpha">1�Ǻڣ�0��͸��</param>
    /// <returns></returns>
    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;

        //Ϊ��ʱ�ڵ����
        fadeCanvasGroup.blocksRaycasts = true;

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;

        // �ж�����floatֵ���޽ӽ�
        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false;

        isFade = false;
    }

    private IEnumerator UnloadScene()
    {
        EventHandler.CallBeforeSceneUnloadEvent();
        yield return Fade(1f);
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        yield return Fade(0);
    }

    private IEnumerator LoadSaveDataScene(string sceneName)
    {
        //yield return Fade(1f);

        if (SceneManager.GetActiveScene().name != "Base")    //����Ϸ������ ����������Ϸ����
        {
            EventHandler.CallBeforeSceneUnloadEvent();
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }

        yield return LoadSceneSetActive(sceneName);
        EventHandler.CallAfterSceneLoadedEvent();
        //yield return Fade(0);
    }
}
