using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaScript : MonoBehaviour
{
    public GameObject player;
    private SpriteRenderer spriteRenderer;
    private float numHearts;
    public Image[] hearts;
    public Sprite Heart;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        numHearts = player.GetComponent<Life>().life;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.sortingOrder = 1;
        spriteRenderer.size = new Vector2(player.GetComponent<Life>().life, 1);
    }
}
