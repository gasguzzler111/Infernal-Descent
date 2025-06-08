using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    NavMeshAgent agent;
    Rigidbody2D rb;
    [SerializeField] private float HP = 100;
    [SerializeField] private float player_dis;
    [SerializeField] private GameObject hurtbxpre;
    [SerializeField] private bool is_attk = false;
    [SerializeField] private float attk_time = 6;
    private Vector2 dir;
    private int attk_pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        agent.SetDestination(player.transform.position);
        dir = (player.transform.position - transform.position).normalized;
        float angle = Vector2.SignedAngle(Vector2.up, dir);  
        //Debug.Log(dir);
        player_dis = Vector2.Distance(transform.position, player.transform.position);
        if (angle > -40 && angle < 40)
        {
            attk_pos = 0;   
            //Debug.Log("look up");
        }
        else if (angle >= 40 && angle <= 135)
        {
            attk_pos = 1;   
            //Debug.Log("look left");
        }
        else if (angle <= -40 && angle >= -135)
        {
            attk_pos = 2;   
            //Debug.Log("look right");
        }
        else // covers angles > 135 or < -135
        {
            attk_pos=3;
            //Debug.Log("look down");
        }

        if (HP <= 0) 
        {
            Destroy(gameObject);
            return;
        }
        if (player_dis >= 1.5 && is_attk == false)
        {
            agent.isStopped = false;
        }
        else if (player_dis < 1.5)
        {
            agent.isStopped = true;    
            attk_time -= Time.deltaTime;
        }
        if (attk_time <= 0)
        {
            attk();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            //Debug.Log("hit");
            bullet_script bullet = other.gameObject.GetComponent<bullet_script>();
            HP -= 20;
            rb.AddForce(dir * -5, ForceMode2D.Impulse);
            Invoke("Knockback_stop", .3f);
            bullet.bullet_hit();
        }
    }
    private void Knockback_stop()
    {
        Debug.Log("STOP");
        rb.linearVelocity = Vector2.zero;
    }
    private void attk()
    {
        switch (attk_pos)
        {
            case 0:
                GameObject hurtbxu = Instantiate(hurtbxpre, new Vector2(transform.position.x, transform.position.y+1), Quaternion.identity);
                break;
            case 1:
                GameObject hurtbxl = Instantiate(hurtbxpre, new Vector2(transform.position.x-1, transform.position.y), Quaternion.identity);

                break;
            case 2:
                GameObject hurtbxr = Instantiate(hurtbxpre, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);

                break;
            case 3:
                GameObject hurtbxd = Instantiate(hurtbxpre, new Vector2(transform.position.x, transform.position.y-1), Quaternion.identity);
                break;
        }
        attk_time = 6;

    }
}
