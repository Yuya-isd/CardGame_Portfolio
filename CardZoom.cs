using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardZoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject canvas,playArea;
    GameObject zoomObject;

    public void Awake()
    {
        canvas = GameObject.Find("Main_Canvas");
    }

    //カーソルが合ったらカードを拡大
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GameManager.instance.currentTurn == 1 && gameObject.tag == "PlayerCard" ||
            GameManager.instance.currentTurn == 2 && gameObject.tag == "EnemyCard" ||
            GameManager.instance.currentTurn == 3)
        {
            //カーソルが合ったカードオブジェクトをコピーしてインスタンス
            zoomObject = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 250), Quaternion.identity);
            zoomObject.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;

            //ズームオブジェクトをキャンバスの親子関係に設定
            zoomObject.transform.SetParent(canvas.transform, true);

            //ズームオブジェクトの位置を設定
            RectTransform rectTransform = zoomObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(256, 375);
        }
    }

    //カーソルが外れたらカードを縮小
    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(zoomObject);
    }
}
