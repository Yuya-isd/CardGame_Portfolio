using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AttackPhase : MonoBehaviour
{
    [SerializeField]
    private SpeciaAttack spAttack;

    // Start is called before the first frame update
    void Start()
    {
        spAttack = new SpeciaAttack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackTurnClac(PlayerStatusEntity player1,PlayerStatusEntity player2)
    {
        //Player1とPlayer2のAttackCountの数値を比較する
        //Player1のAttackCountの数値が大きい場合 or AttackCountの数値が同じの場合
        if(player1.AttackCount >= player2.AttackCount)
        {
            //Player1のArmorFlagを検知し、trueならArmor_Piercingを発動
            if (player1.ArmorFlag) spAttack.Armor_Piercing(player1.ArmorFlag);

            //Player2のArmorFlagを検知し、trueならArmor_Piercingを発動
            if (player2.ArmorFlag) spAttack.Armor_Piercing(player2.ArmorFlag);

            //Player2のミサイルフラグを検知
            if (player2.MissileFlag) spAttack.Missile_Attack(player1.HitPoint);

            //Player1のミサイルフラグを検知
            if (player1.MissileFlag) spAttack.Missile_Attack(player2.HitPoint);

            //Player1をAttackerとして設定
            Attack(player1, player2);
        }

        //Player2のAttackCountの数値が大きい場合
        if (player1.AttackCount < player2.AttackCount)
        {
            //Player1のミサイルフラグを検知
            if (player1.MissileFlag) spAttack.Missile_Attack(player2.HitPoint);

            //Player2のミサイルフラグを検知
            if (player2.MissileFlag) spAttack.Missile_Attack(player1.HitPoint);

            //Player2をAttackerとして設定
            Attack(player2,player1);
        }
    }

    private void Attack(PlayerStatusEntity attacker, PlayerStatusEntity defender)
    {
        //防御側がArmorPiercingを選択していた場合、ダメージ発生時に攻撃無効化


        //Defenderに対して攻撃
        defender.HitPoint -= (attacker.Attack - defender.Defence);

        //Attackerに対して攻撃
        attacker.HitPoint -= (defender.Attack - attacker.Defence);
    }
}
