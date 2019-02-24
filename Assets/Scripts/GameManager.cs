using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Color[] stateBackgroundColors;
    public int maxSwitches;
    public float switchDelay;
    public GameObject[] stateObjects;
    public GameObject[] gameObjects;
    public GameObject switchText, collectedText;
    private UIManager uiManager;
    private AudioSource conMusic, nexMusic;
    private bool canSwitch;
    private int currentState;
    public static int currentStars;
    private int switchCount;
    private float t;

    private void Start ()
    {
        if (!PlayerPrefs.HasKey ("State"))
            PlayerPrefs.SetInt ("State", 0);

        if (!PlayerPrefs.HasKey ("Stars " + "Level " + SceneManager.GetActiveScene ()))
            PlayerPrefs.SetInt ("Stars " + "Level " + SceneManager.GetActiveScene ().buildIndex, 0);

        currentState = PlayerPrefs.GetInt ("State");
        switchCount = 0;

        canSwitch = false;
        Camera.main.backgroundColor = stateBackgroundColors[currentState];

        uiManager = GameObject.Find ("UI Manager").GetComponent<UIManager> ();
        conMusic = GameObject.Find ("ConMusic").GetComponent<AudioSource> ();
        nexMusic = GameObject.Find ("NexMusic").GetComponent<AudioSource> ();

        for (int i = 0; i < stateObjects.Length; i++)
        {
            if (i == currentState)
            {
                stateObjects[i].SetActive (true);
                gameObjects[i].SetActive (true);
            }
            else
            {
                stateObjects[i].SetActive (false);
                gameObjects[i].SetActive (false);
            }
        }

        conMusic.volume = 1 - currentState;
        nexMusic.volume = currentState;

        Time.timeScale = 0;
    }

    private void Update ()
    {
        t += Time.deltaTime;

        if (Resources.FindObjectsOfTypeAll<Pickup> ().Length == 0)
        {
            collectedText.GetComponent<Animator> ().Play ("PopUpAnimation");
        }

        if (t >= switchDelay)
        {
            canSwitch = true;
        }

        if (canSwitch)
        {
            if (Input.GetButton ("Switch"))
            {
                switchCount++;

                switchText.GetComponent<Animator> ().Play ("Switch");
                stateObjects[currentState].SetActive (false);
                gameObjects[currentState].SetActive (false);

                currentState = (currentState + 1) % stateObjects.Length;
                PlayerPrefs.SetInt ("State", currentState);
                stateObjects[currentState].SetActive (true);
                gameObjects[currentState].SetActive (true);
                conMusic.volume = 1 - currentState;
                nexMusic.volume = currentState;
                Camera.main.backgroundColor = stateBackgroundColors[currentState];

                canSwitch = false;
                t = 0;
            }
        }
    }

    public void LevelComplete ()
    {
        currentStars++;

        if (Resources.FindObjectsOfTypeAll<Pickup> ().Length == 0)
        {
            currentStars++;
        }

        if (switchCount <= maxSwitches)
        {
            currentStars++;
        }

        Time.timeScale = 0;
        if (currentStars > PlayerPrefs.GetInt ("Stars " + "Level " + SceneManager.GetActiveScene ().buildIndex))
            PlayerPrefs.SetInt ("Stars " + "Level " + SceneManager.GetActiveScene ().buildIndex, currentStars);
        uiManager.EndPanel ();
    }
}