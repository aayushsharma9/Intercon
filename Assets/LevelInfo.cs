using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    public int buildIndexPointer;
    public Image[] stars;
    public Color starFaded, starComplete;
    private int starCount;

    private void Start ()
    {
        if (!PlayerPrefs.HasKey ("Stars " + "Level " + buildIndexPointer))
            PlayerPrefs.SetInt ("Stars " + "Level " + buildIndexPointer, 0);
        else
        {
            starCount = PlayerPrefs.GetInt ("Stars " + "Level " + buildIndexPointer);
        }

        for (int i = 0; i < 3; i++)
        {
            if (i < starCount)
            {
                stars[i].color = starComplete;
            }
            else
            {
                stars[i].color = starFaded;
            }
        }
    }
}