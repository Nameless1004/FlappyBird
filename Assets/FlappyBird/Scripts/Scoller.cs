using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoller : MonoBehaviour
{
    public float ScrollSpeed;
    public Vector2 StartPosition;
    public Vector2 EndPosition;
    public Vector2 Direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EndPosition.x > transform.position.x)
        {
            transform.position = new Vector2(StartPosition.x, transform.position.y);
        }
        transform.position += (Vector3)(Direction * ScrollSpeed * Time.deltaTime * TimeManager.Instance.TimeScale);
    }
}
