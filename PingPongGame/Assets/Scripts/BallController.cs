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
        bool deadBall = ObsDryer.Current.deadBall;
        startPosY = transform.position;
        endPosY = new Vector3(transform.position.x, transform.position.y + ObsDryer.Current.deadBallPos, transform.position.z);
        if ( deadBall)
        {
            //transform.position.y > ObsDryer.Current.deadBallPos
            Debug.Log("top aþaðýya iniyor");
            // transform.localPosition = Vector3.Lerp(startPosY, endPosY, 0.1f);
            transform.DOLocalMoveY(0.5f, 0);
            ObsDryer.Current.deadBall = false;
        }
    }

    void FixedUpdate()
    {

        if (inWindZone == true)
        {

            Debug.Log("space");
            rb.AddForce(Vector3.right * 20);

        }

        if (racket == true)
        {

            Debug.Log("space");
            rb.AddForce(Vector3.left * 20);
            rb.AddForce(Vector3.back * 20);
        }



    }

    private void OnTriggerEnter(Collider coll)
    {

        if (coll.gameObject.tag == "obsDryer")
        {
            StartCoroutine(Timer());
            rb.isKinematic = false;
            inWindZone = true;
        }

        if (coll.gameObject.tag == "obsRacket")
        {
            rb.isKinematic = false;
            racket = true;
        }


        if (coll.gameObject.CompareTag("PositiveGate"))
        {
            Debug.Log("Top Geldi");

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
