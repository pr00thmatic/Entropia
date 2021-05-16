using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class RandomRange {
  public float Max {
    get => Mathf.Max(a, b);
    set { if (a > b) a = value; else b = value; }
  }
  public float Min {
    get => Mathf.Min(a, b);
    set { if (a > b) b = value; else a = value; }
  }
  public float a;
  public float b;
  public float Uniform { get => Random.Range(a, b); }
  public int IntUniform { get => Random.Range((int) a, (int) b); }

  public RandomRange (float a, float b) {
    this.a = a;
    this.b = b;
  }

}
