using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMan : MonoBehaviour
{

    public GameObject[] ativar;
    public bool Virtual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TurnVirtual();
    }

    void TurnVirtual() 
    {
        if (Input.GetKey("e")) 
        {
            
                for (int i = 0; i < ativar.Length; i++)
                {
                    ativar[i].SetActive(true);
                }
                Virtual = true;
            
        } else if(Input.GetKeyUp("e"))
        {
            for (int i = 0; i < ativar.Length; i++)
            {
                ativar[i].SetActive(false);
            }
            Virtual = false;
        }
    }
}
