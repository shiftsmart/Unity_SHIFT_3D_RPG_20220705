using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolRock : MonoBehaviour
{



    [SerializeField, Header("碎片")]
    private GameObject prefabRock;

    [SerializeField, Header("碎片最大數量")]
    private int countMaxRock = 30;

    private ObjectPool<GameObject> poolRock;
    private int count;


    private void Awake()
    {
      
        poolRock = new ObjectPool<GameObject>(
            CreatePool,GetRock,ReleaseRock,DestroyRock,false,countMaxRock
            );
    }

    private GameObject CreatePool() {
        count++;
        GameObject temp = Instantiate(prefabRock);
        temp.name = prefabRock.name + "  " + count;
        return temp;
    }
    private void GetRock(GameObject rock) {

        rock.SetActive(true);
    }
    private void ReleaseRock(GameObject rock) {

        rock.SetActive(false);
    }
    private void DestroyRock(GameObject rock) {
        Destroy(rock);
    
    }

    /// <summary>
    /// 取得物件池內的物件
    /// </summary>

    public GameObject GetPoolObject() {

      return  poolRock.Get();
    }

    /// <summary>
    /// 將物件還到物件池內
    /// </summary>
    /// <param name="rock"></param>

    public void ReleasePoolObject(GameObject rock) {

        poolRock.Release(rock);
    
    }


}
