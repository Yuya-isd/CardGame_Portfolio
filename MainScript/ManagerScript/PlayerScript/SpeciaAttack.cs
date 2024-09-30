using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//特殊攻撃のscript
//関数の並び順で下に連れ優先度は低くなる

public class SpeciaAttack : MonoBehaviour
{
    //ArmorPiercing
    //一度だけ相手の攻撃を無効化
    public void Armor_Piercing(bool flag)
    {
        if (!flag) return;
        Debug.Log("無効化");

        flag = false;
    }

    //SpikedArmor
    //攻撃を受ける度に相手に1ダメージ反射
    public void Spiked_Armor(int spikedHP)
    {
        spikedHP += -1;
    }

    //MissileAttack
    //先制で相手に2ダメージ(固定)
    public void Missile_Attack(int deffenderHP)
    {
        deffenderHP += -2;
    }

    //ForceField
    //相手の防御力を無視
    public void Force_Field(int deffender)
    {
        deffender = 0;
    }
}
