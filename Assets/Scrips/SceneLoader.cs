using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void gameover()
    {
            SceneManager.LoadScene("Game Over"); //Game Over
    }
    public void restartthegame()
    {
        SceneManager.LoadScene(1);
    }
    public void menu()
    {
        SceneManager.LoadScene(0);
    }
    
}
