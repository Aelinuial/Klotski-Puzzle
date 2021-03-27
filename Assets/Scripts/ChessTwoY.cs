using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessTwoY : MonoBehaviour
{
    Vector3 CalPosTwoY(int x, int y){
        return (GameManager.Instance.GetChessPos(x, y) + GameManager.Instance.GetChessPos(x - 1, y)) / 2;
    }

    public void OnMouseDown(){
        int idxx = (int)transform.position.z / 5 + 1;
        int idxy = (int)transform.position.x / 5;

        if(GameManager.Instance.CanPutChess(idxx + 1, idxy, Chess.TwoY, Dir.Up)){
            this.transform.position = CalPosTwoY(idxx + 1, idxy);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.TwoY);
            GameManager.Instance.SetChess(idxx + 1, idxy, Chess.TwoY);
        }
        else if(GameManager.Instance.CanPutChess(idxx, idxy - 1, Chess.TwoY, Dir.Left)){
            this.transform.position = CalPosTwoY(idxx, idxy - 1);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.TwoY);
            GameManager.Instance.SetChess(idxx, idxy - 1, Chess.TwoY);
        }
        else if(GameManager.Instance.CanPutChess(idxx - 1, idxy, Chess.TwoY, Dir.Down)){
            this.transform.position = CalPosTwoY(idxx - 1, idxy);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.TwoY);
            GameManager.Instance.SetChess(idxx - 1, idxy, Chess.TwoY);
        }
        else if(GameManager.Instance.CanPutChess(idxx, idxy + 1, Chess.TwoY, Dir.Right)){
            this.transform.position = CalPosTwoY(idxx, idxy + 1);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.TwoY);
            GameManager.Instance.SetChess(idxx, idxy + 1, Chess.TwoY);
        }
        GameManager.Instance.WinTest();
    }
}
