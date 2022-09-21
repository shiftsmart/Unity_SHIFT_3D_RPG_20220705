using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolRock : MonoBehaviour
{



    [SerializeField, Header("�H��")]
    private GameObject prefabRock;

    [SerializeField, Header("�H���̤j�ƶq")]
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
    /// ���o�������������
    /// </summary>

    public GameObject GetPoolObject() {

      return  poolRock.Get();
    }

    /// <summary>
    /// �N�����٨쪫�����
    /// </summary>
    /// <param name="rock"></param>

    public void ReleasePoolObject(GameObject rock) {

        poolRock.Release(rock);
    
    }


}
