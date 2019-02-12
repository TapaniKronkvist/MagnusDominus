using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform[] points;
    public Transform bossPosition;

    // Start is called before the first frame update
    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
            points[i].position = new Vector3(points[i].position.x, bossPosition.position.y, points[i].position.z);
        }
    }
}
