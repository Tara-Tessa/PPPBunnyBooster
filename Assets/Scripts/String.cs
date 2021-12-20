using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class String : MonoBehaviour
{
    public Transform LeftPoint;
    public Transform RightPoint;
    public Transform CenterPoint;

    LineRenderer slingshotString;
    void Start()
    {
        slingshotString = GetComponent<LineRenderer>();
    }


    void Update()
    {
        slingshotString.SetPositions(new Vector3[3] { LeftPoint.position, CenterPoint.position, RightPoint.position });
    }
}
