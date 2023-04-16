using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Object", menuName = "SO/SO_Object", order = 0)]
public class SO_Object : ScriptableObject
{    
    [SerializeField] string dayCount;
    public string DayCount => dayCount;

    [SerializeField] bool isEnabled;
    public bool IsEnabled => isEnabled;

    public void setDay(int _count)
    {
        string _day = _count >= 10 ? _day = "" : _day = "0";
        dayCount = _day + _count;
    }
    public void setDay(string _count)
    {
        dayCount = _count;
    }
    public void setEnabled(bool _type) { isEnabled = _type; }
}
