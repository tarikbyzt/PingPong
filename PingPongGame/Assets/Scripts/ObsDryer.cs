using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObsDryer : MonoBehaviour
{
    public static ObsDryer Current;
    public  float deadBallPos;
    public int deadBallIndex;
    Vector3 startPosY, endPosY;
    GameObject deadBall;


    // Start is called before the first frame update
    void Start()
    {
        
        Current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        //startPosY = transform.position;
        //endPosY = new Vector3(transform.position.x, transform.position.y + deadBallPos, transform.position.z);
        //Debug.Log(deadBallIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        deadBall = other.gameObject;
        deadBallIndex = Ball.Current.ballInMachine.IndexOf(deadBall);

        //if (transform.position.y > deadBallPos)
        //{

        //    Debug.Log("top aþaðýya iniyor");
        //    // transform.localPosition = Vector3.Lerp(startPosY, endPosY, 0.1f);

        //}
        for (int i = deadBallIndex; i < Ball.Current.ballInMachine.Count; i++)
        {
            Ball.Current.ballInMachine[i].transform.DOMoveY(-0.5f, 1);
        }
        
        Ball.Current.ballInMachine.Remove(deadBall);
       
        deadBallPos = other.transform.localPosition.y;
        other.transform.parent = Ball.Current.ballOutParent.transform;
        gameObject.GetComponent<Collider>().enabled = false;
        
    }
    
}
