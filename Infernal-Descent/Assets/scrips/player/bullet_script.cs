using UnityEngine;

public class bullet_script : MonoBehaviour
{
    [SerializeField] private float speed = 10; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("bullet_hit", 6f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
    public void bullet_hit()
    {
        Destroy(gameObject);    
    }
}
