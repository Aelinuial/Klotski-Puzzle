using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Chess{
    Empty, One, TwoX, TwoY, Four, Out
};

public enum Dir{
    Up, Left, Right, Down
};

public class GameManager : MonoBehaviour
{

#region single instance

    private static GameManager instance;
    public static GameManager Instance{ get { return instance; } }

    void Awake(){
        instance = this;
    }

#endregion

    private Chess[,] chessMap;//记录地图位置和棋子的对应
    private Vector3[,] chessMapPos;//地图每个点的位置

    public GameObject chessOne;
    public GameObject chessTwoX;
    public GameObject chessTwoY;
    public GameObject chessFour;

    public void ClearChess(int x, int y, Chess chess){
        switch(chess){
            case Chess.One:
                chessMap[x, y] = Chess.Empty;
                break;
            case Chess.TwoX:
                chessMap[x, y] = Chess.Empty;
                chessMap[x, y + 1] = Chess.Empty;
                break;
            case Chess.TwoY:
                chessMap[x, y] = Chess.Empty;
                chessMap[x - 1, y] = Chess.Empty;
                break;
            case Chess.Four:
                chessMap[x, y] = Chess.Empty;
                chessMap[x - 1, y] = Chess.Empty;
                chessMap[x - 1, y + 1] = Chess.Empty;
                chessMap[x, y + 1] = Chess.Empty;
                break;
        }
    }

    public void SetChess(int x, int y, Chess chess){
        switch(chess){
            case Chess.One:
                chessMap[x, y] = Chess.One;
                break;
            case Chess.TwoX:
                chessMap[x, y] = Chess.TwoX;
                chessMap[x, y + 1] = Chess.TwoX;
                break;
            case Chess.TwoY:
                chessMap[x, y] = Chess.TwoY;
                chessMap[x - 1, y] = Chess.TwoY;
                break;
            case Chess.Four:
                chessMap[x, y] = Chess.Four;
                chessMap[x - 1, y] = Chess.Four;
                chessMap[x - 1, y + 1] = Chess.Four;
                chessMap[x, y + 1] = Chess.Four;
                break;
        }
    }

    public bool CanPutChess(int x, int y, Chess chess, Dir dir){
        switch(chess){
            case Chess.One:
                return GetChess(x, y) == Chess.Empty;
            case Chess.TwoX:
                if(dir == Dir.Up || dir == Dir.Down)
                    return GetChess(x, y) == Chess.Empty && GetChess(x, y + 1) == Chess.Empty;
                else if(dir == Dir. Left)
                    return GetChess(x, y) == Chess.Empty;
                else return GetChess(x, y + 1) == Chess.Empty;
            case Chess.TwoY:
                if(dir == Dir.Left || dir == Dir.Right)
                    return GetChess(x, y) == Chess.Empty && GetChess(x - 1, y) == Chess.Empty;
                else if(dir == Dir.Up)
                    return GetChess(x, y) == Chess.Empty;
                else return GetChess(x - 1, y) == Chess.Empty;
            case Chess.Four:
                if(dir == Dir.Up)
                    return GetChess(x, y) == Chess.Empty && GetChess(x, y + 1) == Chess.Empty;
                else if(dir == Dir.Left)
                    return GetChess(x, y) == Chess.Empty && GetChess(x - 1, y) == Chess.Empty;
                else if(dir == Dir.Right)
                    return GetChess(x, y + 1) == Chess.Empty && GetChess(x - 1, y + 1) == Chess.Empty;
                else
                    return GetChess(x - 1, y) == Chess.Empty && GetChess(x - 1, y + 1) == Chess.Empty; 
            default:
                return false;
        }
    }

    public Chess GetChess(int x, int y){
        if(x > 4 || y > 3) return Chess.Out;
        if(x < 0 || y < 0) return Chess.Out;
        return chessMap[x, y];
    }

    public Vector3 GetChessPos(int x, int y){
        return chessMapPos[x, y];
    }

    public void CalculateMap(){
        Vector3 pos;
        for(int i = 0; i < 5; i++){
            for(int j = 3; j >= 0; j--){
                switch(chessMap[i, j]){
                    case Chess.One:
                        Instantiate(chessOne, chessMapPos[i, j], transform.rotation);
                        break;
                    case Chess.TwoX:
                        chessMap[i, j + 1] = Chess.TwoX;
                        pos = (chessMapPos[i, j] + chessMapPos[i, j + 1]) / 2;
                        Instantiate(chessTwoX, pos, transform.rotation);
                        break;
                    case Chess.TwoY:
                        chessMap[i - 1, j] = Chess.TwoY;
                        pos = (chessMapPos[i - 1, j] + chessMapPos[i, j]) / 2;
                        Instantiate(chessTwoY, pos, transform.rotation);
                        break;
                    case Chess.Four:
                        chessMap[i - 1, j] = Chess.Four;
                        chessMap[i, j + 1] = Chess.Four;
                        chessMap[i - 1, j + 1] = Chess.Four;
                        pos = (chessMapPos[i, j] + chessMapPos[i - 1, j] + chessMapPos[i, j + 1] + chessMapPos[i - 1, j + 1]) / 4;
                        Instantiate(chessFour, pos, transform.rotation);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void Start()
    {   
        //棋盘初始化
        chessMap = new Chess[5, 4];
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 4; j++){
                chessMap[i, j] = Chess.Empty;
            }
        }
        chessMapPos = new Vector3[5, 4];
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 4; j++){
                 chessMapPos[i, j] = new Vector3(5.0f * j, 0f, 5.0f * i);
            }
        }
        //放置棋子
        
        chessMap[0, 1] = Chess.One;
        chessMap[0, 2] = Chess.One;
        chessMap[1, 1] = Chess.One;
        chessMap[1, 2] = Chess.One;

        chessMap[4, 0] = Chess.TwoY;
        chessMap[2, 0] = Chess.TwoY;
        chessMap[4, 3] = Chess.TwoY;
        chessMap[2, 3] = Chess.TwoY;

        chessMap[2, 1] = Chess.TwoX;
        
        chessMap[4, 1] = Chess.Four;

        CalculateMap();
    }

    public void WinTest()
    {
        if(chessMap[1, 1] == Chess.Four){
            Debug.Log("Win!");
        }
    }
}
