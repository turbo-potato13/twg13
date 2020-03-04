using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManager : MonoBehaviour
{
    public TextMeshProUGUI unitNumber;
    public TextMeshProUGUI scoreNumber;
    public static int Units = 0;

    public static float MaxUnits = 5;

    public static float score = 1000f;

    public static float scoreToWin = 20000f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        unitNumber.text = "Войска: " + Units + " из " + (int)MaxUnits;
        scoreNumber.text = (int)((score / scoreToWin) * 100) + " процентов планеты освобождено";
        if (score > scoreToWin)
            SceneManager.LoadScene("final");
        if (score < 0)
            SceneManager.LoadScene("gameover");
    }



}
