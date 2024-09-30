using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//カードデータを管理するscript
public class CardModel : MonoBehaviour
{
    public int CardID;
    public string CardName;
    public int HitPoint;
    public int Attack;
    public int Defence;
    public int AttackCount;
    public int tear;

    public bool MissileFlag;
    public bool ArmorFlag;
    public bool ForceFlag;
    public bool SpikedFlag;

    public Sprite backicon;
    public Sprite icon;

    public CardModel(int cardID)
    {
        //ファイルアドレスを指定し、カードのリソースを取得
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntity/Card" + cardID);

        cardID = cardEntity.CardID;
        CardName = cardEntity.CardName;
        HitPoint = cardEntity.HitPoint;
        Attack = cardEntity.Attack;
        Defence = cardEntity.Defence;
        AttackCount = cardEntity.AttackCount;
        tear = cardEntity.Tear;

        MissileFlag = cardEntity.MissileFlag;
        ArmorFlag = cardEntity.ArmorFlag;
        ForceFlag = cardEntity.ForceFlag;
        SpikedFlag = cardEntity.SpikedFlag;

        icon = cardEntity.icon;
        backicon = cardEntity.backicon;
    }
}
