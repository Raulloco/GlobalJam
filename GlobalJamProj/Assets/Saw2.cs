using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw2 : MonoBehaviour
{
    private Collider2D boxcol;
    private SpriteRenderer sprite;

    public float speed;
    public Transform pos0, pos1;
    public Vector3 NextPos;
    public Vector3 BackPos;

    public bool waiter;
    public bool faller;

    public float fall_time;
    public float respawn_time;
    public float TopPositionFromPivot;

    public bool waiting;
    public bool returning;
    public bool passed;

    public bool changecolor;
    public bool respawned;
    public float cc;
    public float timer;
    public bool touched;

    private void Start()
    {
        boxcol = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();

        if (waiter) { waiting = true; }
        if (!waiting) { NextPos = pos1.position; }


        pos0.position = transform.position;
        cc = 1f;
        timer = fall_time;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (changecolor) 
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, cc);
            if (respawned) cc = 1f;
            else
            if (timer > 0f) cc = timer / fall_time;
            else cc = -timer/respawn_time;
        }

        if (!waiting && !returning)//move em frente se n estiver esperando nem retornando
        {
            transform.position = Vector3.MoveTowards(transform.position, NextPos, speed * Time.deltaTime);
        } else if(!waiting && returning)// move pra tras se estiver retornando
        {
            transform.position = Vector3.MoveTowards(transform.position, BackPos, speed * Time.deltaTime); 
        }
        if (faller)
        {
            if (timer < -respawn_time)
            {
                boxcol.enabled = true;
                respawned = true;
            }
            if (touched)
            {
                if (timer < 0f) 
                {
                    Fall();
                    touched = false; 
                }
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (Input.GetKeyDown("e"))
        {
            if (collision.gameObject.CompareTag("Dream") ||
                collision.gameObject.CompareTag("Wake"))
            {
                collision.transform.SetParent(null);
            }
        }
        else

        //coloca player pra andar junto
        if (collision.transform.position.y > transform.position.y + TopPositionFromPivot)
        {
            collision.transform.SetParent(transform);
        }

        if (!touched) { timer = fall_time; }
        touched = true;

        if (faller) 
        {
            changecolor = true;
            respawned = false;
            //Invoke("Fall", fall_time);//se for um faller, retira o collider
            /*if (touched) 
            {
                if(timer < 0f) { Fall(); }
            }*/
        } 
        
        //else

        //se for um waiter vai esperar entrar em colisão
        if (waiter) { waiting = false; }

        //Se estiver retornando ou na posição inicial, vai o proximo local
        if(transform.position == pos0.position||returning) 
        {
            if(!passed)NextPos = pos1.position;
            returning = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);//tira o player

        //Se for um waiter manda para a posição anterior e ativa returning
        if (waiter) 
        { 
            if(!passed)BackPos = pos0.position;            
            returning = true;
        }
    }
    void Fall()
    {
        boxcol.enabled = false;
        //waiting = false;
        //returning = true;
    }

}
