using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    public void NextBU()
    {
        SceneManager.LoadScene("GamePlay");
    }
  
}
