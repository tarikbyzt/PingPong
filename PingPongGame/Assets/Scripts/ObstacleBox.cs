using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ObstacleBox : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer gloveMesh;
    [SerializeField] private Transform startTransform = null, endTransform = null;
    [SerializeField] [Range(0f, 1f)] private float lerpValue;
    float blendWeight;


    // Update is called once per frame
    void Update()
    {
        blendWeight = gloveMesh.GetBlendShapeWeight(0);
        lerpValue = 1 - (blendWeight / 100);
        Debug.Log("Lerp Value= " + lerpValue);
        transform.position = Vector3.Lerp(startTransform.position, endTransform.position, lerpValue);
    }
}
