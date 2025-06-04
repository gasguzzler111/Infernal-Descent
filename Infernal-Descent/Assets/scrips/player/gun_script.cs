using Unity.Mathematics;
using UnityEngine;

public class gun_script : MonoBehaviour
{
    [SerializeField] private GameObject bulletpre;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletpre, new Vector2(transform.position.x,transform.position.y),transform.rotation);
        }
    }
}
