using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishScript : MonoBehaviour
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
        for (int i = Ball.Current.ballCount - 1; i >= 0; i--)
        {
            Ball.Current.ballInMachine[i].transform.DOLocalMove(new Vector3(-3.273f, -2.77f, -7.616f),1 );
        }
    }
}
