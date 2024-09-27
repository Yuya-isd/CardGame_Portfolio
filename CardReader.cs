using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static StatusScript;

public class CardReader : MonoBehaviour
{
    enum PlayerCards
    {
        None = -1,
        ATTACK_1UP,
        ATTACK_2UP,
        ATTACK_3UP_HP_2DOWN,
        HP_2UP,
        HP_3UP,
        HP_4UP_ATTACK_1DOWN,
        DEFENSE_1UP,
        DEFENSE_2UP,
        ATTACKCOUNT_UP,
        MISSILE_ATTACK,
        ARMOR_PIERCING,
        FORCE_FIELD,
        SPIKED_ARMOR
    };
    
    //プレイヤーが置ける最大の枚数
    const int PLAYER_MAXCARDS = 7;

    private PlayerCards cardEffect = PlayerCards.None;

    //CurrentTurn
    [SerializeField]
    private GameManager gameManagerScript = null;

    //PlayArea
    public GameObject PlayArea;

    [SerializeField]
    private StatusScript statusScript = null;

    [SerializeField]
    GameObject[] cardList = new GameObject[PLAYER_MAXCARDS];
    //private GameObject[] cards;
    //List<GameObject> cards = new List<GameObject>();

    [SerializeField]
    private List<string> cardsName = new List<string>();

    bool readFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();  
        statusScript = GameObject.Find("GameManager").GetComponent<StatusScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CardRread()
    {
        switch (gameManagerScript.GetCurrentTurn())
        {
            //Player1のターン
            case 1:
                {
                    Array.Clear(cardList, 0, cardList.Length);

                    for (int i = 0; i < PlayArea.transform.childCount; i++)
                    {
                        //PlayArea内に存在する子オブジェクトをリストに取得
                        cardList[i] = PlayArea.transform.GetChild(i).gameObject;
                    }
                    break;
                }

            //Player2のターン
            case 2:
                {
                    Array.Clear(cardList,0,cardList.Length);
                    for (int i = 0; i < PlayArea.transform.childCount; i++)
                    {
                        //PlayArea内に存在する子オブジェクトをリストに取得
                        cardList[i] = PlayArea.transform.GetChild(i).gameObject;
                    }
                    break;
                }
            
            //Atatckターン
            case 3:
                {

                    break;
                }

            default:
                break;
        }

        for (int i = 0; i < PlayArea.transform.childCount; i++)
        {
            //取得した子オブジェクトの名前を検索し、反映する効果を取得する
            if (cardList[i] != null) CardName();
        }

        //cards.AddRange(cardList);
    }

    private void CardName()
    {
        string cardName;

        for (int i = 0; i < PlayArea.transform.childCount; i++)
        {
            cardName = cardList[i].name.Replace("(Clone)","");

            switch (cardName)
            {
                case "Card1":
                    {
                        cardEffect = PlayerCards.ATTACK_1UP;
                        break;
                    }

                case "Card2":
                    {
                        cardEffect = PlayerCards.ATTACK_2UP;
                        break;
                    }

                case "Card3":
                    {
                        cardEffect = PlayerCards.ATTACK_3UP_HP_2DOWN;
                        break;
                    }

                case "Card4":
                    {
                        cardEffect = PlayerCards.HP_2UP;
                        break;
                    }

                case "Card5":
                    {
                        cardEffect = PlayerCards.HP_3UP;
                        break;
                    }

                case "Card6":
                    {
                        cardEffect = PlayerCards.HP_4UP_ATTACK_1DOWN;
                        break;
                    }

                case "Card7":
                    {
                        cardEffect = PlayerCards.DEFENSE_1UP;
                        break;
                    }

                case "Card8":
                    {
                        cardEffect = PlayerCards.DEFENSE_2UP;
                        break;
                    }

                case "Card9":
                    {
                        cardEffect = PlayerCards.ATTACKCOUNT_UP;
                        break;
                    }

                case "Card10":
                    {
                        cardEffect = PlayerCards.MISSILE_ATTACK;
                        break;
                    }

                case "Card11":
                    {
                        cardEffect = PlayerCards.ARMOR_PIERCING;
                        break;
                    }

                case "Card12":
                    {
                        cardEffect = PlayerCards.FORCE_FIELD;
                        break;
                    }

                case "Card13":
                    {
                        cardEffect = PlayerCards.SPIKED_ARMOR;
                        break;
                    }

                default:
                    continue;
            }

            //StatusScriptのSelectCardEffectを呼び出し
            statusScript.SelectCardEffect(cardEffect.ToString());
        }
    }
}
