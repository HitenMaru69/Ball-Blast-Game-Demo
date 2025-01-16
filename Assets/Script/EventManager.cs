using System;
using System.Collections;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public event EventHandler FireBullet;

    public event EventHandler  NextBallSpwan;

    public event EventHandler PlayerDie;

    public event EventHandler PlayerWin;

    public bool iswait = true;


    private void Awake()
    {
        Instance = this;
    }


    public IEnumerator FireBulletEvent()
    {
        iswait = false;
        FireBullet?.Invoke(this, EventArgs.Empty);
        yield return new WaitForSeconds(0.1f);
        iswait = true;
    }


    public void NextSpwanBallEvent(Ball ball)
    {
        NextBallSpwan?.Invoke(ball, EventArgs.Empty);
        
    }

    public void PlayerDieEvent()
    {
        PlayerDie?.Invoke(this, EventArgs.Empty);
    }

    public void PlayerWinEvent()
    {
        PlayerWin?.Invoke(this, EventArgs.Empty);
    }
    

}
