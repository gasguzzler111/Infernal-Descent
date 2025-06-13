using UnityEngine;
using UnityEngine.Rendering;

public class player_script : MonoBehaviour
{
    [SerializeField] private float HP = 100;
    [SerializeField] private float speed = 5;
    Rigidbody2D rb;
    [SerializeField] GameObject knockback_hitpre;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //movmement 
        float xspeed = Input.GetAxis("Horizontal");
        float yspeed = Input.GetAxis("Vertical");
        transform.Translate(Vector2.right * xspeed * speed * Time.deltaTime);
        transform.Translate(Vector2.up * yspeed * speed * Time.deltaTime);
    }
    public void player_hit(float damage, string debuf_type, float debuf_amount)
    {
        GameObject knockback_hit = Instantiate(knockback_hitpre, new Vector3 (transform.position.x,transform.position.y,0 ),Quaternion.identity); 
        Destroy(knockback_hit,.1f);
        HP -= damage;
        switch (debuf_type)
        {
            case "slow":
                break;
            case "burn":
                break;
            case null: 
                break;

        }

    }
}
