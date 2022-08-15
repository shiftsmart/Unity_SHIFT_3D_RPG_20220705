using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SHIFT;
using UnityEngine;
using UnityEngine.AI;

public class EnemySystem : MonoBehaviour
{

    [SerializeField, Header("�ĤH���")]
    private DataEnemy dataEnemy;

    [SerializeField]
    private StateEnemy stateEnemy;
    private Animator ani;
    private NavMeshAgent nma;
    private Vector3 v3TargetPosition = new Vector3(30,2,30);
    private string parWalk = "�}������";


    private float timerIdle;

    private void Awake()
    {

        ani = GetComponent<Animator>();
        nma = GetComponent<NavMeshAgent>();
        nma.speed = dataEnemy.speedWalk;
    }

    private void Update()
    {
        StateMachine();
        CheckerTargetInTrackRange();
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
        print("���ݮɶ�:"+timerIdle);

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
        nma.SetDestination(v3TargetPosition);
        ani.SetBool(parWalk,true);
        if ( Vector3.Distance(transform.position,v3TargetPosition) <=   dataEnemy.rangeAttack) {
            stateEnemy = StateEnemy.Attack;
            print("�i�J�������A");
        
        }

    }

    private float timerAttack;
    private string parAttack = "Ĳ�o����";


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
        }

    }
    /// <summary>
    /// �ˬd�ؼЬO�_�b�l�ܽd��
    /// </summary>
    private void CheckerTargetInTrackRange() {
        if (stateEnemy == StateEnemy.Attack) return;
        Collider[] hits = Physics.OverlapSphere(transform.position,dataEnemy.rangeTrack,dataEnemy.layerTarget);
        if (hits.Length>0) {
            v3TargetPosition = hits[0].transform.position;
            stateEnemy = StateEnemy.Track;
        }
    
    }

}
