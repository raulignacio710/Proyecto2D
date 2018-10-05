using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public void gameover()
    {
       Invoke("restart",2f);
    }
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
