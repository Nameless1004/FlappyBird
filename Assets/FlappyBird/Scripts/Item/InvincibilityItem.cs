using System.Collections;
using UnityEngine;

public class InvincibilityItem : Item
{
    public void Start()
    {
        _renderer = GetComponent<SpriteRenderer>(); 
        _collider = GetComponent<Collider2D>();
    }
    public void Update()
    {
        transform.Translate(_moveSpeed * Time.deltaTime * TimeManager.Instance.TimeScale * Vector3.left);
    }
    public override void Execution()
    {
        StartCoroutine("Invincibility", _durationTime);
    }

    public IEnumerator Invincibility(float duration)
    {
        GameManager.player.Renderer.material.EnableKeyword("HOLOGRAM_ON");
        GameManager.player.IsInvincibility = true;
        TimeManager.Instance.TimeScale = 2;

        yield return new WaitForSeconds(duration);

        GameManager.player.Renderer.material.DisableKeyword("HOLOGRAM_ON");
        GameManager.player.IsInvincibility = false;
        TimeManager.Instance.TimeScale = 1;
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Execution();
        _renderer.enabled = false;
    }
}
