using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Current { get; private set; }

    public int Points { get; set; }
    public int Lives { get; set; }

    [SerializeField]
    private int maxLives = 3;
    public int MaxLives
    {
        get { return maxLives; }
    }


    // Use this for initialization
    private void OnEnable()
    {
        if (Current != null)
        {
            Debug.Log("You should never have more than one game manager!");
        }
        Current = this;

        Time.timeScale = 1;
        Lives = maxLives;
    }
}
