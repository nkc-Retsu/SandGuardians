using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    SpriteRenderer sr;
    BoxCollider2D boxCol2d;
    float colSizeX, colSizeY;

    GameObject player;
    private Vector3 defaultScale;
    private Vector2 defaultSRSize;

    private LaserScaleChange laserScaleChange;
    public void SetPlayer(GameObject playerObj)
    {
        player = playerObj;
    }

    [SerializeField] float laserSpeed=15f;
    float sr_size_y = 1;
    void Start()
    {
        // サイズの初期化
        laserScaleChange = GetComponent<LaserScaleChange>();

        sr_size_y = 1;

        sr = GetComponent<SpriteRenderer>();
        boxCol2d = GetComponent<BoxCollider2D>();


        colSizeX = 1;
        colSizeY = 1;

        defaultScale = transform.localScale;
        defaultSRSize = sr.size;

    }

    void Update()
    {
        // レーザーを伸ばす

        sr_size_y += Time.deltaTime*laserSpeed;
        sr.size = new Vector2(1.5f, sr_size_y);
        transform.position = player.transform.position;
        transform.localEulerAngles = player.transform.localEulerAngles;

        colSizeY += Time.deltaTime*laserSpeed;
        boxCol2d.size = new Vector2(colSizeX, colSizeY);

        boxCol2d.offset = new Vector2(0, colSizeY / 2);

        if(transform.localScale.x<=0)
        {
            // 破棄
            laserScaleChange.Reset();

            transform.localScale = defaultScale;
            sr.size = new Vector2(defaultSRSize.x,1);
            boxCol2d.size = new Vector2(1, 1);
            gameObject.SetActive(false);
        }
    }
}
