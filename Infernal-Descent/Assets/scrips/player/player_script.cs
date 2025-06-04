using UnityEngine;

public class player_script : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
}
