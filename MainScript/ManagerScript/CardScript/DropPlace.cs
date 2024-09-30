using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour,IDropHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        //ドラッグしているカードの情報を取得
        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();

        if(card != null)
        {
            //カードの親をアタッチしているオブジェクトに変更
            card.cardParent = this.transform;
        }
    }
}
