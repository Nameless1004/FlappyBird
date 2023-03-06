using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private int _poolingCount = 10;
    [SerializeField]
    private float _spawnInterval = 1f;
    [SerializeField]
    private GameObject _columnPrefab;
    [SerializeField]
    private List<GameObject> _columns;
    [SerializeField]
    private Vector3 _spawnPivot;

    [Space]
    [SerializeField]
    private float _maxRange;
    [SerializeField]
    private float _minRange;
    


    

    void Start()
    {
        for (int i = 0; i < _poolingCount; ++i)
        {
            _columns.Add(Instantiate(_columnPrefab, _spawnPivot, Quaternion.identity, transform));
        }
        StartCoroutine("Spawner", _spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator Spawner(float interval)
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(interval);
        }
    }

    public void StopSpawn()
    {
        StopCoroutine("Spawner");
    }

    public void Spawn()
    {
        Vector3 offset = Vector3.zero;
        offset.y = Random.Range(_minRange, _maxRange);

        for (int i = 0; i < _columns.Count; ++i)
        {
            if (_columns[i].activeSelf == false)
            {
                _columns[i].transform.position = _spawnPivot + offset;
                _columns[i].SetActive(true);
                break;
            }
        }
    }
}
