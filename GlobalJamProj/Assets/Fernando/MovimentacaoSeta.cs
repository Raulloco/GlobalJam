using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoSeta : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(player.transform.position);
        float magnitiudedir = direction.magnitude;
       
        
        if (magnitiudedir < 100f)
        {
            transform.localScale = Vector3.one;
        }
        else if(magnitiudedir <= 400f)
        {
            transform.localScale =  Vector3.one  * (1 + 2*(magnitiudedir - 100f)/300f);
        }
        else
        {
            transform.localScale = Vector3.one * 3f;
        }
        
        Vector2 position = (Vector2)player.transform.position + (Vector2)direction.normalized;
        transform.position = position;

        //Lidando com a rotação da seta
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
