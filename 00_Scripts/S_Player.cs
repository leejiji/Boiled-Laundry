using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Player : MonoBehaviour
{
    [SerializeField] SO_Player so_player;
    [SerializeField] SO_Object so_Object;
    [SerializeField] SO_Setting so_setting;
    [SerializeField] Animator animator;

    private void Update()
    {
        if (so_player.IsMove && !so_Object.IsEnabled)
        {
            animator.SetInteger("AniType", 1);
            animator.speed = so_setting.Game_Speed;
        }
        else if(!so_player.IsMove)
        {
            animator.SetInteger("AniType", 0);
            animator.speed = 1;
        }
    }
}
