using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NguoiCHoi : MonoBehaviour
{
    private void Start()
    {
        Kiem kiemthuong = new Kiem();
        kiemthuong.TanCong();
        TinhNangThem kiemlua = new ThuocTinhLua();
        kiemlua.TanCong();
    }
}
