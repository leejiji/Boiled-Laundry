using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Player", menuName = "SO/SO_Player", order = 2)]
public class SO_Player : ScriptableObject
{
    [SerializeField] int money;
    public int Money => money;

    [SerializeField] int happyCount;
    public int HappyCount => happyCount;

    [SerializeField] bool isMove;
    public bool IsMove => isMove;

    public void setMove(bool _type) { isMove = _type; }
    public void setMoney(int _money, int _type = 0)
    {
        if(_type == 0)
            money += _money;
        else
            money = _money;
    }
    public void setHappy(int _happy, int _type = 0)
    {
        if (_type == 0)
            happyCount += _happy;
        else
            happyCount = _happy;
    }
}
