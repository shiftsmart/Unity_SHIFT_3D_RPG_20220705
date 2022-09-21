using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnBallObjectPool : MonoBehaviour
{
    /// <summary>
    /// �ͦ��y��:�ϥΪ����
    /// </summary>


    [SerializeField]
    private GameObject prefabBall;

    /// <summary>
    /// �y�骫���
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
    /// �إߪ�����ɭn�B�z���欰
    /// </summary>
    private GameObject CreatePool()
    {

        return Instantiate(prefabBall);

    }
    /// <summary>
    /// �򪫥��������
    /// </summary>
    private void GetBall(GameObject ball)
    {
        ball.SetActive(true);

    }

    /// <summary>
    /// �⪫���ٵ������
    /// </summary>
    /// <param name="ball"></param>

    private void ReleaseBall(GameObject ball)
    {
        ball.SetActive(false);


    }


    /// <summary>
    /// �ƶq�W�X������e�q�n�����B�z
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
