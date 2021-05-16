using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MotionCameraLookAtTarget : MonoBehaviour {
  [Header("Configuration")]
  public float maxDistance = 5.2f;

  [Header("Initialization")]
  public Gun gun;
  public Transform root;

  void Update () {

    transform.localPosition = Vector3.ClampMagnitude(root.InverseTransformPoint(gun.aimTarget), maxDistance);
  }
}
