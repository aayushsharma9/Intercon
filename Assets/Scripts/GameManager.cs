using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float switchDelay;
    public GameObject[] stateObjects;
    public GameObject[] gameObjects;
    private bool canSwitch;
    private int currentState;
    private float t;

    private void Start ()
    {
        currentState = 0;
        canSwitch = false;

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
    }

    private void Update ()
    {
        t += Time.deltaTime;

        if (t >= switchDelay)
        {
            canSwitch = true;
        }

        if (canSwitch)
        {
            if (Input.GetButton ("Switch"))
            {
                stateObjects[currentState].SetActive (false);
                gameObjects[currentState].SetActive (false);

                currentState = (currentState + 1) % stateObjects.Length;

                stateObjects[currentState].SetActive (true);
                gameObjects[currentState].SetActive (true);

                canSwitch = false;
                t = 0;
            }
        }
    }
}