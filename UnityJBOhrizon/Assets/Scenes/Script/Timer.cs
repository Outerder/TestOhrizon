using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float targetTime = 60.0f;
    [SerializeField]
    Text score;

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

       
        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        score.text = targetTime.ToString();
    }
}

