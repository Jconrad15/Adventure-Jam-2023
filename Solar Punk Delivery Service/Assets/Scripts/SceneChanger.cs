using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private Animator transition;

    public void LoadMainMenu()
    {
        StartCoroutine(AsyncLoadScene(0));
    }

    public void LoadStartingScene()
    {
        Debug.Log("LoadStartingScene");
        StartCoroutine(AsyncLoadScene(1));
    }

    public void LoadCredits()
    {
        StartCoroutine(AsyncLoadScene(2));
    }

    private IEnumerator AsyncLoadScene(int sceneNumber)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);

        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.

        AsyncOperation asyncLoad =
            SceneManager.LoadSceneAsync(sceneNumber);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
