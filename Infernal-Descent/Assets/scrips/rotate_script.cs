using UnityEngine;

public class rotate_script : MonoBehaviour
{
    public Transform crosshair;

    // Update is called once per frame
    void Update()
    {
        Vector3 crosshairpos = crosshair.transform.position;
        //rotates the gun
        Vector3 rotation = crosshairpos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

    }
}
