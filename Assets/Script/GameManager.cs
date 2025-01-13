
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public List<Level> levelList;

    public int totalObject;
    public int currentObject = 0;
    public int currentLevel = 0;

    public int totalBall;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        totalObject = levelList[currentLevel].ballPrefeb.Count;
        GameObject obj = Instantiate(levelList[currentLevel].firstObject.gameObject,transform.position,Quaternion.identity)
            ;
        Ball ball = obj.GetComponent<Ball>();
        ball.nextPrefeb = levelList[currentLevel].ballPrefeb[currentObject].gameObject;
        totalBall += 1;
        currentObject += 1;

        EventManager.Instance.IncressBallNumber += IncreesCurrentObjectNumber;

        EventManager.Instance.PlayerWin += CheckPlayerWinn;
    }



    private void IncreesCurrentObjectNumber(object sender, System.EventArgs e)
    {
        if(currentObject < totalObject  ) {
            currentObject += 1;
        }
        
    }

    private void CheckPlayerWinn(object sender, System.EventArgs e)
    {
        // Player Winn Functionality

        Debug.Log("Player Winn");
    }

    public GameObject NextObject()
    {


       if (currentObject < totalObject)
       {
                       
            return levelList[currentLevel].ballPrefeb[currentObject].gameObject;
       }

        else
        {
            return null;
        }
        
    }

    private void OnDisable()
    {
        EventManager.Instance.IncressBallNumber -= IncreesCurrentObjectNumber;
    }

    public bool CheckCurrentObject()
    {
        if (currentObject != totalObject ) return true;
        else return false;

        
    }
}
