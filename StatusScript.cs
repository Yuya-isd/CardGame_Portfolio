using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static StatusScript;
using static UnityEditor.Experimental.GraphView.GraphView;

public class StatusScript : MonoBehaviour
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
        ATTACKCOUNT_UP
    };

    //PlayerStatus
    [System.Serializable]
    public struct PlayerStatus
    {
        public int Hp;
        public int Attack;
        public int Defense;
        public int AttackCount;
        public bool missileFlag;
        public bool armorFlag;
        public bool forceFlag;
        public bool spikeFlag;
    }

    private PlayerStatus status;

    private void Awake()
    {
        //Debug.Log(status.missileFlag);
    }

    // Start is called before the first frame update
    void Start()
    {
        //ステータスの初期値を設定
        status.Hp = 4;
        status.Attack = 2;
        status.Defense = 1;
        status.AttackCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //プレイヤーが使用したカードの効果をロボットに反映する関数
    public void SelectCardEffect(string cardEffect)
    {
        //取得したCardEffectをプレイヤーに反映する
        switch (cardEffect)
        {
            //Card1
            case "ATTACK_1UP":
                {
                    status.Attack += 1;
                    break;
                }

            //Card2
            case "ATTACK_2UP":
                {
                    status.Attack += 2;
                    break;
                }

            //Card3
            case "ATTACK_3UP_HP_2DOWN":
                {
                    status.Attack += 3;
                    status.Hp -= 2;
                    break;
                }

            //Card4
            case "HP_2UP":
                {
                    status.Hp += 2;
                    break;
                }

            //Card5
            case "HP_3UP":
                {
                    status.Hp += 3;
                    break;
                }

            //Card6
            case "HP_4UP_ATTACK_1DOWN":
                {
                    status.Hp += 4;
                    status.Attack -= 1;
                    break;
                }

            //Card7
            case "DEFENSE_1UP":
                {
                    status.Defense += 1;
                    break;
                }

            //Card8
            case "DEFENSE_2UP":
                {
                    status.Defense += 2;
                    break;
                }

            //Card9
            case "ATTACKCOUNT_UP":
                {
                    status.AttackCount += 1;
                    break;
                }

            //Card10
            case "MISSILE_ATTACK":
                {
                    status.missileFlag = true;
                    break;
                }

            //Card11
            case "ARMOR_PIERCING":
                {
                    status.armorFlag = true;
                    break;
                }

            //Card12
            case "FORCE_FIELD":
                {
                    status.forceFlag = true;
                    break;
                }

            //Card13
            case "SPIKED_ARMOR":
                {
                    status.spikeFlag = true;
                    break;
                }

            default:
                break;
        }
    }

    //Statusの実数値を返す変数
    public PlayerStatus SetPlayerStatus()
    {
        return status;
    }

    //使用したカードの効果を反映する関数
    public void SetPlayerStatusUpdate(int formerHp, int formerAttack, int formerDefense, int formerAttackCout)
    {
        //HP
        formerHp += status.Hp;

        //Atatck
        formerAttack += status.Attack;

        //Defence
        formerDefense += status.Defense;

        //AttackCount
        formerAttackCout += status.AttackCount;
    }

    public void SetPlayerStatusUpdate(PlayerStatus player)
    {
        //HP
        player.Hp += status.Hp;

        //Atatck
        player.Attack += status.Attack;

        //Defence
        player.Defense += status.Defense;

        //AttackCount
        player.AttackCount += status.AttackCount;
    }

    //攻撃処理のまとめ
    public void AttackSummary(PlayerStatus player1,PlayerStatus player2)
    {
        //北朝鮮ミサイル
        if (player1.missileFlag || player2.missileFlag) MissileAttack(player1, player2);

        //ダメージ無効化
        if (player1.armorFlag || player2.armorFlag) ArmorPiercing(player1, player2);

        //防御力無視
        if (player1.forceFlag || player2.forceFlag) ForceField(player1, player2);

        //ダメージ反射
        if (player1.spikeFlag || player2.spikeFlag) SpikedArmor(player1 , player2);

        //ミサイル攻撃以外のフラグがfalseの場合Noamal攻撃
        if (!player1.armorFlag || !player2.armorFlag 
            || !player1.forceFlag || !player2.forceFlag
            || !player1.spikeFlag || !player2.spikeFlag)
        {
            NomalAttack(player1, player2);
        }
    }

    //通常攻撃の関数
    public void NomalAttack(PlayerStatus player1, PlayerStatus player2)
    {
        //プレイヤー1のロボットのAttackCountがプレイヤー2のAttackCountより大きい場合の処理
        if (player1.AttackCount > player2.AttackCount)
        {
            player2.Hp -= player1.Attack - player2.Defense;
        }

        //プレイヤー2のロボットのAttackCountがプレイヤー1のAttackCountより大きい場合の処理
        if (player1.AttackCount < player2.AttackCount)
        {
            player1.Hp -= player2.Attack - player1.Defense;
        }

        //プレイヤー1の攻撃処理
        player2.Hp -= player1.Attack - player2.Defense;

        //プレイヤー2の攻撃処理
        player1.Hp -= player2.Attack - player1.Defense;
    }

    //ミサイル攻撃の関数
    void MissileAttack(PlayerStatus p1, PlayerStatus p2)
    {
        if (p1.missileFlag) p2.Hp -= 2;

        else p1.Hp -= 2;
    }

    //ダメージ無効化の関数
    void ArmorPiercing(PlayerStatus p1, PlayerStatus p2)
    {
        //プレイヤー1のArmorFlagがtrueの処理
        if (p1.armorFlag)
        {
            //プレイヤー1のロボットのAttackCountがプレイヤー2のAttackCountより大きい場合の処理
            if (p1.AttackCount > p2.AttackCount)
            {
                p2.Hp -= p1.Attack - p2.Defense;
            }

            //プレイヤー2のロボットのAttackCountがプレイヤー1のAttackCountより大きい場合の処理
            if (p1.AttackCount < p2.AttackCount)
            {
                Debug.Log("ブロック");
            }

            //プレイヤー1の攻撃処理
            p2.Hp -= p1.Attack - p2.Defense;
        }

        //プレイヤー2のArmorFlagがtrueの処理
        else if (p2.armorFlag)
        {
            //プレイヤー1のロボットのAttackCountがプレイヤー2のAttackCountより大きい場合の処理
            if (p1.AttackCount > p2.AttackCount)
            {
                Debug.Log("ブロック");
            }

            //プレイヤー2のロボットのAttackCountがプレイヤー1のAttackCountより大きい場合の処理
            if (p1.AttackCount < p2.AttackCount)
            {
                p1.Hp -= p2.Attack - p1.Defense;
            }

            //プレイヤー2の攻撃処理
            p1.Hp -= p2.Attack - p1.Defense;
        }
    }

    //防御力無視の関数
    void ForceField(PlayerStatus p1, PlayerStatus p2)
    {
        if (p1.forceFlag)
        {
            p2.Hp -= p1.Attack;
        }

        else if (p2.forceFlag)
        {
            p1.Hp -= p2.Attack;
        }
    }

    //ダメージ反射の関数
    void SpikedArmor(PlayerStatus p1, PlayerStatus p2)
    {
        int spikedDamage = 0;

        if (p1.spikeFlag)
        {
            p1.Hp -= p2.Attack + p1.Defense;
            spikedDamage = p2.Attack + p1.Defense;
            p2.Hp -= spikedDamage;
        }

        else if (p2.spikeFlag)
        {
            p2.Hp -= p1.Attack + p2.Defense;
            spikedDamage = p1.Attack + p2.Defense;
            p1.Hp -= spikedDamage;
        }
    }

    public void ChangeScene_Result(PlayerStatus player1, PlayerStatus player2, bool flag)
    {
        if (player1.Hp <= 0 || player2.Hp <= 0)
        {
            flag = true;
        }   
    }
}
