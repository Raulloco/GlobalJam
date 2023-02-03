using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cristal : MonoBehaviour
{
    private bool lighted;
    public bool lighting;
    public GameObject[] ativar;
    // Start is called before the first frame update
    void Start()
    {
        if (lighting) {lighted = true;}
    }

    // Update is called once per frame
    void Update()
    {
        if (lighted&&!lighting) 
        {
            for (int i = 0; i < ativar.Length; i++)
            {
                ativar[i].SetActive(!ativar[i].activeSelf);
            }
            lighting = true;
        }
        if (!lighted && lighting)
        {
            for (int i = 0; i < ativar.Length; i++)
            {
                ativar[i].SetActive(!ativar[i].activeSelf);
            }
            lighting = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Light")) { lighted = true; }
        if (collision.gameObject.CompareTag("Earth")) { lighted = false; }
    }
}
