using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNight : MonoBehaviour
{
    public float time;
    public SpriteRenderer spr;
    public Sprite night;
    public Sprite day;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 60f)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0;
            if (spr.sprite == day)
                spr.sprite = night;
            else
                spr.sprite = day;
        }
    }
}
