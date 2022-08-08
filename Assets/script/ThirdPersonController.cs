using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    #region 資料
    [SerializeField, Header("移動速度"), Range(0, 50)]
    private float speed = 3.5f;
    [SerializeField, Header("旋轉速度"), Range(0, 50)]
    private float turn = 5f;
    [SerializeField, Header("跳躍速度"), Range(0, 50)]
    private float jump = 7f;
    private Animator ani;
    private CharacterController controller;


    #endregion
    private Vector3 direction;
    private Transform traCamera;
    private string parRun = "Blend";
    private string parJump = "jump";
    #region 事件
    private void Awake()
    {
        ani = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        traCamera = GameObject.Find("Main Camera").GetComponent<Transform>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    #endregion

    #region 方法

    private void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");


        transform.rotation = Quaternion.Lerp(transform.rotation, traCamera.rotation, turn * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        direction.z = v;
        direction.x = h;

        direction = transform.TransformDirection(direction);

        controller.Move(direction * speed * Time.deltaTime);


        float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");
        if (Mathf.Abs(vAxis) > 0.1f)
        {
            ani.SetFloat(parRun, Mathf.Abs(vAxis));
        }
        else if (Mathf.Abs(hAxis) > 0.1f)
        {
            ani.SetFloat(parRun, Mathf.Abs(hAxis));

        }
        else
        {
            ani.SetFloat(parRun, 0);

        }

        //print("<color=yellow>垂直軸向:"+v+"</color>");
    }
    private void Jump()
    {
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetTrigger(parJump);
            direction.y = jump;

        }
        direction.y += Physics.gravity.y * Time.deltaTime;

    }
    #endregion

}
