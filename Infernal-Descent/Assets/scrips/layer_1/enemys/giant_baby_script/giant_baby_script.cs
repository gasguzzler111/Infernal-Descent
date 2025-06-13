using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    NavMeshAgent agent;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer render;
    [SerializeField] private float HP = 100;
    [SerializeField] private float player_dis;
    [SerializeField] private GameObject hurtbxpre;
    [SerializeField] private float attk_time = 6;
    private Vector2 dir;
    private bool is_stuned = false;
    private int attk_pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        render = GetComponent<SpriteRenderer>();    
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); 
        agent = GetComponent<NavMeshAgent>();   
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = 2;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position); // makes the enemy move towerd the player
        dir = (player.transform.position - transform.position).normalized;
        float angle = Vector2.SignedAngle(Vector2.up, dir);  
        //Debug.Log(dir);
        player_dis = Vector2.Distance(transform.position, player.transform.position); 
        // find direction that the enemy is comingfrom and changes there sprite
        if (angle > -40 && angle < 40)
        {
            attk_pos = 0;   
            //Debug.Log("look up");
        }
        else if (angle >= 40 && angle <= 135)
        {
            animator.Play("gb_side",0);
            attk_pos = 1;
            render.flipX = false;   
            //Debug.Log("look left");
        }
        else if (angle <= -40 && angle >= -135)
        {
            animator.Play("gb_side",0);
            attk_pos = 2;
            render.flipX = true;
            //Debug.Log("look right");
        }
        else // covers angles > 135 or < -135
        {
            attk_pos=3;
            animator.Play("gb_down", 0);
            //Debug.Log("look down");

        }
       
        // enemy dies/gets destroyed
        if (HP <= 0) 
        {
            Destroy(gameObject);
            return;
        }
     
        // distence check
        if (player_dis >= 1.5 && is_stuned == false)
        {
            attk_time = 6;  
            agent.isStopped = false;
        }
        else if (player_dis < 1.5)
        {
            agent.isStopped = true;    
            attk_time -= Time.deltaTime;
        }
        //attacks if 
        if (attk_time <= 0)
        {
            attk();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if the bullet hits the enemy 
        if (other.gameObject.CompareTag("bullet"))
        {
            //Debug.Log("hit");
            bullet_script bullet = other.gameObject.GetComponent<bullet_script>();
            HP -= 20;
            rb.AddForce(dir * -5, ForceMode2D.Impulse);// knock back
            is_stuned = true;
            agent.isStopped = true;
            Invoke("Knockback_stop", .3f);// stops the knock back after some time 
            Invoke("stun_stop", .5f);
            bullet.bullet_hit();
        }
        if (other.gameObject.CompareTag("knockback_hit")) //when player is hit they get knocked back
        {
            is_stuned = true;
            agent.isStopped = true;
            rb.AddForce(dir * -5, ForceMode2D.Impulse);
            Invoke("Knockback_stop", .3f);// stops the knock back after some time 
            Invoke("stun_stop", .5f);
        }
    }
    private void Knockback_stop()
    {
        Debug.Log("STOP");
        rb.linearVelocity = Vector2.zero;

    }
    private void stun_stop()
    {
        agent.isStopped = false;
        is_stuned = false;  
    }
    private void attk() 
    {
        switch (attk_pos)//wich way the hitbox spawns
        {
            case 0:
                GameObject hurtbxu = Instantiate(hurtbxpre, new Vector2(transform.position.x, transform.position.y+1), Quaternion.identity);
                Destroy(hurtbxu,.1f);
                break;
            case 1:
                GameObject hurtbxl = Instantiate(hurtbxpre, new Vector2(transform.position.x-1, transform.position.y), Quaternion.identity);
                Destroy(hurtbxl, .1f);
                break;
            case 2:
                GameObject hurtbxr = Instantiate(hurtbxpre, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                Destroy(hurtbxr, .1f);
                break;
            case 3:
                GameObject hurtbxd = Instantiate(hurtbxpre, new Vector2(transform.position.x, transform.position.y-1), Quaternion.identity);
                Destroy(hurtbxd, .1f);
                break;
        }
        attk_time = 6;

    }
}
