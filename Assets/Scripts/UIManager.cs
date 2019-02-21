using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel, endPanel;
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

    public void nextLevel ()
    {
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    public void restart(){
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);        
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
        Debug.Log ("Pressed");
        startPanel.SetActive (false);
        endPanel.SetActive (false);
        Time.timeScale = 1;
    }
}