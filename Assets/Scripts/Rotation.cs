using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rotation : MonoBehaviour {
  [Header("Configuration")]
  public float turnAroundAngle = 100;
  public float turnAroundTime = 0.5f;

  [Header("Information")]
  public float elapsedTurnAroundTime = 0;
  public float foundAngle;
  public float foundDot;

  [Header("Initialization")]
  public Motion motion;
  public Transform model;
  public Transform aim;

  void Update () {
    foundDot = Vector3.Dot(motion.smoothedUntimedMotion, motion.transform.forward);
    foundAngle = Vector3.Angle(aim.position - model.position, model.transform.forward);

    if (Vector3.Angle(aim.position - model.position, model.transform.forward) > turnAroundAngle &&
        Vector3.Dot(motion.smoothedUntimedMotion, model.transform.forward) < -0.1f) {
      elapsedTurnAroundTime += Time.deltaTime;
    } else {
      elapsedTurnAroundTime = 0;
    }

    if (elapsedTurnAroundTime > turnAroundTime) {
      model.Rotate(0, 180, 0);
    }
  }
}
