using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//画面上のUIの処理を行うスクリプト
public class UIcontroller : MonoBehaviour
{
    private GameObject Player1Object, Player2Object;
    private GameObject Player1_Status, Player2_Status;
    private PlayerStatusEntity player1, player2;

    private StatusViewScript statusView;

    private GameObject readyButton = null;

    // Start is called before the first frame update
    void Start()
    {
        statusView = new StatusViewScript();

        Player1Object = GameObject.FindGameObjectWithTag("Player");
        Player2Object = GameObject.FindGameObjectWithTag("Enemy");

        Player1_Status = GameObject.FindGameObjectWithTag("Player1Status");
        Player2_Status = GameObject.FindGameObjectWithTag("Player2Status");

        player1 = GameObject.Find("PlayerArea").GetComponent<PlayerStatusEntity>();
        player2 = GameObject.Find("EnemyArea").GetComponent<PlayerStatusEntity>();

        //ステータスの表示を消す
        Player1_Status.SetActive(false);
        Player2_Status.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.instance.currentTurn)
        {
            case 0:
                {
                    Player1_Status.SetActive(false);
                    Player2_Status.SetActive(false);

                    Player1Object.SetActive(false);
                    Player2Object.SetActive(false);

                    break;
                }

            case 1:
                {
                    Player1_Status.SetActive(false);
                    Player2_Status.SetActive(false);

                    Player1Object.SetActive(true);
                    Player2Object.SetActive(false);
                    break;
                }

            case 2:
                {
                    Player1Object.SetActive(false);
                    Player2Object.SetActive(true);
                    break;
                }

            case 3:
                {
                    Player1_Status.SetActive(true);
                    Player2_Status.SetActive(true);

                    statusView.UpdateStatusView(Player1_Status, player1);
                    statusView.UpdateStatusView(Player2_Status, player2);

                    Player1Object.SetActive(false);
                    Player2Object.SetActive(false);

                    break;
                }

            default:
                break;
        }
    }
}
