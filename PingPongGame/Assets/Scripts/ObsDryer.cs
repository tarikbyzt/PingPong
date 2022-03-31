using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsDryer : MonoBehaviour
{
    public static ObsDryer Current;
    public float deadBallPos;
    public bool deadBall = false;
    // Start is called before the first frame update
    void Start()
    {
        Current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        deadBall = true;
        
        gameObject.GetComponent<Collider>().enabled = false;
        deadBallPos = other.transform.localPosition.y;
    }
}
