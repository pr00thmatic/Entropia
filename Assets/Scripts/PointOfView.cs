using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointOfView : NonPersistentSingleton<PointOfView> {
  public static Vector3 Right { get => Utils.SetY(0, Instance.transform.right); }
  public static Vector3 Forward { get => Utils.SetY(0, Instance.transform.forward); }
}
