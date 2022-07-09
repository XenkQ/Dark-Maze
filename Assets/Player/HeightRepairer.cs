using UnityEngine;

public class HeightRepairer : MonoBehaviour
{
    private void FixedUpdate()
    {
        if(transform.position.y != 0)
        {
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
