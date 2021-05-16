using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProgrammedDeath : MonoBehaviour {
  public float time = 0.5f;

  IEnumerator Start () {
    yield return new WaitForSeconds(time);
    Destroy(gameObject);
  }
}
