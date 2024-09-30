using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player1のステータス
    public PlayerStatusEntity player1;

    //Player2のステータス
    public PlayerStatusEntity player2;

    //PlayArea
    [SerializeField]
    private GameObject playeAreaObject;

    private void Awake()
    {
        player1 = GameObject.Find("PlayerArea").GetComponent<PlayerStatusEntity>();
        player2 = GameObject.Find("EnemyArea").GetComponent<PlayerStatusEntity>();

        playeAreaObject = GameObject.Find("PlayArea");
    }

    //PlayAreaに配置したカードの効果を保持する関数
    public void PlayerStatus(CardController card)
    {
        //PlayAreaのオブジェクトがnullの状態なら再度検知
        if (playeAreaObject == null) playeAreaObject = GameObject.Find("PlayArea");

        List<GameObject> cards = new List<GameObject>();

        //PlayAreaの子オブジェクト分ループ
        for (int i = 0; i < playeAreaObject.transform.childCount; i++)
        {
            //cardsにPlayAreaの子オブジェクト分の要素を追加
            cards.Add(playeAreaObject.transform.GetChild(i).gameObject);

            //追加したオブジェクトのタグを確認し、それぞれにステータスを配分
            switch (cards[i].tag)
            {
                case "PlayerCard":
                    {
                        Debug.Log(cards[i].GetComponent<CardController>().cardModel.HitPoint);

                        //基礎ステータス
                        player1.SetHitPoint(cards[i].GetComponent<CardController>().cardModel.HitPoint);
                        player1.Attack += card.cardModel.Attack;
                        player1.Defence += card.cardModel.Defence;
                        player1.AttackCount += card.cardModel.AttackCount;

                        //特殊効果
                        player1.MissileFlag = card.cardModel.MissileFlag;
                        player1.ArmorFlag = card.cardModel.ArmorFlag;
                        player1.ForceFlag = card.cardModel.ForceFlag;
                        player1.SpikedFlag = card.cardModel.SpikedFlag;

                        break;
                    }

                case "EnemyCard":
                    {
                        //基礎ステータス
                        player2.HitPoint += card.cardModel.HitPoint;
                        player2.Attack += card.cardModel.Attack;
                        player2.Defence += card.cardModel.Defence;
                        player2.AttackCount += card.cardModel.AttackCount;

                        //特殊効果
                        player2.MissileFlag = card.cardModel.MissileFlag;
                        player2.ArmorFlag = card.cardModel.ArmorFlag;
                        player2.ForceFlag = card.cardModel.ForceFlag;
                        player2.SpikedFlag = card.cardModel.SpikedFlag;
                        break;
                    }
            }

        }
    }
}
