using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 方向を回転して決めるタイプのPlayerCOntroller
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerControllerRotate : MonoBehaviour
{
    public float speed = 6.0F;          //歩行速度
    public float jumpSpeed = 8.0F;      //ジャンプ力
    public float gravity = 20.0F;       //重力の大きさ
    public float rotateSpeed = 3.0F;    //回転速度

    private CharacterController _controller;
    private Vector3 _moveDirection = Vector3.zero;
    private float _moveHorizon;
    private float _moveVertical;

    void Start () {
        _controller = GetComponent<CharacterController>();
    }

    void Update () {

        _moveHorizon = Input.GetAxis ("Horizontal");    //左右矢印キーの値(-1.0~1.0)
        _moveVertical = Input.GetAxis ("Vertical");      //上下矢印キーの値(-1.0~1.0)

        if (_controller.isGrounded) {
            gameObject.transform.Rotate (new Vector3 (0, rotateSpeed * _moveHorizon, 0));
            _moveDirection = speed * _moveVertical * gameObject.transform.forward;
            if (Input.GetButton("Jump"))
                _moveDirection.y = jumpSpeed;
        }
        _moveDirection.y -= gravity * Time.deltaTime;
        _controller.Move(_moveDirection * Time.deltaTime);

    }
}
