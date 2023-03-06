using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField]
    protected float _moveSpeed;
    protected Vector2 _position;
    protected SpriteRenderer    _renderer;
    protected Collider2D        _collider;
    
    [SerializeField]
    protected ParticleSystem _particle;

    [SerializeField]
    protected float _durationTime;
    public abstract void Execution();
}
