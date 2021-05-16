using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gun : MonoBehaviour {
  [Header("Configuration")]
  public float timeBetweenBullets = 0.2f;

  [Header("Information")]
  public float cooldown;
  public Vector3 aimTarget;

  [Header("Initialization")]
  public Transform origin;
  public GameObject bullet;
  public Transform bulletSpawnPoint;
  public BulletDamage damage;

  void Update () {
    float enter;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit)) {
      aimTarget = hit.point;
      origin.forward = hit.point - origin.transform.position;
    } else if (new Plane(-Vector3.forward, origin.transform.position).Raycast(ray, out enter)) {
      aimTarget = ray.GetPoint(enter);
      origin.forward = ray.GetPoint(enter) - origin.transform.position;
    }

    cooldown -= Time.deltaTime;
    if (cooldown < 0 && Input.GetMouseButton(0)) {
      Shoot();
      cooldown = timeBetweenBullets;
    }
  }

  public void Shoot () {
    GameObject bullet = Instantiate(this.bullet);
    bullet.transform.position = bulletSpawnPoint.position;
    bullet.transform.forward = origin.forward;
    bullet.GetComponent<Bullet>().damage = damage;
  }
}
