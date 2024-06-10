using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GioiHanKhungHinh : MonoBehaviour
{
    [SerializeField] public Transform top, bottom, left, right;
    public float GetVertical()
    {
        return Mathf.Abs(top.position.y) + Mathf.Abs(bottom.position.y);
    }
    public float GetHozirontal()
    {
        return Mathf.Abs(left.position.x) + Mathf.Abs(right.position.x);
    }
}
