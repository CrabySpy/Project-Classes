using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _moveForce = 3f;

    public float MoveForce
    {
        get {return _moveForce;}
        set {_moveForce = value;}
    }

    [SerializeField]
    private float _jumpForce = 10f;

    public float JumpForce
    {
        get {return _jumpForce;}
        set {JumpForce = value;}
    }

    private float _movementX;

    public float MovementX
    {
        get {return _movementX;}
        set {_movementX = value;}
    }

    private bool _isGrounded;

    public bool IsGrounded
    {
        get {return _isGrounded;}
        set {_isGrounded = value;}
    }

    private Rigidbody2D _myBody;
    public Rigidbody2D MyBody
    {
        get {return _myBody;}
        set {_myBody = value;}
    }

    private SpriteRenderer _sr;

    private Animator _anim;

    private string WALK_ANIMATION = "Walk";

    private string FLAG_TAG = "Flag";

    private string GROUND_TAG = "Ground";

    private void Awake()
    {
        MyBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        PlayerWalk();
        PlayerJump();
        AnimatePlayer();
    }

    public void PlayerWalk()
    {
        MovementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(MovementX, 0f, 0f) * Time.deltaTime * _moveForce;
    }

    public virtual void PlayerJump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Vertical")) && IsGrounded)
        {
            IsGrounded = false;
            MyBody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            Debug.Log("jumping");
        }
    }

    public void AnimatePlayer()
    {
        if (MovementX > 0)
        {
            _anim.SetBool(WALK_ANIMATION, true);
            _sr.flipX = false;
        }
        else if (MovementX < 0)
        {
            _anim.SetBool(WALK_ANIMATION, true);
            _sr.flipX = true;
        }
        else
        {
            _anim.SetBool(WALK_ANIMATION, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            IsGrounded = true;
        }

        if (collision.gameObject.CompareTag(FLAG_TAG))
        {
            WinGame();
        }
    }

    protected void WinGame()
    {
        Debug.Log("You Win!");
        Time.timeScale = 0f;
    }
}
