using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMan : MonoBehaviour
{

    public GameObject[] ativar;
    public GameObject[] desativar;
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
                desativar[i].SetActive(false);
            }
                Virtual = true;
            GetComponent<PlayerMoves>().enabled = false;
            GetComponent<Animator>().SetBool("walking",false);
            
        } else if(Input.GetKeyUp("e"))
        {
            for (int i = 0; i < ativar.Length; i++)
            {
                ativar[i].SetActive(false);
                desativar[i].SetActive(true);
            }
            Virtual = false;
            GetComponent<PlayerMoves>().enabled = true;
        }
    }
}
