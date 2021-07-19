using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class BulletPool : MonoBehaviour, IGetBullet
{
    [SerializeField] GameObject redBullet;
    [SerializeField] GameObject blueBullet;
    [SerializeField] GameObject redBulletParent;
    [SerializeField] GameObject blueBulletParent;
    private List<GameObject> redBulletList;
    private List<GameObject> blueBulletList;

    private const int MAX_COUNT = 10;

    private void Awake()
    {
        CreatePool();   
    }

    private void CreatePool()
    {
        redBulletList = new List<GameObject>();
        blueBulletList = new List<GameObject>();

        for(int i=0;i<MAX_COUNT; ++i)
        {
            GameObject newRedBullet = CreateBullet(redBullet, redBulletParent, redBulletList);
            redBulletList.Add(newRedBullet);
            GameObject newBlueBullet = CreateBullet(blueBullet, blueBulletParent, blueBulletList);
            blueBulletList.Add(newBlueBullet);
        }
    }

    public GameObject GetRedBullet()
    {
        foreach(var obj in redBulletList)
        {
            if(obj.activeSelf==false)
            {
                return obj;
            }
        }

        GameObject newRedBullet = CreateBullet(redBullet,redBulletParent,redBulletList);
        redBulletList.Add(newRedBullet);
        newRedBullet.SetActive(true);
        return newRedBullet;
    }


    public GameObject GetBlueBullet()
    {
        foreach(var obj in blueBulletList)
        {
            if(obj.activeSelf==false)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newBlueBullet = CreateBullet(blueBullet,blueBulletParent,blueBulletList);
        blueBulletList.Add(newBlueBullet);
        newBlueBullet.SetActive(true);
        return newBlueBullet;
    }

    private GameObject CreateBullet(GameObject bullet,GameObject parentObj,List<GameObject> addList)
    {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.parent = parentObj.transform;
        newBullet.name = newBullet.name + (addList.Count + 1);
        newBullet.SetActive(false);

        return newBullet;
    }
}
