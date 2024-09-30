using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Playerのステータスの基礎を持つスクリプト
public class PlayerStatusEntity : MonoBehaviour
{
    public int HitPoint;
    public int Attack;
    public int Defence;
    public int AttackCount;

    public bool MissileFlag;
    public bool ArmorFlag;
    public bool ForceFlag;
    public bool SpikedFlag;

    //プレイヤーにステータスを反映する関数
    //----------------------------------------------------------
    public void SetHitPoint(int setHP)
    {
        HitPoint += setHP;
    }

    //プレイヤーの現在のステータスを渡す関数
    //----------------------------------------------------------
    public int GetHP()
    {
        return HitPoint;
    }

    public int GetAttack()
    {
        return Attack;
    }

    public int GetDefence()
    {
        return Defence;
    }

    public int GetAttackCount()
    {
        return AttackCount;
    }
    //----------------------------------------------------------

    //プレイヤーの特殊効果のフラグを渡す関数
    //----------------------------------------------------------
    public bool GetMissileFlag()
    {
        return MissileFlag;
    }

    public bool GetArmorFlag()
    {
        return ArmorFlag;
    }

    public bool GetForceFlag()
    {
        return ForceFlag;
    }

    public bool GetSpikedFlag()
    {
        return SpikedFlag;
    }

    //プレイヤーにステータスを書き込む関数
    //----------------------------------------------------------
}
