using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatorino : MonoBehaviour
{

    public float _rotateSpeed = 5f;
    public float _radius = 0.1f;

    private Vector2 center;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        center = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        angle += _rotateSpeed * Time.deltaTime;

        Vector2 offset = new Vector2(Mathf.Sin(angle) * 2, Mathf.Cos(angle)) * _radius;
        transform.position = center + offset;
    }
}
