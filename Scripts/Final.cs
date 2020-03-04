using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Final : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public float time;
    public int sec;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        sec = Mathf.RoundToInt(time);

        if (sec==5)
        {
            Close();
        }
        if (sec==5)
        {
            Open2();
        }
        if (sec == 9)
        {
            Close2();
        }
        if (sec == 9)
        {
            Open3();
        }
        if (sec == 12)
        {
            Close3();
        }
        if (sec == 12)
        {
            Open4();
        }
        if (sec == 15)
        {
            Close4();
        }
        if (sec == 20)
        {
            SceneManager.LoadScene("Menu"); 
        }

    }
    public void Close()
    {
        panel1.gameObject.SetActive(false);
    }
    public void Close2()
    {
        panel2.gameObject.SetActive(false);
    }
    public void Close3()
    {
        panel3.gameObject.SetActive(false);
    }
    public void Close4()
    {
        panel4.gameObject.SetActive(false);
    }
    public void Open2()
    {
        panel2.gameObject.SetActive(true);
    }
     public void Open3()
    {
        panel3.gameObject.SetActive(true);
    }
    public void Open4()
    {
        panel4.gameObject.SetActive(true);
    }
}

