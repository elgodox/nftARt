using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasARManager : MonoBehaviour
{
    public void LoadPreviousScene()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return SceneManager.LoadSceneAsync("WindowsTest", LoadSceneMode.Additive);
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
}
