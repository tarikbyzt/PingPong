using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MachineController : MonoBehaviour
{
    [SerializeField] float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        transform.position = newPosition;

        
    }
}
