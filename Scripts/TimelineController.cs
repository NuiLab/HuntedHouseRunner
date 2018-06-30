using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.SceneManagement;

public class TimelineController : MonoBehaviour
{

    public List<PlayableDirector> playableDirectors;
    public List<TimelineAsset> timelines;

    void Start()
    {
        Play();
        StartCoroutine(LoadAfterDelay("DisplayGameGoal"));
    }

    IEnumerator LoadAfterDelay(string levelName)
    {
        yield return new WaitForSeconds(22); // wait 10 seconds
        SceneManager.LoadScene(levelName);
    }

    public void Play()
    {
        foreach (PlayableDirector playableDirector in playableDirectors)
        {
            playableDirector.Play();
        }
    }

    public void PlayFromTimelines(int index)
    {
        TimelineAsset selectedAsset;

        if (timelines.Count <= index){
            selectedAsset = timelines[timelines.Count - 1];
        } 
        else 
        {
            selectedAsset = timelines[index];
        }

        playableDirectors[0].Play(selectedAsset);
    }
}