using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool wet;
    public bool teste;
    public float speed;
    public GameObject Player;
    private Vector3 cursordirect;
    public Transform cursor;
    public GameObject Seta;
    public GameObject PlayerLight;
    public GameObject Waterlight;
    //private Vector3 playerposcorrection;
    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        //Segue a posi��o do player
        if (Player.GetComponent<PlayerMoves>().waterjumped)
        {
            //transform.position = new Vector3(Player.gameObject.transform.position.x,transform.position.y,transform.position.z);
            //transform.position = new Vector3(Player.gameObject.transform.position.x, Player.gameObject.transform.position.y-playerposcorrection.y, transform.position.z);
            //GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<Collider2D>().enabled = false;
            Player.GetComponent<Animator>().SetBool("Waterexplode", false);
        }
        else
        { 
            //GetComponent<SpriteRenderer>().enabled = true; 
            //GetComponent<Collider2D>().enabled = true;
            //transform.SetParent(null);
            Player.GetComponent<Animator>().SetBool("Waterexplode", true);
            Player.GetComponent<Animator>().SetBool("Waterbubble", false);
        }
        //dire��o do mouse
        cursordirect = new Vector3(Player.transform.position.x - cursor.position.x, Player.transform.position.y - cursor.position.y, 0);
        //est� na po�a
        if (wet)
        {
            //clicando
            if (Input.GetMouseButton(0))
            {
                teste = true;
                Seta.SetActive(true);
                Player.GetComponent<Animator>().SetBool("Watercharging", true);
                Player.GetComponent<PlayerMoves>().moveDirection = 0;
                Player.GetComponent<PlayerMoves>().enabled = false;
                Player.GetComponent<VirtualMan>().enabled = false;
                PlayerLight.SetActive(false);
                Waterlight.SetActive(true);

            }
            //n t� clicando
            else
            {
                //soltou
                if (teste)
                {
                    //Player.transform.position= Vector3.MoveTowards(Player.transform.position, cursor.position, speed);
                    Player.GetComponent<Rigidbody2D>().AddForce(-cursordirect * speed);
                    //GetComponent<Rigidbody2D>().velocity = -cursordirect * speed;
                    teste = false;
                    Player.GetComponent<PlayerMoves>().waterjumped = true;
                    Seta.SetActive(false);
                    //transform.SetParent(Player.transform, true);
                    Player.GetComponent<Animator>().SetBool("Waterbubble", true);
                    Invoke("fallanim", Player.GetComponent<PlayerMoves>().FallAnimTimer);
                }
            }

        }
        //saiu da po�a
        else { teste = false; }
        

    }
    void fallanim() 
        {
            Player.GetComponent<PlayerMoves>().FallAnim();
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wet = true;
            Player =collision.gameObject;
            Player.GetComponent<PlayerMoves>().wet = true;
            //playerposcorrection = new Vector3(0, Player.gameObject.transform.position.y-transform.position.y , 0);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            wet = false;
            Player.GetComponent<PlayerMoves>().enabled = true;
            Player.GetComponent<PlayerMoves>().wet = false;
            Seta.SetActive(false);
            Player.GetComponent<Animator>().SetBool("Watercharging", false);
        }
    }
}
