using UnityEngine;

public class giant_baby_hit_script : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit");
            player_script player = other.gameObject.GetComponent<player_script>();
            player.player_hit(12,null,0);
        }
    }
}
