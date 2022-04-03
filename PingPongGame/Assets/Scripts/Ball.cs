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
        StartCoroutine(Wait());



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
        Debug.Log(ballCount);
        StartCoroutine(BallMovement());



    }
    public void BallPull()
    {

        ballList[0].transform.parent = ballParent.transform;

        ballInMachine.Add(ballList[0]);
        StartCoroutine(Wait());

        Vector3 currentBallPos = new Vector3(ballInMachine[ballCount - 1].transform.localPosition.x, ballInMachine[ballCount - 1].transform.localPosition.y, ballInMachine[ballCount - 1].transform.localPosition.z);
        ballInMachine[ballCount].transform.localPosition = currentBallPos + new Vector3(0, 0.5f, 0);

    }

    public void BallPush()
    {

    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.01f);
        ballList.RemoveAt(0);

    }

    IEnumerator BallMovement()
    {

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < ballCount; i++)
            {
                Vector3 ballPosition = new Vector3(ballInMachine[i].transform.localPosition.x, ballInMachine[i].transform.localPosition.y + touchSpeed * Time.deltaTime, ballInMachine[i].transform.localPosition.z);
                ballInMachine[i].transform.localPosition = ballPosition;
                yield return new WaitForSeconds(0.1f);
                Debug.Log("yukarý çýkýyor");
            }

        }

        else if (Input.touchCount==0 && ballInMachine[0].transform.localPosition.y > 1)
        {
            for (int i = 0; i < ballCount; i++)
            {
                Vector3 ballPosition = new Vector3(ballInMachine[i].transform.localPosition.x, ballInMachine[i].transform.localPosition.y - touchSpeed * Time.deltaTime, ballInMachine[i].transform.localPosition.z);
                ballInMachine[i].transform.localPosition = ballPosition;
                yield return new WaitForSeconds(0.1f);
            }
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
