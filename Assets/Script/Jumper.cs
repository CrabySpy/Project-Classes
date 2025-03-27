using UnityEngine;
public class DoubleJumpPlayer : Player
{
    
    private int _jumpCount = 0;
    private int _maxJumps = 2; // Allow double jump

    public override void PlayerJump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Vertical")) && _jumpCount < _maxJumps)
        {
            IsGrounded = false;
            MyBody.linearVelocity = new Vector2(MyBody.linearVelocity.x, 0f); // Reset Y velocity before adding force
            MyBody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            _jumpCount += 1;
            Debug.Log($"Jump Count: {_jumpCount}");
        }

        if (IsGrounded)
        {
            _jumpCount = 0;
            Debug.Log($"Jusdas"); // Reset jump count when grounded
        }
    }
}
