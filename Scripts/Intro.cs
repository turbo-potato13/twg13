using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {


            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("intro2");
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {


            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("Game");
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {


            if (Input.GetKeyDown(KeyCode.Space))
            {
                panel.SetActive(!panel.activeSelf);
            }

        }
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
