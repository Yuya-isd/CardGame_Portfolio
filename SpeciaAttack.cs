using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����U����script
//�֐��̕��я��ŉ��ɘA��D��x�͒Ⴍ�Ȃ�

public class SpeciaAttack : MonoBehaviour
{
    //ArmorPiercing
    //��x��������̍U���𖳌���
    public void Armor_Piercing(bool flag)
    {
        if (!flag) return;
        Debug.Log("������");

        flag = false;
    }

    //SpikedArmor
    //�U�����󂯂�x�ɑ����1�_���[�W����
    public void Spiked_Armor(int spikedHP)
    {
        spikedHP += -1;
    }

    //MissileAttack
    //�搧�ő����2�_���[�W(�Œ�)
    public void Missile_Attack(int deffenderHP)
    {
        deffenderHP += -2;
    }

    //ForceField
    //����̖h��͂𖳎�
    public void Force_Field(int deffender)
    {
        deffender = 0;
    }
}
