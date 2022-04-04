using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    public static Ball Current;
    public GameObject[] balls;
    public GameObject ballOutParent;
    public GameObject ballParent;
    [SerializeField] float touchSpeed;
    public int ballCount;
    public List<GameObject> ballList;
    public List<GameObject> ballInMachine;
    




    void Awake()
    {
        ballList[0].transform.parent = ballParent.transform;

        //balls[1].transform.parent = ballParent.transform;


    }

    private void Start()
    {





        Current = this;
        ballInMachine.Add(ballList[0]);
        //StartCoroutine(Wait());



        Vector3 firstBallPos = new Vector3(0, 1, 0);
        ballList[0].transform.localPosition = firstBallPos;
        //Vector3 secondBallPos = new Vector3(0, 1.5f, 0);
        //balls[1].transform.localPosition = secondBallPos;


    }
    private void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    ballInMachine[0].transform.SetParent;
        //}
        ballCount = ballInMachine.Count;
        if (Input.touchCount > 0)
        {
             StartCoroutine(BallUp());

        }
        if (Input.touchCount == 0 && ballInMachine[0].transform.localPosition.y > 1)
        {
            StartCoroutine(BallDown());
        }
        Debug.Log(ballCount);
        //StartCoroutine(BallMovement());



    }
    public void BallPull()
    {

        ballList[0].transform.parent = ballParent.transform;

        ballInMachine.Add(ballList[0]);
        StartCoroutine(Wait());

        
        ballInMachine[ballCount].transform.localPosition =  new Vector3(0,ballInMachine[ballCount-1].transform.localPosition.y + 0.5f, 0);

    }

    public void BallPush()
    {

    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.01f);
        ballList.RemoveAt(0);

    }
    IEnumerator BallUp()
    {
        for (int i = 0; i < ballCount; i++)
        {

            ballInMachine[i].transform.localPosition = new Vector3(0, ballInMachine[i].transform.localPosition.y + 0.062f*Time.deltaTime, 0);
            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator BallDown()
    {
        for (int i = ballCount-1; i >= 0; i--)
        {

            ballInMachine[i].transform.localPosition = new Vector3(0, ballInMachine[i].transform.localPosition.y - 0.062f*Time.deltaTime, 0);
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator BallMovement()
    {

        if (Input.touchCount > 0)
        {
            for (int j = 0; j < 1; j++)
            {
                for (int i = 0; i < ballCount; i++)
                {
                    
                    
                    yield return new WaitForSeconds(0.1f);
                    Debug.Log("yukarý çýkýyor");
                }
            }


        }

        else if (Input.touchCount == 0 && ballInMachine[0].transform.localPosition.y > 1)
        {
            for (int i = ballCount - 1; i >= 0; i--)
            {
                Vector3 ballPosition = new Vector3(ballInMachine[i].transform.localPosition.x, ballInMachine[i].transform.localPosition.y - touchSpeed * Time.deltaTime, ballInMachine[i].transform.localPosition.z);
                ballInMachine[i].transform.localPosition = ballPosition;
                yield return new WaitForSeconds(0.1f);
                Debug.Log("aþaðý iniyor");
            }
            //Vector3 ballPosition = new Vector3(ballInMachine[0].transform.localPosition.x, ballInMachine[0].transform.localPosition.y - touchSpeed * Time.deltaTime, ballInMachine[0].transform.localPosition.z);
            //ballInMachine[0].transform.localPosition = ballPosition;

            //for (int i = 0; i < ballCount; i++)
            //{
            //    if (i>0)
            //    {
            //        Vector3 targetPosition = new Vector3(ballInMachine[i - 1].transform.localPosition.x, ballInMachine[i - 1].transform.localPosition.y - 0.5f, ballInMachine[i - 1].transform.localPosition.z);
            //        ballInMachine[i].transform.localPosition = Vector3.Lerp(ballInMachine[i].transform.localPosition, targetPosition, lerpValue);
            //    }


            //    yield return new WaitForSeconds(0.1f);
            //}
        }



        //for (int j = 0; j < ballCount; j++)
        //{
        //    if (Input.touchCount == 0 && ballInMachine[0].transform.position.y > 1)
        //    {
        //        Vector3 ballPosition = new Vector3(ballParent.transform.position.x, ballParent.transform.position.y - touchSpeed * Time.deltaTime, ballParent.transform.position.z);
        //        ballInMachine[j].transform.position = ballPosition;
        //    }


        //    yield return new WaitForSeconds(0.1f);
        //}

    }



}
