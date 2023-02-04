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
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        Vector2 position = direction.normalized;
        
        transform.position = (Vector2)player.transform.position + position;

        //Lidando com a rotação da seta
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
