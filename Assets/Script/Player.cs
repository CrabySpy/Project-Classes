// using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _moveForce = 10f;

    [SerializeField]
    private float _jumpForce = 11f;

    private float _movementX;

    private bool isGrounded;

    private Rigidbody2D _myBody;

    private SpriteRenderer _sr;

    private Animator _anim;

    private string WALK_ANIMATION = "Walk";

    private string GROUND_TAG = "Ground";

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
        PlayerWalk();
        PlayerJump();
        AnimatePlayer();
        Debug.Log(_movementX);
    }

    public void PlayerWalk() {

        _movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(_movementX, 0f, 0f) * Time.deltaTime * _moveForce;
    }

    public void PlayerJump() {

        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Vertical") ) && isGrounded) {
            isGrounded = false;
            _myBody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            Debug.Log("jumping");
        }        
    }

    public void AnimatePlayer(){
        if (_movementX > 0) {
            _anim.SetBool(WALK_ANIMATION, true);
            _sr.flipX = false;
        }
        else if (_movementX < 0) {
            _anim.SetBool(WALK_ANIMATION, true);
            _sr.flipX = true;
        }
        else {
            _anim.SetBool(WALK_ANIMATION, false);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(GROUND_TAG)) {
            isGrounded = true;
        }
    }

}
