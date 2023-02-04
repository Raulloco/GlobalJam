using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFernando : MonoBehaviour
{
    public bool wet;
    public bool teste;
    public float speed;
    public GameObject Player;
    private Vector3 cursordirect;
    public Transform cursor;
    public GameObject Seta;
    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player.GetComponent<PlayerMoves>().waterjumped) 
        {
            //transform.position = new Vector3(Player.gameObject.transform.position.x,transform.position.y,transform.position.z);
            transform.position = Player.gameObject.transform.position;
            GetComponent<SpriteRenderer>().enabled = false;
        } else GetComponent<SpriteRenderer>().enabled = true;
        //dire��o do mouse
        cursordirect = new Vector3(Player.transform.position.x - cursor.position.x, Player.transform.position.y - cursor.position.y, 0f);
        //est� na po�a
        if (wet)
        {
            //clicando
            if (Input.GetMouseButton(0))
            {
                teste = true;
                Seta.SetActive(true);

            }
            //n t� clicando
            else
            {
                //soltou
                if (teste)
                {
                    //Player.transform.position= Vector3.MoveTowards(Player.transform.position, cursor.position, speed);
                    Player.GetComponent<Rigidbody2D>().AddForce(-cursordirect*speed);
                    //GetComponent<Rigidbody2D>().velocity = -cursordirect * speed;
                    teste = false;
                    Player.GetComponent<PlayerMoves>().waterjumped = true;
                    Seta.SetActive(false);
                }             
            }
            
        }
        //saiu da po�a
        else teste = false; 

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            wet = true;   
            Player=collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            wet = false;
        }
    }
}
