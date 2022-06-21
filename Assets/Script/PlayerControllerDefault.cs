using UnityEngine;

/// <summary>
/// 十字キーのみで操作ができるUnity公式のスクリプト
/// スペースキーでジャンプができる
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerControllerDefault : MonoBehaviour
{
    [SerializeField] private float speed = 6.0F;       //歩行速度
    [SerializeField] private float jumpSpeed = 8.0F;   //ジャンプ力
    [SerializeField] private float gravity = 20.0F;    //重力の大きさ

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
            _moveDirection = new Vector3 (_moveHorizon, 0, _moveVertical);
            _moveDirection = transform.TransformDirection(_moveDirection);
            _moveDirection *= speed;
            if (Input.GetButton("Jump"))
                _moveDirection.y = jumpSpeed;
        }
        
        _moveDirection.y -= gravity * Time.deltaTime;
        _controller.Move(_moveDirection * Time.deltaTime);

    }
}
