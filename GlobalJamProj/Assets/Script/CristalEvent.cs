using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalEvent : MonoBehaviour
{
    public GameObject Cristal;
    public bool SawReturn;
    public bool CristalAlredyLit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SawReturn) 
        {
            if(CristalAlredyLit) GetComponent<Saw2>().returning = !Cristal.GetComponent<cristal>().lighting;
            else GetComponent<Saw2>().returning = Cristal.GetComponent<cristal>().lighting;
        }
    }
}
