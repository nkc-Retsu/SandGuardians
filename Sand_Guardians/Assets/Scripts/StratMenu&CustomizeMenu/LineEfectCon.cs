using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEfectCon : MonoBehaviour
{

    [SerializeField] GameObject lineEfect;
    private Vector3 efVec;

    // Start is called before the first frame update
    void Start()
    {
        efVec = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        efVec.x += Time.deltaTime; 

        if(efVec.x >= 20)
        {
            efVec.x = 0;
        }


        lineEfect.transform.position = efVec;
    }
}
