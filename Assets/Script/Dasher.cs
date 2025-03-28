using UnityEngine;

public class Dasher : Player
{
    [SerializeField]
    private float _dashSpeed = 10f;

    [SerializeField]
    private float _dashDuration = 0.1f;

    private bool _isDashing;
    private float _dashTimer;

    protected override void Update()
    {
        base.Update();

        if (_isDashing)
        {
            _dashTimer -= Time.deltaTime;

            if (_dashTimer <= 0f)
            {
                StopDash();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !_isDashing)
        {
            StartDash();
        }
    }

    private void StartDash()
    {
        _isDashing = true;
        _dashTimer = _dashDuration;
        MoveForce = _dashSpeed;
        Debug.Log("Dashing...");
    }

    private void StopDash()
    {
        _isDashing = false;
        MoveForce = 3f; 
        Debug.Log("Dash Ended.");
    }
}