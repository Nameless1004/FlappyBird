using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingHorizon : MonoBehaviour
{
    public float ScrollSpeed;
    public Transform[] backgrounds;
    public float leftPosX = -9f;
    public float rightPosX = 9;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].position += new Vector3(-ScrollSpeed, 0, 0) * Time.deltaTime * Time.timeScale;

            if (backgrounds[i].position.x < leftPosX)
            {
                backgrounds[i].position = new Vector3(rightPosX, backgrounds[i].position.y);
            }
        }
    }
}
