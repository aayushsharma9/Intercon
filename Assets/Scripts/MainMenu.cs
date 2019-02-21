using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start ()
    {
        Time.timeScale = 1;
    }
    
    public void loadScene (int index)
    {
        SceneManager.LoadScene (index, LoadSceneMode.Single);
    }

    public void Exit ()
    {
        Application.Quit ();
    }
}