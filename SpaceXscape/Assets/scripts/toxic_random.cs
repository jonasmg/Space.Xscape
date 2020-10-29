using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class toxic_random : MonoBehaviour
{
    Animator tc_animator;

    //Floating movement variables
    Vector2 origPos = new Vector2();
    Vector2 tempPos = new Vector2();
    public float ampx = 0.4f;
    public float ampy = 0.4f;
    private float freq = 0.5f;
    private bool randAlt;
    private float t;

    //controls for customizing each cloud sprite apart from the pack
    public float ExtraAmpX;
    public float ExtraAmpY;
    public float ExtraWait;

    private void Start()
    {
        //setting floating stuff
        origPos = transform.position;
        randAlt = false;
        t = 0.5f;
       
        //setting animator stuff
        tc_animator = this.gameObject.GetComponent<Animator>();
        tc_animator.SetBool("tc_anim1", false);
        tc_animator.SetBool("tc_anim2", false);
        tc_animator.SetBool("tc_anim3", false);
    }



    //Floating function within Update through position transformations
    private void Update()
    {
        // Float up/down with a Sin()
        tempPos = origPos;
        tempPos.x += Mathf.Sin(Time.fixedTime * Mathf.PI * freq) * (ampx + ExtraAmpX);
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * (freq - 0.3f)) * (ampy + ExtraAmpY);
        transform.position = tempPos;
    }




    // Random wait time to start animation 1i
    public void RandomWaitTime()
    {
        tc_animator.SetBool("tc_anim4", false);
        StartCoroutine(RandomWait());
        tc_animator.SetBool("tc_anim4", false);
    }
    // Coroutine to make it happen
    public IEnumerator RandomWait()
    {
        int randomWait = Random.Range(1, 4);
        //Debug.Log ("waiting " + randomWait + ExtraWait + " seconds"); //debug                
        yield return new WaitForSeconds(randomWait + ExtraWait);
        tc_animator.SetBool("tc_anim4", true);
    }




    //A C T U A L    R A N D O M    F U N C T I O N
    public void RandomAnim()
    {
        tc_animator.SetBool("tc_anim1", false);
        tc_animator.SetBool("tc_anim2", false);
        tc_animator.SetBool("tc_anim3", false);

        //random number here!
        int randomNumber = Random.Range(1, 4);

        //now what to do with it...

        //these bools control the animator component to decide which loop will come next
        if(randomNumber == 1)
        {
            tc_animator.SetBool("tc_anim1", true);
            //Debug.Log("RandomAnim 1");
        }
        else if (randomNumber == 2)
        {
            tc_animator.SetBool("tc_anim2", true);
            //Debug.Log("RandomAnim 2");
        }
        else
        {
            tc_animator.SetBool("tc_anim3", true);
            //Debug.Log("RandomAnim 3");
        }

        //the random number is also used to subtly change the amplitude of the floating movement
        //the randAlt alternates between subtracting and adding, meaning the value stays close to the initial amplitude
        if (randAlt == false)
        {
            if (randomNumber ==1 && ampx >= 0.2f)
            {
                ampx = Mathf.Lerp(ampx, ampx - 0.1f, t);
            }

            else if (randomNumber == 2 && ampy >= 0.2f)
            {
                ampy = Mathf.Lerp(ampy, ampy - 0.1f, t);
            }

            else if (randomNumber == 3 && ampx >= 0.2f && ampy >= 0.2f)
            {
                ampx = Mathf.Lerp(ampx, ampx - 0.1f, t);
                ampy = Mathf.Lerp(ampy, ampy - 0.1f, t);
            }

            randAlt = true;
        }
        else
        {
            if (randomNumber == 1 && ampx <= 0.6f)
            {
                ampx = Mathf.Lerp(ampx, ampx + 0.1f, t);
            }

            else if (randomNumber == 2 && ampy <= 0.6f)
            {
                ampy = Mathf.Lerp(ampy, ampy + 0.1f, t);
            }
           
           else if (randomNumber == 3 && ampx <= 0.6f && ampy <= 0.6f)
            {
                ampx = Mathf.Lerp(ampx, ampx + 0.1f, t);
                ampy = Mathf.Lerp(ampy, ampy + 0.1f, t);
            }
           
            randAlt = false;
        }
    }



    //Resets the bools for between 1o and 1i animations (as in when cloud disappears and reappears).
    //Otherwise, the first animation or two would be skipped
    public void RandomReset()
    {
        tc_animator.SetBool("tc_anim1", false);
        tc_animator.SetBool("tc_anim2", false);
        tc_animator.SetBool("tc_anim3", false);

    }
}