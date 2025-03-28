using UnityEngine;

public class Dasher : Player
{
    [SerializeField]
    private float dashSpeed = 10f;

    [SerializeField]
    private float dashDuration = 0.1f;

    private bool isDashing;
    private float dashTimer;

    protected override void Update()
    {
        base.Update();

        if (isDashing)
        {
            dashTimer -= Time.deltaTime;

            if (dashTimer <= 0f)
            {
                StopDash();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartDash();
        }
    }

    private void StartDash()
    {
        isDashing = true;
        dashTimer = dashDuration;
        MoveForce = dashSpeed;
        Debug.Log("Dashing...");
    }

    private void StopDash()
    {
        isDashing = false;
        MoveForce = 3f; 
        Debug.Log("Dash Ended.");
    }
}