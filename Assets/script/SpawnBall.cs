using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBall;

    private void Awake()
    {
        InvokeRepeating("Spawn", 0, 0.1f);
    }

    private void Spawn() {

        Vector3 pos;
        pos.x = Random.Range(-15f,15f);
        pos.y = Random.Range(5f, 7f);
        pos.z = Random.Range(-15f, 15f);

        Instantiate(prefabBall,pos,Quaternion.identity);

    }

}
