using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public GameObject Player;
    public Transform cursor;
    public float speed;
    private Vector3 cursordirect;
    private bool touched;

    private int rotated;
    private float rotbkp;
    //private bool floating;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(8, 11, true);
        Physics2D.IgnoreLayerCollision(6, 11, true);
        Physics2D.IgnoreLayerCollision(8, 10, true);
        cursordirect = new Vector3(transform.position.x - cursor.position.x, transform.position.y - cursor.position.y, 0f);
    }
    private void OnMouseDown()
    {
        touched = false;
        rotbkp = Player.transform.localEulerAngles.y;
    }
    private void OnMouseDrag()
    {
        //transform.position = Vector3.MoveTowards(transform.position,cursor.position,speed*Time.deltaTime);
        if (!touched&&!Player.GetComponent<PlayerMoves>().waterjumped)
        {
            GetComponent<Rigidbody2D>().velocity = -cursordirect * speed;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            //floating = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            gameObject.layer = 8;
            Physics2D.IgnoreLayerCollision(8, 9, true);

            Player.GetComponent<PlayerMoves>().enabled = false;
            Player.GetComponent<Animator>().SetBool("Earthing", true);
            if (transform.position.x < Player.transform.position.x&&rotated!=1)
            {
                Player.transform.localEulerAngles=new Vector3(Player.transform.localEulerAngles.x, -180f, Player.transform.localEulerAngles.z); 
                rotated = 1;
            }
            else if(transform.position.x > Player.transform.position.x && rotated!=-1)
            {
                rotated = -1;
                Player.transform.localEulerAngles = new Vector3(Player.transform.localEulerAngles.x, 0f, Player.transform.localEulerAngles.z);
            }
        }
    }
    private void OnMouseUp()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        //gameObject.layer = 6;
        Player.GetComponent<PlayerMoves>().enabled = true;
        Player.GetComponent<Animator>().SetBool("Earthing", false);
        if (rotated != 0) {rotated = 0; Player.transform.localEulerAngles = new Vector3(Player.transform.localEulerAngles.x, rotbkp, Player.transform.localEulerAngles.z); }
        //floating = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.layer == 6|| collision.gameObject.layer == 8) )//&& !floating) 
        { 
            gameObject.layer = 6;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX| RigidbodyConstraints2D.FreezeRotation;
            Physics2D.IgnoreLayerCollision(8, 9, false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 8 || collision.gameObject.layer == 12)
        {
            touched = true;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            //gameObject.layer = 6;
            Player.GetComponent<Animator>().SetBool("Earthing", false);
            if (rotated == 1) { rotated = 0; Player.transform.localEulerAngles = new Vector3(Player.transform.localEulerAngles.x, rotbkp, Player.transform.localEulerAngles.z); }
            Player.GetComponent<PlayerMoves>().enabled = true;
            //floating = false;
        }
    }
}
