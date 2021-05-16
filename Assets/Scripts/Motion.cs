using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Motion : MonoBehaviour {
  [Header("Configuration")]
  public float speed = 7;
  public float lateralSpeed = 4;
  public float animationSmoothTime = 0.1f;
  public float fallPreventerWidth = 1;

  [Header("Information")]
  public Vector3 smoothedUntimedMotion = Vector3.zero;
  public Vector3 currentSmoothVelocity = Vector3.zero;

  [Header("Initialization")]
  public Transform motionTarget;
  public Animator animator;
  public Transform model;

  void Update () {
    Vector3 deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed * PointOfView.Right;
    Vector3 deltaZ = Input.GetAxis("Vertical") * Time.deltaTime * speed * PointOfView.Forward;

    if (deltaX != Vector3.zero &&
        !Physics.Raycast((deltaX.normalized) * (fallPreventerWidth/2f) + deltaX + motionTarget.position + Vector3.up * 0.1f, -Vector3.up, 0.25f, LayerMask.GetMask("Floor"))) {
      deltaX = Vector3.zero;
    }
    if (deltaZ != Vector3.zero &&
      !Physics.Raycast((deltaZ.normalized) * (fallPreventerWidth/2f) + deltaZ + motionTarget.position + Vector3.up * 0.1f, -Vector3.up, 0.25f, LayerMask.GetMask("Floor"))) {
      deltaZ = Vector3.zero;
    }

    Vector3 motion = Vector3.ClampMagnitude(deltaX + deltaZ, speed * Time.deltaTime);
    Vector3 untimedMotion = motion / Time.deltaTime;
    smoothedUntimedMotion = Vector3.SmoothDamp(smoothedUntimedMotion, untimedMotion, ref currentSmoothVelocity, animationSmoothTime);
    motion = Vector3.Dot(motion, model.forward) * model.forward +
      Vector3.Dot(motion, model.right) * model.right * (lateralSpeed / speed);
    motionTarget.position += motion;

    animator.SetFloat("speed front", Vector3.Dot(smoothedUntimedMotion.normalized, model.forward));
    animator.SetFloat("speed side", Vector3.Dot(smoothedUntimedMotion.normalized, model.right));
    animator.SetBool("is running", untimedMotion.magnitude > 0.1f);
  }
}
