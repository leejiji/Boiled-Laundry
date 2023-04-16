using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Setting", menuName = "SO/SO_Setting", order = 1)]
public class SO_Setting : ScriptableObject
{
    [SerializeField] float all_volume;
    public float All_volume => all_volume;

    [SerializeField] float sfx_volume;
    public float Sfx_volume => sfx_volume;

    [SerializeField] float bgm_volume;
    public float Bgm_volume => bgm_volume;

    [SerializeField] float game_Speed;
    public float Game_Speed => game_Speed;

    public void SpeedSet(float _speed) { game_Speed = _speed; }
}
