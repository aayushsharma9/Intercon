using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel, endPanel, pausePanel;
    public Color starFaded, starComplete;
    public TextMeshProUGUI optionalText;
    public Image[] stars;

    private void Start ()
    {
        startPanel.SetActive (true);
        endPanel.SetActive (false);
        optionalText.text = "OPTIONAL : Complete the level in at most " +
            GameObject.Find ("Game Manager").GetComponent<GameManager> ().maxSwitches +
            " switches.";
    }

    private void Update ()
    {
        if (Input.GetKeyDown (KeyCode.Escape))
        {
            pausePanel.SetActive (!pausePanel.activeSelf);
        }
    }

    public void loadScene (int index)
    {
        SceneManager.LoadScene (index, LoadSceneMode.Single);
    }
    
    public void nextLevel ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1, LoadSceneMode.Single);
    }

    public void restart ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex, LoadSceneMode.Single);
    }

    public void EndPanel ()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i <= (GameManager.currentStars - 1))
            {
                stars[i].color = starComplete;
            }
            else
            {
                stars[i].color = starFaded;
            }
        }

        endPanel.SetActive (true);
    }

    public void closeAll ()
    {
        startPanel.SetActive (false);
        endPanel.SetActive (false);
        pausePanel.SetActive (false);
        Time.timeScale = 1;
    }
}