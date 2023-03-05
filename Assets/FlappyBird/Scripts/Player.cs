using System.Collections;
using Unity.PlasticSCM.Editor.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpPower = 200f;


    public ParticleSystem DieParticle;

    [SerializeField]
    private GameEvent playerDieEvent;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rig2D;
    private Animator _animator;
    public bool _isDie = false;

    void Start()
    {
        _rig2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDie) return;
        if(_rig2D.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.z, 30f, _rig2D.velocity.y/8f));
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(transform.rotation.z, -90f, -_rig2D.velocity.y/8f));
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            _renderer.material.EnableKeyword("HOLOGRAM_ON");
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            _renderer.material.DisableKeyword("HOLOGRAM_ON");
        }
        if (Input.GetKeyDown(KeyCode.Space) && _isDie == false)
        {
            _rig2D.velocity = Vector2.zero;
            Vector2 jumpVec = Vector2.up * JumpPower;
            _rig2D.AddForce(jumpVec);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isDie == true) return;

        if (collision.collider.CompareTag("Obstacle") || collision.collider.CompareTag("Ground"))
        {
            _rig2D.constraints = RigidbodyConstraints2D.None;
            _rig2D.velocity = Vector2.zero;
            if (collision.collider.CompareTag("Obstacle"))
            {
                Vector2 dir = (transform.position - collision.collider.transform.position).normalized;
                float dotResult = Vector2.Dot(dir, collision.collider.transform.right);
                Debug.Log(dotResult);
                if (dotResult < 0f)
                {
                    _rig2D.AddForce(Vector3.left * 4, ForceMode2D.Impulse);
                    _rig2D.AddTorque(10f);
                }
                else
                {
                    _rig2D.AddForce(Vector3.right * 4, ForceMode2D.Impulse);
                    _rig2D.AddTorque(-10f);
                }
            }
            else
            {
                Vector2 force = new Vector2(1, 1) * 3;
                _rig2D.AddForce(force, ForceMode2D.Impulse);
                _rig2D.AddTorque(-10f);
            }

            _isDie = true;
            TimeManager.Instance.TimeScale = 0;
            _animator.SetBool("isDie", true);
            DieParticle.transform.position = transform.position;
            DieParticle.Play();
            
            StartCoroutine("Fadeout", 2);
        }

    }

    public IEnumerator Fadeout(float time)
    {
        float t = 0f;
        while(time > t)
        {
            t += Time.deltaTime;
            Color col = _renderer.color;
            col.a = Mathf.Lerp(1, 0, t/time);
            _renderer.color = col;
            yield return null;
        }
        Color color = _renderer.color;
        color.a = 0;
        _renderer.color = color;
        playerDieEvent.Raise();
        Destroy(gameObject);
    }
}

