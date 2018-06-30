using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DelayToExit : MonoBehaviour {


    public void Start()
    {
        StartCoroutine(LoadAfterDelay("EndingScene"));
    }

    IEnumerator LoadAfterDelay(string levelName)
    {
        yield return new WaitForSeconds(0); // wait 10 seconds
        SceneManager.LoadScene(levelName);
    }
}



