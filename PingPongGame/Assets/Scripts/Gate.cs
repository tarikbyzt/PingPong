using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Ball"))
        {
            Ball.Current.BallPull();


            Debug.Log("2 top kazanýldý");
            gameObject.GetComponent<Collider>().enabled = false;

        }



    }


}
