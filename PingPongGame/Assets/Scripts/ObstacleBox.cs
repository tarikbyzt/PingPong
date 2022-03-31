using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBox : MonoBehaviour
{
    [SerializeField] float startValue = 0, endValue = 100, currentValue=0;
    [SerializeField] [Range(3.23f, 5.76f)] private float lerpValue=3.23f ;
    public BoxCollider coll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentValue =Mathf.Lerp(startValue, endValue, lerpValue);
    }
}
