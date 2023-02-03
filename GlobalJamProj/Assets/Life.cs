using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float life=2;
    public bool enemy;
    public float recuoy;
    public float recuox;
    private float recuoxbkp;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike")) 
        {
            if (collision.gameObject.transform.position.x > transform.position.x)
            { recuoxbkp = -recuox; }
            else { recuoxbkp = recuox; }
            life -= collision.gameObject.GetComponent<Damage>().damage;
            GetComponent<Rigidbody2D>().AddForce(new Vector3(recuoxbkp, recuoy, 0),ForceMode2D.Impulse);
        }
        
    }
}
