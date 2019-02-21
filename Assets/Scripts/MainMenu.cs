using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void loadScene (int index)
    {
        SceneManager.LoadScene (index, LoadSceneMode.Single);
    }

    public void Exit ()
    {
        Application.Quit ();
    }
}