using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static StatusScript;
using Unity.VisualScripting;
using static UnityEditor.Experimental.GraphView.GraphView;

public class StatusViewScript : MonoBehaviour
{
    private PlayerStatusEntity player1,player2;
    private GameObject player1_StatusObject, player2_StatusObject;

    private void Awake()
    {
        player1 = GameObject.Find("PlayerArea").GetComponent<PlayerStatusEntity>();
        player2 = GameObject.Find("EnemyArea").GetComponent<PlayerStatusEntity>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateStatusView(GameObject statusObject,PlayerStatusEntity status)
    {
        statusObject.GetComponent<TextMeshProUGUI>().text =
            "HP:" + status.HitPoint + "\nAttack:" + status.Attack + "\nDefense:" + status.Defence + "\nAttackCount:" + status.AttackCount;
    }
}
