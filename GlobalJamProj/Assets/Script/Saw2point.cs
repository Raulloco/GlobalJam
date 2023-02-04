using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw2point : MonoBehaviour
{
    public Transform pos;
    public Transform posB;
    public GameObject saw;
    public float speed;
    public bool Invert;
    public int InvertLado=1;
    //public bool enabler;
    //public Saw2 saww;

    //Vector3 NextPos;

    private void Start()
    {
        //NextPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (saw.transform.position == transform.position) 
        {
            //InverteSpriteRenderer
            if (Invert)
            {
                saw.transform.Rotate(0f, 180f*InvertLado, 0f);
                //saw.transform.localEulerAngles = new Vector3(0f,180f,0f);
            }


            saw.GetComponent<Saw2>().speed = speed;
            saw.GetComponent<Saw2>().passed = true;
            /*if (saw.GetComponent<Saw2>().faller && enabler) 
            { 
                saw.GetComponent<Saw2>().boxcol.enabled=true; 
                //saw.GetComponent<Saw2>().cc = 1f;
                //saw.GetComponent<Saw2>().touched =false;
            }*/
            if (saw.GetComponent<Saw2>().returning)
            {
                saw.GetComponent<Saw2>().NextPos = transform.position;
                saw.GetComponent<Saw2>().BackPos = posB.position;
            }
            else 
            {
                saw.GetComponent<Saw2>().NextPos = pos.position;
                saw.GetComponent<Saw2>().BackPos = transform.position;
            }                
            


        }
    }

 
}
