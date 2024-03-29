using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public int maxjumpCount = 1;
    public Transform groundCheck;
    public LayerMask groundObjects;
    //public LayerMask OtherWorld;
    public Vector2 boxSize = new(1, 1);

    private int jumpCount;
    private Rigidbody2D rb;
    public bool isFacingRight = true;
    public float moveDirection;
    private bool isJumping = false;
    private bool isGrounded;
    public bool waterjumped;
    public bool wet;

    public float FallAnimTimer = 0.1f;

    private Animator anim;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Tratando os inputs do player
        ProcessarInputs();

        //Animar
        Animar();


    }


    private void FixedUpdate()
    {
        //verifica se o player est� no ch�o
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0f, groundObjects);

        if (isGrounded)
        {
            jumpCount = maxjumpCount;
        }

        //mover
        Mover();
    }

    private void Mover()
    {
        if (!waterjumped) { rb.velocity = new Vector3(moveDirection * moveSpeed * Time.deltaTime, rb.velocity.y, 0f); }

        else rb.AddForce(new Vector2(moveDirection * (moveSpeed/25) * Time.deltaTime, 0f), ForceMode2D.Impulse);
        if (moveDirection == 0)
        {
            anim.SetBool("walking", false);
        }
        else anim.SetBool("walking", true);

        if (isJumping && jumpCount > 0)
        {
            Vector2 temp = rb.velocity;
            temp[1] = 0f;
            rb.velocity = temp;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpCount--;
        }
        isJumping = false;
    }

    private void Animar()
    {
        if (moveDirection > 0 && !isFacingRight)
        {
            //FlipCharacter();
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            isFacingRight = !isFacingRight;
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            //FlipCharacter();
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            isFacingRight = !isFacingRight;
        } 
    }

    private void ProcessarInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("jump",true);
            anim.SetBool("falling", false);
            Invoke("FallAnim", FallAnimTimer);
            isJumping = true;
        }
    }

    public void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    public void FallAnim() 
    {
        anim.SetBool("falling", true);
    }

    public Vector3 waterrecuo;
    public Vector3 waterecuobkp;

    public GameObject PlayerLight;
    public GameObject Waterlight;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (waterjumped) 
        {
            if (collision.gameObject.layer == 6 && !collision.gameObject.CompareTag("Earth"))
            {
                waterjumped = false; 
                PlayerLight.SetActive(true);
                Waterlight.SetActive(false);
                GetComponent<VirtualMan>().enabled = true;
            }
            else
            {
                //quica se n for o ch�o
                if (collision.gameObject.transform.position.x > transform.position.x)
                { waterecuobkp.x = -waterrecuo.x; }
                else { waterecuobkp.x = waterrecuo.x; }
                if (collision.gameObject.transform.position.y > transform.position.y)
                { waterecuobkp.y = -waterrecuo.y; }
                else { waterecuobkp.y = waterrecuo.y; }
                GetComponent<Rigidbody2D>().AddForce(waterecuobkp, ForceMode2D.Impulse);
            }
        }
        anim.SetBool("jump",false);
        anim.SetBool("falling", false);
    }
}
