using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Change : MonoBehaviour
{
    public TextMeshProUGUI one;
    public TextMeshProUGUI two;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void cheche()
    {
        one.enabled = false;
        two.enabled = true;
    }
}
