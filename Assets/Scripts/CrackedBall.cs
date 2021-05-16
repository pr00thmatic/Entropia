using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrackedBall : MonoBehaviour, IShootable {
  [Header("Configuration")]
  public float maxHP;
  public Vector2 speed = new Vector2(10, 18);
  public Vector2 angular = new Vector2(180, 360);

  [Header("Information")]
  public float currentHP;

  [Header("Initialization")]
  public SkinnedMeshRenderer skin;
  public Transform pieces;

  void Update () {
    skin.SetBlendShapeWeight(0, 100 * (currentHP / maxHP));
  }

  public void GetShot (BulletDamage damage) {
    if (currentHP <= 0) {
      Explode();
      Destroy(gameObject);
    }
    currentHP = Mathf.Clamp(currentHP - damage.damage, 0, maxHP);
  }

  public void Explode () {
    pieces.gameObject.SetActive(true);
    pieces.transform.parent = null;
    foreach (Transform piece in pieces) {
      Rigidbody body = piece.GetComponent<Rigidbody>();
      body.isKinematic = false;
      body.angularVelocity = Random.insideUnitSphere * Random.Range(angular.x, angular.y);
      body.velocity = Random.insideUnitSphere * Random.Range(speed.x, speed.y);
    }
  }
}
