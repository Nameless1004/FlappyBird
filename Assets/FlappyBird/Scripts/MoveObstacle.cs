using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float CountingPos;
    private bool isActive = true;
    public float DestroyPos;
    public float MoveSpeed;

    [Space]
    [SerializeField, Range(1f, 3f)]
    private float _columnSpacing;

    
    [Space]
    [SerializeField]
    private Transform topColumn;
    [SerializeField]
    private Transform bottomColumn;
    

    [SerializeField]
    private GameEvent columnDestroyedEvent;

    private void Awake()
    {
        Vector3 pos = bottomColumn.position;
        pos.y -= _columnSpacing / 2;
        bottomColumn.position = pos;
        pos = topColumn.position;
        pos.y += _columnSpacing / 2;
        topColumn.position = pos;
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        isActive = true;
    }

    void Update()
    {

        if (DestroyPos > transform.position.x)
        {
            gameObject.SetActive(false);
            return;
        }

        if(isActive == true && CountingPos > transform.position.x)
        {
            columnDestroyedEvent.Raise();
            isActive = false;
        }

        transform.position += MoveSpeed * Time.deltaTime * TimeManager.Instance.TimeScale * Vector3.left;
    }
}
