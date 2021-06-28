using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    public class EnemyDamged : MonoBehaviour
    {
        private EnemyCore core;
        private SpriteRenderer sr;

        // Start is called before the first frame update
        void Start()
        {
            core = GetComponent<EnemyCore>();
            sr = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (core.DamageFlg)
            {
                Damage();
                core.DamageFlg = false;
            }
        }

        private void Damage()
        {
            StartCoroutine("ColorChange");
        }


        private IEnumerator ColorChange()
        {
            Debug.Log("‚¨‚¨‚¨‚¨");
            sr.color = new Color(1, 1, 1, 0); ;
            yield return new WaitForSeconds(0.1f);
            sr.color = new Color(1, 1, 1, 1);
        }
    }

}
