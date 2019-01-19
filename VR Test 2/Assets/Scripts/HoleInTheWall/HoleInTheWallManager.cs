using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleInTheWallManager : MonoBehaviour {

    enum ManagerStates
    {
        countingDown,
        doingLevel,
        paused
    }

    ManagerStates state = ManagerStates.countingDown;

    public float timeBetweenLevels;
    public FloatVariable counter;
    int counterRounded;
    int prevCounterRounded;

    public GameEvent changeCounter;
    public GameEvent beginLevel;
    

	// Use this for initialization
	void Start () {
        BeginCountDown();

    }
	
	// Update is called once per frame
	void Update () {
        RunStates();
	}

    void RunStates()
    {
        CountDown();
        DoingLevel();
    }


    void BeginCountDown()
    {
        counter.Value = timeBetweenLevels;
        counterRounded = (int) Mathf.Ceil(counter.Value);
        state = ManagerStates.countingDown;
    }

    void CountDown()
    {
        if(state == ManagerStates.countingDown)
        {
            counter.Value -= Time.deltaTime;
            counterRounded = (int)Mathf.Ceil(counter.Value);

            if(prevCounterRounded != counterRounded)
            {
                changeCounter.Raise();
                prevCounterRounded = counterRounded;
            }

            if(counterRounded <= 0)
            {
                BeginLevel();
            }

        }
    }

    void BeginLevel()
    {
        state = ManagerStates.doingLevel;
        beginLevel.Raise();
    }

    void DoingLevel()
    {

    }
}
