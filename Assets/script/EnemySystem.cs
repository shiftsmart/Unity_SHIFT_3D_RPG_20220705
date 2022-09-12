using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SHIFT;
using UnityEngine;
using UnityEngine.AI;

public class EnemySystem : MonoBehaviour
{

    [SerializeField, Header("敵人資料")]
    private DataEnemy dataEnemy;

    [SerializeField]
    private StateEnemy stateEnemy;
    private Animator ani;
    private NavMeshAgent nma;
    private Vector3 v3TargetPosition = new Vector3(30,2,30);
    private string parWalk = "開關走路";


    private float timerIdle;

    private EnemyAttack enemyAttack;

    private void Awake()
    {

        ani = GetComponent<Animator>();
        enemyAttack = GetComponent<EnemyAttack>();
        nma = GetComponent<NavMeshAgent>();
        nma.speed = dataEnemy.speedWalk;
    }

    private void Update()
    {
        StateMachine();
        CheckerTargetInTrackRange();
    }
    private void OnDisable()
    {
        nma.isStopped = true;
    }

    private void StateMachine() {
        switch (stateEnemy)
        {
            case StateEnemy.Idle:
                Idle();
                break;
            case StateEnemy.Wander:
                Wander();
                break;
            case StateEnemy.Track:
                Track();
                break;
            case StateEnemy.Attack:
                Attack();
                break;
       
        }

    }

    private void Idle() {
        nma.velocity = Vector3.zero;
        ani.SetBool(parWalk, false);
        timerIdle += Time.deltaTime;
        print("等待時間:"+timerIdle);

        float r = Random.Range(dataEnemy.timeIdleRange.x,dataEnemy.timeIdleRange.y);

        if (timerIdle>=r) {
            timerIdle = 0;
            stateEnemy = StateEnemy.Wander;
        
        }
    
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 3, 0.2f, 0.3f);
        Gizmos.DrawSphere(transform.position, dataEnemy.rangeTrack);

        Gizmos.color = new Color(1, 0.2f, 0.2f, 0.3f);
        Gizmos.DrawSphere(transform.position, dataEnemy.rangeAttack);

        Gizmos.color = new Color(1, 0.2f, 0.3f, 1);
        Gizmos.DrawSphere(v3TargetPosition, 0.3f);



    }
    private void Wander()
    {

        if (nma.remainingDistance==0) {
            v3TargetPosition =  transform.position+Random.insideUnitSphere * dataEnemy.rangeTrack;
            v3TargetPosition.y = transform.position.y;
        }


        nma.SetDestination(v3TargetPosition);
        ani.SetBool(parWalk,nma.velocity.magnitude>0.1f);
    }
    private void Track() {

        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Attack01")) {

            nma.velocity = Vector3.zero;
        }



        nma.SetDestination(v3TargetPosition);
        ani.SetBool(parWalk,true);

        ani.ResetTrigger(parAttack);

        if (Vector3.Distance(transform.position, v3TargetPosition) <= dataEnemy.rangeAttack)
        {
            stateEnemy = StateEnemy.Attack;
            print("進入攻擊狀態");

        }
        else {

            timerAttack = dataEnemy.intervalAttack;
        }

    }

    private float timerAttack;
    private string parAttack = "觸發攻擊";


    private void Attack() {

        ani.SetBool(parWalk,false);
        nma.velocity = Vector3.zero;

        if (timerAttack < dataEnemy.intervalAttack)
        {
            timerAttack += Time.deltaTime;
        }
        else {

            ani.SetTrigger(parAttack);
            timerAttack = 0;
            enemyAttack.StartAttack();
            stateEnemy = StateEnemy.Track;
        }

    }
    /// <summary>
    /// 檢查目標是否在追蹤範圍內
    /// </summary>
    private void CheckerTargetInTrackRange() {
  
        Collider[] hits = Physics.OverlapSphere(transform.position,dataEnemy.rangeTrack,dataEnemy.layerTarget);
        if (hits.Length > 0)
        {
            v3TargetPosition = hits[0].transform.position;
            if (stateEnemy == StateEnemy.Attack) return;
            stateEnemy = StateEnemy.Track;
        }
        else {

            stateEnemy = StateEnemy.Wander;
        
        }
    
    }

}
