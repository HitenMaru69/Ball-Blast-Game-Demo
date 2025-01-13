using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLose : MonoBehaviour
{
   
    public void RestartBU()
    {
        SceneManager.LoadScene("GamePlay");
    }



}
