using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    SpriteRenderer sr;
    BoxCollider2D boxCol2d;
    float colSizeX, colSizeY;

    [SerializeField] GameObject player;

    [SerializeField] float laserSpeed=15f;
    float a = 1;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        boxCol2d = GetComponent<BoxCollider2D>();

        player = GameObject.Find("Player_Red");

        colSizeX = 1;
        colSizeY = 1;

    }

    void Update()
    {
        a += Time.deltaTime*laserSpeed;
        sr.size = new Vector2(1.5f, a);
        transform.position = player.transform.position;
        transform.localEulerAngles = player.transform.localEulerAngles;

        colSizeY += Time.deltaTime*laserSpeed;
        boxCol2d.size = new Vector2(colSizeX, colSizeY);

        boxCol2d.offset = new Vector2(0, colSizeY / 2);

        if(transform.localScale.x<=0)
        {
            Destroy(gameObject);
        }
    }
}
