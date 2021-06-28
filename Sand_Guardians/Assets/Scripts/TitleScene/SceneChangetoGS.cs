using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangetoGS : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) { FadeManager.Instance.LoadScene("GameScene", 0.5f); }
        
    }
}
