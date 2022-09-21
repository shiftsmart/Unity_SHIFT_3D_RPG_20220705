using System.Collections;
using System.Collections.Generic;
using SHIFT;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    private EnemySystem enemySystem;

    private Material matDissolve;
    private string nameDissolve = "DissolveValue";

    private float maxDissolve = 2.5f;
    private float minDissolve=-2.6f;

    private ObjectPoolRock objectPoolRock;

    protected override void Awake()
    {
        base.Awake();
        enemySystem = GetComponent<EnemySystem>();
        matDissolve = GetComponentsInChildren<Renderer>()[0].material;
        //    matDissolve.SetFloat(nameDissolve, 0.1f);

        objectPoolRock = FindObjectOfType<ObjectPoolRock>();
    }

    protected override void Dead()
    {
        base.Dead();
        enemySystem.enabled = false;
        DropProp();
        StartCoroutine(Dissolve());
    }

    private IEnumerator Dissolve() {
        while (maxDissolve>minDissolve) {
            maxDissolve -= 0.1f;
            matDissolve.SetFloat(nameDissolve,maxDissolve);
            yield return new WaitForSeconds(0.03f);
        
        }
    
    }


    private void DropProp()
    {

        float value = Random.value;
        if (value <= dataHealth.propProbability)
        {

            //Instantiate(
            //    dataHealth.goProp,
            //    transform.position + Vector3.up * 3,
            //    Quaternion.identity
            //    );

            GameObject tempObject = objectPoolRock.GetPoolObject();
            tempObject.transform.position = transform.position + Vector3.up * 3;

        }

    }

}
