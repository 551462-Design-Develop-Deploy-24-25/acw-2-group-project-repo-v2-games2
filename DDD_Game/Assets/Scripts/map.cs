using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Transform[] points;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < points.Length; i++)
        {
            lineRenderer.SetPosition(i,points[i].position);
        }
    }
}
