using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SceneManager : MonoBehaviour
{
    
    public IEnumerator LoadScene(string sceneName)
    {
        AsyncOperation asyncOper = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOper.isDone)
        {
            yield return null;
        }

    }
}
