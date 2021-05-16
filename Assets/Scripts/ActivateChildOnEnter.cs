using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivateChildOnEnter : MonoBehaviour {
  void OnTriggerEnter (Collider c) {
    if (c.GetComponentInParent<Player>()) {
      foreach (Transform child in transform) {
        child.gameObject.SetActive(true);
      }
    }
  }
}
