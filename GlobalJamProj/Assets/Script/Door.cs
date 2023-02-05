using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /*public float aheadx;
    public float upy;
    public float backx;
    public float downy;*/
    public bool vertical;
    public Transform nextroom;
    public Transform backroom;

    public bool MinionLevel;
    public bool Minion;

    public bool follower;
    public Vector2 correction;
    public float cameraspeed;
    public float camerasize;
    [SerializeField] private CameraMove cam;


    //private GameObject player;
    private MainDoors Main;

    private void Start()
    {
        Main = GetComponentInParent<MainDoors>();
    }
    private void Update()
    {
        if (cam.following) 
        {
            cam.MoveCamera(Main.player.transform.position.x+correction.x, Main.player.transform.position.y+correction.y);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (cam.following)
            {
                cam.MoveCamera(nextroom.position.x, nextroom.position.y);
                cam.CameraSpeed += cameraspeed;
                cam.CamSize += camerasize;
            }
            else
            {
                cam.CameraSpeed -= cameraspeed;
                cam.CamSize -= camerasize;
            }
            if (follower)
            {
                cam.following = !cam.following;
                if (cam.following) { Main.player = collision.gameObject; }
                else { Main.player = null; }
                //if (!cam.following) { cam.CameraSpeed += cameraspeed; }
            }
            else
            if(vertical)
            {
                if (collision.transform.position.y < transform.position.y) { cam.MoveCamera(nextroom.position.x, nextroom.position.y); }
                else { cam.MoveCamera(backroom.position.x, backroom.position.y); }
            } 
            else
            if (collision.transform.position.x < transform.position.x) { cam.MoveCamera(nextroom.position.x, nextroom.position.y); }
            else { cam.MoveCamera(backroom.position.x, backroom.position.y); }

        }
        
    }
}
