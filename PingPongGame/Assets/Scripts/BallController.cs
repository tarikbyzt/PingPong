using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 startPosY, endPosY;
    public bool inWindZone = false;
    public bool racket = false;
    [SerializeField] GameObject balls;
    [SerializeField] GameObject obsDryer;


    void Start()
    {
        
        balls = GameObject.FindWithTag("Balls");
        obsDryer = GameObject.FindWithTag("obsDryer");

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       

        startPosY = transform.position;
        endPosY = new Vector3(transform.position.x, transform.position.y + ObsDryer.Current.deadBallPos, transform.position.z);
        
    }

    

    void FixedUpdate()
    {
        

        if (inWindZone == true)
        {
            
            Debug.Log("space");
            rb.AddForce(Vector3.right * 20);

        }

    }

    private void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag == "obsDryer")
        {
            gameObject.GetComponent<Animator>().enabled = false;
            StartCoroutine(Timer());
            rb.isKinematic = false;
            inWindZone = true;
        }

    }

    /*
    private void Down()
    {
        Debug.Log("DoMoveY");
        transform.DOMoveY(-0.5f, 1);

    }*/

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.1f);
        obsDryer.SetActive(false);
    }
}
