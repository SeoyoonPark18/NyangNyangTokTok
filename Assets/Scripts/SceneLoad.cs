using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    static string nextScene;
    public Slider progressBar;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }

    void Start()
    {

        StartCoroutine(LoadSceneProgress());
    }
    

    IEnumerator LoadSceneProgress()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.9f) //���൵�� 90���� ����
            {
                progressBar.value = op.progress;
            }
            else
            {
                progressBar.value = Mathf.MoveTowards(progressBar.value, 1f, Time.deltaTime);

                if (progressBar.value >= 1f) //�ٰ� �� ����
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
