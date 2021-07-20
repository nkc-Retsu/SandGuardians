using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class BulletPool : MonoBehaviour, IGetBullet
{
    // �I�u�W�F�N�g�v�[��

    [SerializeField] GameObject redBullet;
    [SerializeField] GameObject blueBullet;
    [SerializeField] GameObject redBulletParent;
    [SerializeField] GameObject blueBulletParent;
    // ���X�g
    private List<GameObject> redBulletList;
    private List<GameObject> blueBulletList;

    // �ŏ���10�R����
    private const int MAX_COUNT = 10;

    private void Awake()
    {
        // �v�[�����쐬
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
        // ��A�N�e�B�u�ȃI�u�W�F�N�g�����������琶��

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
        // ��A�N�e�B�u�ȃI�u�W�F�N�g�����������琶��

        foreach (var obj in blueBulletList)
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
