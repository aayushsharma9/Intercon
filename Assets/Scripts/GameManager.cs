    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public float switchDelay;
        public GameObject[] stateObjects;
        public GameObject[] gameObjects;
        public GameObject switchText;
        private bool canSwitch;
        private int currentState;
        private float t;
        private Pickups pickup;
        int nex, con;

        private void Awake()
        {
            pickup = GetComponent<Pickups>();
        }

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
            nex = pickup.nexTotal;
            con = pickup.conTotal;
            Debug.Log("NEX: " + nex + "  CON: " + con);

            t += Time.deltaTime;

            if (t >= switchDelay)
            {
                canSwitch = true;
            }

            if (canSwitch)
            {
                if (Input.GetButton ("Switch"))
                {
                    switchText.GetComponent<Animator> ().Play ("Switch");
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