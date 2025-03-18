// using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _moveForce = 10f;

    [SerializeField]
    private float _jumpForce = 11f;

    private float _movementX;

    private Rigidbody2D _myBody;

    private SpriteRenderer _sr;

    private Animator _anim;

    private string WALK_ANIMATION = "Walk";

    private void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Debug.Log(_movementX);
    }

    void PlayerMovement() {

        _movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(_movementX, 0f, 0f) * Time.deltaTime * _moveForce;

    }
}
