using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessOne : MonoBehaviour
{
    Vector3 CalPosOne(int x, int y){
        return GameManager.Instance.GetChessPos(x, y);
    }

    public void OnMouseDown(){
        int idxx = (int)transform.position.z / 5;
        int idxy = (int)transform.position.x / 5;
        if(GameManager.Instance.CanPutChess(idxx + 1, idxy, Chess.One, Dir.Up)){
            this.transform.position = CalPosOne(idxx + 1, idxy);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.One);
            GameManager.Instance.SetChess(idxx + 1, idxy, Chess.One);
        }
        else if(GameManager.Instance.CanPutChess(idxx, idxy - 1, Chess.One, Dir.Left)){
            this.transform.position = CalPosOne(idxx, idxy - 1);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.One);
            GameManager.Instance.SetChess(idxx, idxy - 1, Chess.One);
        }
        else if(GameManager.Instance.CanPutChess(idxx - 1, idxy, Chess.One, Dir.Down)){
            this.transform.position = CalPosOne(idxx - 1, idxy);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.One);
            GameManager.Instance.SetChess(idxx - 1, idxy, Chess.One);
        }
        else if(GameManager.Instance.CanPutChess(idxx, idxy + 1, Chess.One, Dir.Right)){
            this.transform.position = CalPosOne(idxx, idxy + 1);
            GameManager.Instance.ClearChess(idxx, idxy, Chess.One);
            GameManager.Instance.SetChess(idxx, idxy + 1, Chess.One);
        }
        GameManager.Instance.WinTest();
    }
}
