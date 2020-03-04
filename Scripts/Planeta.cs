using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planeta : MonoBehaviour
{
    
    public float angle = 0f;
    public float speed = 0.4f;
    public float radius = 13.9f;
   public float radius2 = 3.7f;
    public float z = 1.0f;
    public float t = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
  

    
    // Update is called once per frame
    void Update()
    {
       
            angle += Time.deltaTime;
            var x = Mathf.Cos(angle * speed) * radius;
            var y = Mathf.Sin(angle * speed) * radius2;
            transform.position = new Vector2(x, y)+new Vector2(z,t);
        
    }
   
}
