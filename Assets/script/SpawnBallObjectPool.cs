using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnBallObjectPool : MonoBehaviour
{
    /// <summary>
    /// 生成球體:使用物件值
    /// </summary>


    [SerializeField]
    private GameObject prefabBall;

    /// <summary>
    /// 球體物件池
    /// </summary>
    private ObjectPool<GameObject> poolBall;
    private void Awake()
    {
        poolBall = new ObjectPool<GameObject>(
            CreatePool, GetBall, ReleaseBall, DestoryBall, false, 100
            );
        InvokeRepeating("Spawn", 0, 0.1f);
    }
    /// <summary>
    /// 建立物件池時要處理的行為
    /// </summary>
    private GameObject CreatePool()
    {

        return Instantiate(prefabBall);

    }
    /// <summary>
    /// 跟物件池拿物件
    /// </summary>
    private void GetBall(GameObject ball)
    {
        ball.SetActive(true);

    }

    /// <summary>
    /// 把物件還給物件池
    /// </summary>
    /// <param name="ball"></param>

    private void ReleaseBall(GameObject ball)
    {
        ball.SetActive(false);


    }


    /// <summary>
    /// 數量超出物件池容量要做的處理
    /// </summary>
    private void DestoryBall(GameObject ball)
    {
        Destroy(ball);

    }

    private void Spawn()
    {
        Vector3 pos;
        pos.x = Random.Range(-15f, 15f);
        pos.y = Random.Range(5f, 7f);
        pos.z = Random.Range(-15f, 15f);

        GameObject tempBall = poolBall.Get();
        tempBall.transform.position = pos;
        tempBall.GetComponent<BallObjectPool>().OnHit = BallHitAndRelease;


    }

    private void BallHitAndRelease(GameObject ball) {

        poolBall.Release(ball);

    }


}
