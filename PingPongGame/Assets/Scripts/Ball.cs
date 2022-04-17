using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject machine;
    public static Ball Current;
    [SerializeField] float speed;
    public bool finished = false;
    public GameObject ballOutParent;
    public GameObject ballParent;
    [SerializeField] float touchSpeed;
    public int ballCount;
    public GameObject[] balls;
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
        ballInMachine[0].GetComponent<Animator>().enabled = true;

        //Vector3 secondBallPos = new Vector3(0, 1.5f, 0);
        //balls[1].transform.localPosition = secondBallPos;
    }
    private void Update()
    {
        
        Vector3 newPosition = new Vector3(machine.transform.position.x, machine.transform.position.y, machine.transform.position.z + speed * Time.deltaTime);
        machine.transform.position = newPosition;

        ballCount = ballInMachine.Count;
        Debug.Log(ballCount);
        if (Input.touchCount > 0 && ballInMachine[ballCount-1].transform.position.y<16&&finished==false)
        {
            Touch first = Input.GetTouch(0);
            if (first.phase == TouchPhase.Stationary)
            {
                Vector3 ballPosition = new Vector3(ballParent.transform.position.x, ballParent.transform.position.y + touchSpeed * Time.deltaTime, ballParent.transform.position.z);
                ballParent.transform.position = ballPosition;

                Debug.Log("yukar� ��k�yor");
            }
        }
        else if (ballParent.transform.localPosition.y > 1.91f)
        {
            Vector3 ballPosition = new Vector3(ballParent.transform.position.x, ballParent.transform.position.y - touchSpeed * Time.deltaTime, ballParent.transform.position.z);
            ballParent.transform.position = ballPosition;
        }
        
        if (finished==true)
        {
            speed = 0;
            for (int i = ballCount-1; i >= 0; i--)
            {
                ballInMachine[i].GetComponent<Animator>().SetBool("finish", true);
                //StartCoroutine(FinishAnimation(i));
            }
        }



        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    ballInMachine[0].transform.SetParent;
        //}

        //if (Input.touchCount > 0)
        //{
        //     StartCoroutine(BallUp());

        //}
        //if (Input.touchCount == 0 && ballInMachine[0].transform.localPosition.y > 1)
        //{
        //    StartCoroutine(BallDown());
        //}

        //StartCoroutine(BallMovement());



    }
    public void BallPull()
    {

        ballList[0].transform.parent = ballParent.transform;

        ballInMachine.Add(ballList[0]);
        StartCoroutine(Wait());

        ballList[0].GetComponent<Animator>().enabled = true;
        ballInMachine[ballCount].transform.localPosition = new Vector3(0, ballInMachine[ballCount - 1].transform.localPosition.y + 0.5f, 0);

    }

    public void BallPush()
    {

    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.01f);
        ballList.RemoveAt(0);

    }
}
