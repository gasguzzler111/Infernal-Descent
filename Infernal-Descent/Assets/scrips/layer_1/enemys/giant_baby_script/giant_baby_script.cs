using UnityEngine;
using UnityEngine.AI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform players;
    NavMeshAgent agent;
    //[SerializeField] private GameObject player;
    //[SerializeField] private float HP = 100;
    //[SerializeField] private float player_dis;
    //[SerializeField] private GameObject hurtbxpre;
    //[SerializeField] private bool is_attk = false;
    //[SerializeField]private float attk_time = 6;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = 2;
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(players.transform.position);

        //player_dis = Vector2.Distance(transform.position, player.transform.position);
        //if (HP <= 0)
        //{
        //    Destroy(gameObject);
        //}
        //if (player_dis >= 1.5 && is_attk == false)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime);

        //}
        //else  if ( player_dis < 1.5)
        //{
        //    attk_time -= Time.deltaTime;
        //}
        //if (attk_time <= 0) 
        //{
        //    attk();
        //}
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("bullet"))
    //    {
    //        Debug.Log("hit");
    //        bullet_script bullet = other.gameObject.GetComponent<bullet_script>();
    //        HP -= 20;
    //        bullet.bullet_hit();
    //    }
    //}
    //public void attk()
    //{
    //    GameObject hurtbx = Instantiate(hurtbxpre, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    //    attk_time = 6;
        
    //}
}
