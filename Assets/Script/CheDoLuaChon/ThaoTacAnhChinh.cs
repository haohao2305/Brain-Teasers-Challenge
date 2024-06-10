using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThaoTacAnhChinh : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool isClick;
    public GameObject viewPanel;
    public GameObject chonSai;
    private Vector3 mousePosition;
    //
    private bool isHandInImg;
    private Vector2 point1;
    private Vector2 point2;
    private bool isZoom = false;

    [SerializeField] private GioiHanKhungHinh gioiHan;
    private float baseYPos;
    private void Start()
    {
        baseYPos = transform.position.y;
        gioiHan =  transform.parent.gameObject.transform.parent.gameObject.transform.parent.GetComponent<GioiHanKhungHinh>();
        Debug.Log(Camera.main.WorldToViewportPoint(transform.position));
    }
    void Update()
    {
        if (Input.touchCount == 2 && isHandInImg)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (!isZoom)
            {
                point1 = touch1.position;
                point2 = touch2.position;
                isZoom = true;
            }
            else
            {
                Vector2 touch1Pos = touch1.position;
                Vector2 touch2Pos = touch2.position;

                float khoangCachCu = Vector2.Distance(point1, point2);
                float khoangCachMoi = Vector2.Distance(touch1Pos, touch2Pos);
                float bienDoi = khoangCachMoi - khoangCachCu;

                float dieuChinh = bienDoi * 0.01f;

                Vector3 newScale = transform.localScale + new Vector3(dieuChinh, dieuChinh, 1);
                newScale = new Vector3(Mathf.Clamp(newScale.x, 1f, 2.5f), Mathf.Clamp(newScale.y, 1f, 2.5f), 1);

                transform.localScale = newScale;

                point1 = touch1Pos;
                point2 = touch2Pos;
            }
        }
        else
        {
            isZoom = false;
        }
    }
    IEnumerator demNguoc()
    {
        yield return new WaitForSeconds(2f);
        viewPanel.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isClick)
        {
            viewPanel.SetActive(true);
            chonSai.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            chonSai.transform.position = new Vector3(chonSai.transform.position.x, chonSai.transform.position.y, 0);
            chonSai.SetActive(true);
            Singleton.Instance.PlaySaiSoundEffect();
            StartCoroutine(demNguoc());
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isClick = true;
        mousePosition = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isHandInImg = true;
        isZoom = false;
    }

    public void DatThongTinDoiTuong(GameObject view, GameObject sai)
    {
        this.viewPanel = view;
        this.chonSai = sai;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isHandInImg = false;
        isZoom = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        isClick = false;
        Vector3 dragPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragPos.z = 0;
        Vector3 newPos = dragPos + mousePosition;
        float motNuaCanhBen = (gioiHan.GetVertical() / 2) * transform.localScale.x;
        float minX = (gioiHan.GetHozirontal() / 2) - motNuaCanhBen;
        minX = Mathf.Clamp(minX, minX, 0);
        float maxX = motNuaCanhBen - (gioiHan.GetHozirontal() / 2);
        maxX = Mathf.Clamp(maxX, 0, maxX);
        float minY = ((gioiHan.GetVertical() / 2) - motNuaCanhBen)+baseYPos;
        minY = Mathf.Clamp(minY, minY, baseYPos);
        float maxY = (motNuaCanhBen - (gioiHan.GetVertical() / 2))+baseYPos;
        maxY = Mathf.Clamp(maxY, baseYPos, maxY);

        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        transform.position = newPos;
    }
}
