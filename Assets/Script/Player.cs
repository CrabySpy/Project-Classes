using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 3f;

    public float MoveForce
    {
        get {return moveForce;}
        set {moveForce = value;}
    }

    [SerializeField]
    private float jumpForce = 10f;

    public float JumpForce
    {
        get {return jumpForce;}
        set {JumpForce = value;}
    }

    private float movementX;

    public float MovementX
    {
        get {return movementX;}
        set {movementX = value;}
    }

    private bool isGrounded;

    public bool IsGrounded
    {
        get {return isGrounded;}
        set {isGrounded = value;}
    }

    private Rigidbody2D myBody;
    public Rigidbody2D MyBody
    {
        get {return myBody;}
        set {myBody = value;}
    }

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";

    private string FLAG_TAG = "Flag";

    private string GROUND_TAG = "Ground";

    private void Awake()
    {
        MyBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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
        transform.position += new Vector3(MovementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    public virtual void PlayerJump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Vertical")) && IsGrounded)
        {
            IsGrounded = false;
            MyBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Debug.Log("jumping");
        }
    }

    public void AnimatePlayer()
    {
        if (MovementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (MovementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
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
