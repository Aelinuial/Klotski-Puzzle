using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessTwoX : MonoBehaviour
{
    Vector3 CalPosTwoX(int x, int y){
        return (GameManager.Instance.GetChessPos(x, y) + GameManager.Instance.GetChessPos(x, y + 1)) / 2;
    }

    public void OnMouseDown(){
        int idxx = (int)transform.position.z / 5;
        int idxy = (int)transform.position.x / 5;
        if(GameManager.Instance.CanPutChess(idxx + 1, idxy, Chess.TwoX, Dir.Up)){
            this.transform.position = CalPosTwoX(idxx + 1, idxy);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.TwoX);
            GameManager.Instance.SetChess(idxx + 1, idxy, Chess.TwoX);
        }
        else if(GameManager.Instance.CanPutChess(idxx, idxy - 1, Chess.TwoX, Dir.Left)){
            this.transform.position = CalPosTwoX(idxx, idxy - 1);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.TwoX);
            GameManager.Instance.SetChess(idxx, idxy - 1, Chess.TwoX);
        }
        else if(GameManager.Instance.CanPutChess(idxx - 1, idxy, Chess.TwoX, Dir.Down)){
            this.transform.position = CalPosTwoX(idxx - 1, idxy);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.TwoX);
            GameManager.Instance.SetChess(idxx - 1, idxy, Chess.TwoX);
        }
        else if(GameManager.Instance.CanPutChess(idxx, idxy + 1, Chess.TwoX, Dir.Right)){
            this.transform.position = CalPosTwoX(idxx, idxy + 1);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.TwoX);
            GameManager.Instance.SetChess(idxx, idxy + 1, Chess.TwoX);
        }
        GameManager.Instance.WinTest();
    }
}
