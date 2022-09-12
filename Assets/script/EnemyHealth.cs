using System.Collections;
using System.Collections.Generic;
using SHIFT;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    private EnemySystem enemySystem;

    protected override void Awake()
    {
        base.Awake();
        enemySystem = GetComponent<EnemySystem>();


    }

    protected override void Dead()
    {
        base.Dead();
        enemySystem.enabled = false;
        DropProp();
    }

    private void DropProp() {

        float value = Random.value;
        if (value<=dataHealth.propProbability) {

            Instantiate(
                dataHealth.goProp,
                transform.position+Vector3.up*3,
                Quaternion.identity
                );
        
        }
    
    }

}
