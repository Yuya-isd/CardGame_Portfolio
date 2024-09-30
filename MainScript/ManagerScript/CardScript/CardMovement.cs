using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardMovement : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public Transform cardParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ドラッグを始める時の処理
    public void OnBeginDrag(PointerEventData eventData)
    {
        cardParent = transform.parent;
        transform.SetParent(cardParent.parent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    //ドラッグ中の処理
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    //ドラッグを終了するときの処理
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(cardParent, false);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
