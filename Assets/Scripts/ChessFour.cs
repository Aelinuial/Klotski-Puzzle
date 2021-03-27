using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessFour : MonoBehaviour
{
    Vector3 CalPosFour(int x, int y){
        return (GameManager.Instance.GetChessPos(x, y) + GameManager.Instance.GetChessPos(x - 1, y)
                + GameManager.Instance.GetChessPos(x, y + 1) + GameManager.Instance.GetChessPos(x - 1, y + 1)) / 4;
    }

    public void OnMouseDown(){
        int idxx = (int)transform.position.z / 5 + 1;
        int idxy = (int)transform.position.x / 5;

        if(GameManager.Instance.CanPutChess(idxx + 1, idxy, Chess.Four, Dir.Up)){
            this.transform.position = CalPosFour(idxx + 1, idxy);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.Four);
            GameManager.Instance.SetChess(idxx + 1, idxy, Chess.Four);
        }
        else if(GameManager.Instance.CanPutChess(idxx, idxy - 1, Chess.Four, Dir.Left)){
            Debug.Log("111");
            this.transform.position = CalPosFour(idxx, idxy - 1);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.Four);
            GameManager.Instance.SetChess(idxx, idxy - 1, Chess.Four);
        }
        else if(GameManager.Instance.CanPutChess(idxx - 1, idxy, Chess.Four, Dir.Down)){
            this.transform.position = CalPosFour(idxx - 1, idxy);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.Four);
            GameManager.Instance.SetChess(idxx - 1, idxy, Chess.Four);
        }
        else if(GameManager.Instance.CanPutChess(idxx, idxy + 1, Chess.Four, Dir.Right)){
            this.transform.position = CalPosFour(idxx, idxy + 1);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.Four);
            GameManager.Instance.SetChess(idxx, idxy + 1, Chess.Four);
        }
        GameManager.Instance.WinTest();
    }
}
