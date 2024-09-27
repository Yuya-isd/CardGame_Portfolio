using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardEntity" , menuName = "CreateCardEntity")]

//カードの情報を保持するファイル
public class CardEntity : ScriptableObject
{
    public int CardID;
    public string CardName;
    public int HitPoint;
    public int Attack;
    public int Defence;
    public int AttackCount;
    public int Tear;

    public bool MissileFlag;
    public bool ArmorFlag;
    public bool ForceFlag;
    public bool SpikedFlag;

    public Sprite backicon;
    public Sprite icon;
}
