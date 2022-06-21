using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 十字キーのみで操作ができるUnity公式のスクリプト
/// スペースキーでジャンプができる
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerControllerDefault : MonoBehaviour
{
    [SerializeField] float speed = 6.0F;       //歩行速度
    [SerializeField] float jumpSpeed = 8.0F;   //ジャンプ力
    [SerializeField] float gravity = 20.0F;    //重力の大きさ

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float moveHorizon;
    private float moveVertical;
    

    void Start () {
        controller = GetComponent<CharacterController>();
    }

    void Update () {

        moveHorizon = Input.GetAxis ("Horizontal");    //左右矢印キーの値(-1.0~1.0)
        moveVertical = Input.GetAxis ("Vertical");      //上下矢印キーの値(-1.0~1.0)

        if (controller.isGrounded) {
            moveDirection = new Vector3 (moveHorizon, 0, moveVertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

    }
}
