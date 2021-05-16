using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour {
  [Header("Configuration")]
  public float speed = 8;

  [Header("Initialization")]
  public Rigidbody body;
  public ParticleSystem explosion;
  public BulletDamage damage;

  void Reset () {
    body = GetComponent<Rigidbody>();
  }

  IEnumerator Start () {
    yield return new WaitForSeconds(2);
    Destroy(gameObject);
  }

  void FixedUpdate () {
    body.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
  }

  void OnCollisionEnter (Collision c) {
    ParticleSystem x = Instantiate(explosion);
    x.transform.position = c.GetContact(0).point + c.GetContact(0).normal * 0.1f;
    x.transform.forward = transform.forward - 2*(Vector3.Dot(transform.forward, c.GetContact(0).normal)) * c.GetContact(0).normal;

    if (c.collider.GetComponentInParent<IShootable>() != null) {
      c.collider.GetComponentInParent<IShootable>().GetShot(damage);
    }

    Destroy(gameObject);
    // Debug.Break();
  }
}
