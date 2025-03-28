using UnityEngine;
public class DoubleJumpPlayer : Player
{
    
    private int jumpCount = 0;
    private int maxJumps = 2; // Allow double jump

    public override void PlayerJump()
    {
        if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Vertical")) && jumpCount < maxJumps)
        {
            IsGrounded = false;
            MyBody.linearVelocity = new Vector2(MyBody.linearVelocity.x, 0f); // Reset Y velocity before adding force
            MyBody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            jumpCount += 1;
            Debug.Log($"Jump Count: {jumpCount}");
        }

        if (IsGrounded)
        {
            jumpCount = 0;
            Debug.Log($"Jusdas"); // Reset jump count when grounded
        }
    }
}
