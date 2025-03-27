using UnityEngine;

public class Dasher : Player
{
    [SerializeField]
    private float _dashSpeed = 10f;

    [SerializeField]
    private float _dashDuration = 0.2f;

    private bool isDashing = false;

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            StartCoroutine(PlayerDash());
        }
    }

    private System.Collections.IEnumerator PlayerDash()
    {
        isDashing = true;
        float originalSpeed = MoveForce;
        MoveForce = _dashSpeed;

        yield return new WaitForSeconds(_dashDuration);

        MoveForce = originalSpeed;
        isDashing = false;
    }
}

