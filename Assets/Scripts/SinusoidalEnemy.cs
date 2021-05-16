using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SinusoidalEnemy : MonoBehaviour {
  [Header("Configuration")]
  public float sinSpeed = 2;
  public float width = 6;
  public float forwardSpeed = 5;

  [Header("Information")]
  public Vector3 sin;

  void Update () {
    Vector3 newSin = Mathf.Sin(Time.time * sinSpeed) * (width / 2f) * PointOfView.Forward;
    transform.position = (transform.position - sin) + newSin;
    transform.position = transform.position - forwardSpeed * PointOfView.Right * Time.deltaTime;
    sin = newSin;
  }
}
