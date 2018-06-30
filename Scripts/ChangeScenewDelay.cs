using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScenewDelay : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(LoadAfterDelay("Map_Hosp2"));
    }

    IEnumerator LoadAfterDelay(string levelName)
    {
        yield return new WaitForSeconds(10); // wait 10 seconds
        SceneManager.LoadScene(levelName);
    }

}
