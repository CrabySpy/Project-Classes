using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    void Start()
    {
        FindPlayer();
    }
    private void LateUpdate()
    {

        if (player != null) {
            tempPos = transform.position;
            tempPos.x = player.position.x;
            transform.position = tempPos;
        }
    }

    // ✅ Try to find the player by tag
    private void FindPlayer()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    public void SetPlayer(Transform playerTransform) 
    {
        player = playerTransform;
    }
}
