using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyManager : MonoBehaviour
{

    public static float Money = 0f;

    public static float income = 50f;
    float time = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Money += Time.deltaTime * income;


        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Setting2");
        }
    }
    
}
