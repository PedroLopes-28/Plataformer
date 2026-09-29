using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            print("Grounded");
            player.ResetJump();
        }
    }
}