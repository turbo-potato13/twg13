using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{

    public AudioClip[] AudioArrayChange;
    private AudioSource audiosource;
    public static Sound instance;
    private Slider sla;
    int curlvl;
    private int curaudio = -1;

    // Use this for initialization
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        audiosource = GetComponent<AudioSource>();
        //curlvl = SceneManager.GetActiveScene().buildIndex;
        //AudioClip thisLevelMusic = AudioArrayChange[curlvl];


        //audiosource.clip = thisLevelMusic;
        //audiosource.loop = true;
        //audiosource.Play();
    }





    // Update is called once per frame
    void Update()
    {

        if (sla)
        {
            audiosource.volume = sla.value;
        }
        else
        {
            try
            {
                sla = GameObject.FindObjectOfType<Slider>();
                sla.maxValue = 0.8f;
                sla.value = 0.5f;
            }
            catch { }
        }
        if (SceneManager.GetActiveScene().buildIndex < 6)
        {
            if (!audiosource.isPlaying)
            {
                curaudio++;
                if (curaudio > 4)
                {
                    curaudio = 0;
                }

                AudioClip thisLevelMusic = AudioArrayChange[curaudio];
                audiosource.clip = thisLevelMusic;
                //audiosource.loop = true;
                audiosource.Play();
            }

        }
        //if (SceneManager.GetActiveScene().buildIndex == 6)
        //{
        //    AudioClip thisLevelMusic = AudioArrayChange[5];
        //    audiosource.clip = thisLevelMusic;
        //    audiosource.loop = true;
        //    audiosource.Play();
        //}
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            //if (!audiosource.isPlaying)
            //{
                
                if (curaudio <= 4)
                {
                    curaudio = 5;
                }

                AudioClip thisLevelMusic = AudioArrayChange[curaudio];
                audiosource.clip = thisLevelMusic;
                audiosource.loop = true;
                audiosource.Play();
            //}

        }


    }
}
