using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Kiem : TanCong
{
    public void TanCong()
    {
        Debug.Log("tan cong");
    }
}
public interface TanCong
{
    void TanCong();
}
public class TinhNangThem : TanCong
{
    Kiem kiem;
    public virtual void TanCong()
    {
        kiem.TanCong();
    }
}
public class ThuocTinhLua : TinhNangThem
{
    public override void TanCong()
    {
        base.TanCong();
        //dinh lua
    }
}
public class ThuocTinhBang : TinhNangThem
{
    public override void TanCong()
    {
        base.TanCong();
        //dinh lua
    }
}
