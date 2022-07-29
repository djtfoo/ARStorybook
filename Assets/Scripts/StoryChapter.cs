using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryChapter : MonoBehaviour {

    private Animator animator = null;

	// Use this for initialization
	void Start () {
        animator = gameObject.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public IEnumerator ActivateStoryChapter()
    {
        float scale = 0f;
        gameObject.SetActive(true);
        if (animator)
            animator.enabled = false;

        while (scale < 1f)
        {
            scale += Time.deltaTime;
            if (scale > 1f)
                scale = 1f;

            transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }

        if (animator)
            animator.enabled = true;
    }

    public IEnumerator DeactivateStoryChapter()
    {
        float scale = 1f;

        while (scale > 0f)
        {
            scale -= Time.deltaTime;
            if (scale < 0f)
                scale = 0f;

            transform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }

        gameObject.SetActive(false);

        if (animator)
            animator.enabled = false;
    }

    //public IEnumerator ScaleObject(bool up)
    //{
    //    float scale = transform.localScale.x;
    //    gameObject.SetActive(true);
    //
    //    if (up)
    //    {
    //        while (scale < 1f)
    //        {
    //            scale += Time.deltaTime;
    //            if (scale > 1f)
    //                scale = 1f;
    //
    //            transform.localScale = new Vector3(scale, scale, scale);
    //            yield return null;
    //        }
    //    }
    //    else
    //    {
    //        while (scale > 0f)
    //        {
    //            scale -= Time.deltaTime;
    //            if (scale < 0f)
    //                scale = 0f;
    //
    //            transform.localScale = new Vector3(scale, scale, scale);
    //            yield return null;
    //        }
    //
    //        gameObject.SetActive(false);
    //    }
    //}

}
