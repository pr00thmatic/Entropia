using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Piece : MonoBehaviour {
  [Header("Configuration")]
  public RandomRange lifeTime = new RandomRange(5, 8);
  public RandomRange blinks = new RandomRange(3, 5);
  public float blinkTime = 0.1f;

  [Header("Initialization")]
  public new Renderer renderer;

  void Reset () {
    renderer = GetComponent<Renderer>();
  }

  IEnumerator Start () {
    yield return new WaitForSeconds(lifeTime.Uniform);
    int b = blinks.IntUniform;

    for (int i=0; i<b; i++) {
      renderer.enabled = false;
      yield return new WaitForSeconds(blinkTime);
      renderer.enabled = true;
      yield return new WaitForSeconds(blinkTime);
    }

    Destroy(gameObject);
  }
}
