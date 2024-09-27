using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static StatusScript;
using System.Runtime.CompilerServices;
using System.Data;
using System.ComponentModel;

public class GameManager : MonoBehaviour
{
    const int DECK_CARD_NUM = 20;
    const int CARD_NUM = 13;

    public int currentTurn = 0;

    [SerializeField]
    private Transform playerHand,enemyHand;

    //ManagerScript
    public static GameManager instance;

    //カードコントローラ
    [SerializeField]
    private CardController cardPrefab;

    //プレイヤーコントローラ
    [SerializeField]
    private PlayerController player_Controller;

    //アタックコントローラ
    private AttackPhase attack_Controller;

    //PlayerDeck
    [SerializeField]
    private List<int> player1_deck = new List<int>();

    //Player2Deck
    [SerializeField]
    private List<int> player2_deck = new List<int>();

    //ObjectScript
    private GameObject PlayArea = null;

    //Flag
    private bool startFlag = false;

    public void Awake()
    {
        if (!instance) instance = this;
    }

    void Start()
    {
        currentTurn = 0;

        for (int i = 0; i < DECK_CARD_NUM; i++)
        {
            player1_deck.Add(Random.Range(1, 14));
            player2_deck.Add(Random.Range(1, 14));
        }

        PlayArea = GameObject.Find("PlayArea");
        player_Controller = GameObject.Find("PlayerManager").GetComponent<PlayerController>();
        attack_Controller = new AttackPhase();

        //StartGame();
        if(!startFlag) StartHand();

        cardPrefab.CardFilip(currentTurn);
    }

    void Update()
    {
        //Debug.Log(currentTurn);
    }

    private void StartGame()
    {
        //カードを1生成
        for (int i = 1; i <= CARD_NUM; i++)
        {
            CreateCard(i, playerHand);
            CreateCard(i, enemyHand);
        }
    }


    private void StartHand()
    {
        for (int i = 0; i <= 5; i++)
        {
            //Player1のカードをドローする
            Player1_DrawCard(playerHand);

            //Player2のカードをドローする
            Player2_DrawCard(enemyHand);

            startFlag = true;
        }
    }

    //カード生成
    private void CreateCard(int id,Transform place)
    {
        CardController card = Instantiate(cardPrefab, place);
        card.Init(id);
    }

    //Player1のカードドロー処理
    public void Player1_DrawCard(Transform hand)
    {
        //デッキが0の時はドローしない
        if (player1_deck.Count == 0) return;

        CardController[] playerCardList = playerHand.GetComponentsInChildren<CardController>();
        List<GameObject> cards = new List<GameObject>();

        //Player1の手札が5枚以下の際にドロー
        if (playerCardList.Length <= 5)
        {
            ////デッキからカードを1枚ドロー
            int cardID = player1_deck[0];
            player1_deck.RemoveAt(0);
            CreateCard(cardID, hand);
        }

        //Player1の手札にあるカードに対してPlayerCardのタグをつける
        for (int i = 0; i < playerHand.childCount; i++)
        {
            cards.Add(playerHand.GetChild(i).gameObject);
            cards[i].tag = "PlayerCard";
        }
    }

    public void Player2_DrawCard(Transform hand)
    {
        //デッキが0の時はドローしない
        if (player2_deck.Count == 0) return;

        CardController[] enemyCardList = enemyHand.GetComponentsInChildren<CardController>();
        List<GameObject> cards = new List<GameObject>();

        //手札の枚数が5枚以下の時にドロー
        if (enemyCardList.Length <= 5)
        {
            //デッキからカードを1枚ドロー
            int cardID = player2_deck[0];
            player2_deck.RemoveAt(0);
            CreateCard(cardID, hand);
        }

        //Player2の手札にあるカードに対してEnemyCardのタグをつける
        for (int i = 0; i < enemyHand.childCount; i++)
        {
            cards.Add(enemyHand.GetChild(i).gameObject);
            cards[i].tag = "EnemyCard";
        }
    }

    //ターン管理
    private void TurnCalc()
    {
        switch (currentTurn)
        {
            case 0:
                {
                    currentTurn = 1;
                    break;
                }

            //Player1のターン
            case 1:
                {
                    Player1Turn();
                    currentTurn = 2;
                    break;
                }

            //Player2のターン
            case 2:
                {
                    Player2Turn();
                    currentTurn = 3;
                    break;
                }

            //攻撃フェーズ
            case 3:
                {
                    Debug.Log("ステータス反映");

                    //Playerのステータスを反映
                    player_Controller.PlayerStatus(cardPrefab);
                    attack_Controller.AttackTurnClac(player_Controller.player1, player_Controller.player2);
                    
                    currentTurn = 1;
                    break;
                }

            default:
                break;
        }

        //カードを裏面表示
        cardPrefab.CardFilip(currentTurn);
    }

    //Player1のターン処理
    private void Player1Turn()
    {
        Player1_DrawCard(playerHand);
    }

    //Player2のターン処理
    private void Player2Turn()
    {
        Player2_DrawCard(enemyHand);
    }

    //readyボタン
    public void ChangeTurn()
    {
        switch (currentTurn)
        {
            case 0:
                {
                    TurnCalc();
                    break;
                }

            case 1:
                {
                    TurnCalc();
                    break;
                }

            case 2:
                {
                    TurnCalc();
                    break;
                }

            case 3:
                {
                    TurnCalc();
                    break;
                }

            default:
                break;
        }
    }

    //現在のターンを渡す関数
    public int GetCurrentTurn()
    {
        return currentTurn;
    }

    //プレイヤーのデッキを渡す関数
    public int GetPlayer1Deck(int i)
    {
        int deck = player1_deck[i];
        return deck;
    }

    public int GetPlayer2Deck(int i)
    {
        int deck = player2_deck[i];
        return deck;
    }

    //public int GetPlayArea_CardID(int i)
    //{
    //    return deck;
    //}

    public void TurnCounter()
    {
        //if (currentTurn == 1)
        //{
        //   for (int i = 0; i < PlayerHand.Count; i++)
        //    {
        //        PlayerHand[i].GetComponent<CardFlipper>().Flip();
        //    }

        //   for (int i =0; i <EnemyHand.Count; i++)
        //    {
        //        EnemyHand[i].GetComponent<CardFlipper>().Flip();
        //    }

        //    uiSwapper.SwapHands(); 
        //}

        //currentTurn++;

        //if (currentTurn > 3)
        //{
        //    currentTurn = 1;
        //    for (int i = 0; i < PlayerHand.Count; i++)
        //    {
        //        PlayerHand[i].GetComponent<CardFlipper>().Flip();
        //        EnemyHand[i].GetComponent<CardFlipper>().Flip();
        //    }
        //}
    }
}
