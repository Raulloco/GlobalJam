using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public float life = 2;
    public bool enemy;
    public Vector2 recuo;
    private Vector2 recuoxbkp;
    public GameObject[] hearts;
    public GameObject gameOverBackground;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            if (collision.gameObject.transform.position.x > transform.position.x)
            { recuoxbkp.x = -recuo.x; }
            else { recuoxbkp.x = recuo.x; }
            life -= collision.gameObject.GetComponent<Damage>().damage;
            updateUI(false);
            GetComponent<Rigidbody2D>().AddForce(new Vector3(recuoxbkp.x, recuo.y, 0), ForceMode2D.Impulse);
        }

    }

    void updateUI(bool condition)
    {
        //caso chame o metodo como falso, a vida sera diminuida
        //se chamar como true, aumenta a vida
        hearts[(int)life].SetActive(condition);
        if (life == 0)
        {
            //call game over function here
            gameOver();

        }
    }

    void gameOver()
    {
        Time.timeScale = 0f;
        gameOverBackground.SetActive(true);

    }
}
