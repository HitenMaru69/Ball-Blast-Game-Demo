using System;
using System.Collections;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public event EventHandler FireBullet;

    public event EventHandler IncressBallNumber;

    public event EventHandler  NextBallSpwan;


    public bool iswait = true;


    private void Awake()
    {
        Instance = this;
    }


    public IEnumerator FireBulletEvent()
    {
        iswait = false;
        FireBullet?.Invoke(this, EventArgs.Empty);
        yield return new WaitForSeconds(0.05f);
        iswait = true;
    }

    public void IncreesBallNumberEvent()
    {
        IncressBallNumber?.Invoke(this, EventArgs.Empty);
    }

    public void NextSpwanBallEvent(Ball ball)
    {
        NextBallSpwan?.Invoke(ball, EventArgs.Empty);
        
    }

}
