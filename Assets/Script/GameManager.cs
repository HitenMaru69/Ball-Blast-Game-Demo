
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public List<Level> levelList; // Scriptable object 

    public int totalObject;
    public int currentObject = 0;
    public int currentLevel = 0;

    public int totalBall;

    [Space(5)]
    [SerializeField] private Canvas loseCanvas;
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Canvas gamePlayCanvas;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

        loseCanvas.enabled = false;
        winCanvas.enabled = false;
        gamePlayCanvas.enabled = true;

        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        totalObject = levelList[currentLevel].ballPrefeb.Count;
        GameObject obj = Instantiate(levelList[currentLevel].firstObject.gameObject,transform.position,Quaternion.identity)
            ;
        Ball ball = obj.GetComponent<Ball>();
        ball.nextPrefeb = levelList[currentLevel].ballPrefeb[0].gameObject;
        totalBall += 1;
        currentObject += 1;

        EventManager.Instance.IncressBallNumber += IncreesCurrentObjectNumber;

        EventManager.Instance.PlayerWin += CheckPlayerWinn;

        EventManager.Instance.PlayerDie += OnPlayerDie;

        Time.timeScale = 0f;
    }


    private void IncreesCurrentObjectNumber(object sender, System.EventArgs e)
    {
        //if(currentObject < totalObject  ) {
        //    currentObject += 1;
        //}
        
    }

    private void OnPlayerDie(object sender, System.EventArgs e)
    {
        loseCanvas.enabled = true;
    }

    private void CheckPlayerWinn(object sender, System.EventArgs e)
    {
        winCanvas.enabled = true;
        currentLevel++;
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
    }

    public GameObject NextObject(int number)
    {


       if (number < totalObject) 
       {
                       
            return levelList[currentLevel].ballPrefeb[number].gameObject; 
       }
        else
        {
            return null;
        }
        
    }
    
    public void PlayBU()
    {
        Time.timeScale = 1f;
        gamePlayCanvas.enabled = false;
    }

    private void OnDisable()
    {
        EventManager.Instance.IncressBallNumber -= IncreesCurrentObjectNumber;
        EventManager.Instance.PlayerWin -= CheckPlayerWinn;
    }

    public bool CheckCurrentObject()
    {
        if (currentObject != totalObject ) return true;
        else return false;

        
    }
}
