using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    //カードのビジュアルを処理
    public CardView cardView;

    //カードのデータを処理
    public CardModel cardModel,cardModel2;

    private void Awake()
    {
        cardView = GetComponent<CardView>();
    }

    //カードの生成時に呼び出しされる関数
    public void Init(int cardID)
    {
        //カードデータを生成
        cardModel = new CardModel(cardID);

        //カードを表示
        cardView.Show(cardModel);
    }

    //使用したカードを削除する関数
    public void DestroyCard(CardController card)
    {
        Destroy(card.gameObject);
    }

    //ターンによってカードの表裏を変更する関数
    public void CardFilip(int turn)
    {
        List<GameObject> list = new List<GameObject>();
        List<GameObject> list2 = new List<GameObject>();

        switch (turn)
        {
            case 0:
                {
                    list.Clear();
                    list2.Clear();

                    list.AddRange(GameObject.FindGameObjectsWithTag("PlayerCard"));
                    list2.AddRange(GameObject.FindGameObjectsWithTag("EnemyCard"));

                    for (int i = 0; i < list.Count; i++)
                    {
                        Debug.Log(GameManager.instance.GetPlayer1Deck(i));

                        cardModel = new CardModel(GameManager.instance.GetPlayer1Deck(i));
                        cardModel2 = new CardModel(GameManager.instance.GetPlayer2Deck(i));

                        //cardModel = list[i].GetComponent<CardModel>();
                        //cardModel2 = list2[i].GetComponent<CardModel>();

                        list[i].GetComponent<CardController>().cardView.ShowBack(cardModel);
                        list2[i].GetComponent<CardController>().cardView.ShowBack(cardModel2);
                    }

                    break;
                }

            //Player1のターンなのでPlayer2のカードを裏面にする
            case 1:
                {
                    list.Clear();
                    list2.Clear();

                    list.AddRange(GameObject.FindGameObjectsWithTag("PlayerCard"));
                    list2.AddRange(GameObject.FindGameObjectsWithTag("EnemyCard"));

                    //Player2のカードを裏面表示
                    for (int i = 0; i < list2.Count; i++)
                    {
                        cardModel2 = new CardModel(GameManager.instance.GetPlayer2Deck(i));
                        list2[i].GetComponent<CardController>().cardView.ShowBack(cardModel2);
                    }

                    //Player1のカードは表面を表示
                    for (int i = 0; i < list.Count; i++)
                    {
                        cardModel = new CardModel(GameManager.instance.GetPlayer1Deck(i));
                        list[i].GetComponent<CardController>().cardView.Show(cardModel);
                    }

                    break;
                }

            //Player2のターンなのでPlayer1のカードを裏面にする
            case 2:
                {
                    list.Clear();
                    list2.Clear();

                    list.AddRange(GameObject.FindGameObjectsWithTag("PlayerCard"));
                    list2.AddRange(GameObject.FindGameObjectsWithTag("EnemyCard"));

                    //Player1のカードを裏面表示
                    for (int i = 0; i < list.Count; i++)
                    {
                        cardModel = new CardModel(GameManager.instance.GetPlayer1Deck(i));
                        list[i].GetComponent<CardController>().cardView.ShowBack(cardModel);
                    }

                    for(int i = 0; i < list2.Count; i++)
                    {
                        cardModel2 = new CardModel(GameManager.instance.GetPlayer2Deck(i));
                        list2[i].GetComponent<CardController>().cardView.Show(cardModel2);
                    }

                    break;
                }

            //PlayAreaに置かれているカード以外は裏返しにする
            case 3:
                {
                    list.Clear();
                    list2.Clear();

                    GameObject playArea;
                    List<GameObject> playAreaCards = new List<GameObject>();

                    list.AddRange(GameObject.FindGameObjectsWithTag("PlayerCard"));
                    list2.AddRange(GameObject.FindGameObjectsWithTag("EnemyCard"));

                    playArea = GameObject.Find("PlayArea");

                    //PlayArea以外のカードを裏返し
                    //-------------------------------------------------------------------------------
                    for (int i = 0; i < list.Count; i++)
                    {
                        cardModel = new CardModel(GameManager.instance.GetPlayer1Deck(i));
                        list[i].GetComponent<CardController>().cardView.ShowBack(cardModel);
                    }

                    for (int i = 0; i < list2.Count; i++)
                    {
                        cardModel2 = new CardModel(GameManager.instance.GetPlayer2Deck(i));
                        list2[i].GetComponent<CardController>().cardView.ShowBack(cardModel);
                    }
                    //-------------------------------------------------------------------------------

                    //PlayAreaのカードは表を向ける
                    //-------------------------------------------------------------------------------
                    for (int i = 0; i < playArea.transform.childCount;i++)
                    {
                        //cardModel = new CardModel(GameManager.instance.GetPlayArea_CardID(i));

                        playAreaCards.Add(playArea.transform.GetChild(i).gameObject);
                        playAreaCards[i].GetComponent<CardController>().cardView.Show(cardModel);
                    }

                    //-------------------------------------------------------------------------------

                    break;
                }

            default:
                break;
        }
    }
}
