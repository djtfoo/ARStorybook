using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTransition : MonoBehaviour {

    public StoryChapter[] chapters;
    public Animator pageFlipAnimation;

    private int currChapter = -1;

	// Use this for initialization
	void Start () {

        pageFlipAnimation.gameObject.SetActive(false);
        ResetStory();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextChapter()
    {
        StartCoroutine(LoadNextChapter());
    }

    public void ResetStory()
    {
        currChapter = -1;
        foreach (StoryChapter chapter in chapters)
            chapter.gameObject.SetActive(false);
    }

    public IEnumerator LoadNextChapter()
    {
        pageFlipAnimation.gameObject.SetActive(true);

        if (currChapter > -1)
            yield return chapters[currChapter].DeactivateStoryChapter();

        // page flip animation is playing
        if (pageFlipAnimation.GetCurrentAnimatorStateInfo(0).length > pageFlipAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime)
            yield return null;

        currChapter++;
        if (currChapter >= chapters.Length)
            ResetStory();
        else
            yield return chapters[currChapter].ActivateStoryChapter();
    }

}
