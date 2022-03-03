using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAnimation : MonoBehaviour
{
    [SerializeField]
    Animator test = null;

    float RunBlend = 0.0f;

    float speed = 1.0f;

    enum animationState
    {
        idle,
        move
    }

    animationState state = animationState.move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {// swap to idle
            test.SetInteger("State", 1);

            //test.Play("idle");
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {//swap to run
            test.SetInteger("State", 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {//swap to run
            state = animationState.move;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {//swap to run
            state = animationState.idle;
        }

        if(state == animationState.idle)
        {//need to decrease run blend
            RunBlend = RunBlend + speed * Time.deltaTime;
        }
        else if (state == animationState.move)
        {//need to increase run blend
            RunBlend = RunBlend + (-speed) * Time.deltaTime;
        }

        RunBlend = Mathf.Clamp01(RunBlend);
        test.SetFloat("RunBlend", RunBlend);
    }
}
