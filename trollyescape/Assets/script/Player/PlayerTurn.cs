using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public bool TurnNow{get;private set;} = false;

    [SerializeField]
    private TrollyController trollyController;

    public void Turn()
    {
        // ターンフラグがたっていないとき
        if(!trollyController.TurnFlag)
        {
            // 右に曲がる
            if (trollyController.Right)
            {
                if (!TurnNow)
                {
                    TurnNow = true;
                    StartCoroutine(turnMove(Const.TURN_NUM_MAX, Const.TURN_SPEED));
                }
            }
            // 左に曲がる
            else if (trollyController.Left)
            {
                if (!TurnNow)
                {
                    TurnNow = true;
                    StartCoroutine(turnMove(Const.TURN_NUM_MAX, -Const.TURN_SPEED));
                }
            }
                
            // どちらのフラグもたってない場合
            else
            {
                trollyController.Reset();
            }
        }
    }
    IEnumerator turnMove(int maxNum, float turnSpeed)
    {
        for (int turn = 0; turn < maxNum; turn++)
        {
            transform.Rotate(0, turnSpeed, 0);
            yield return new WaitForSeconds(Const.WAIT_CORUTINE);
            trollyController.PlayerSpeed = 0.0f;
        }
        TurnNow = false;
        trollyController.Reset();
    }

}
