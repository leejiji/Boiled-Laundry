using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class S_TouchManager : MonoBehaviour
{
    [SerializeField] SO_Object so_object;
    [SerializeField] SO_Player so_player;
    [SerializeField] S_UIManager UIManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            S_SoundManager.Instance.PlaySFXSound(1);

            if (CastRay())
            {
                CastRay();                
            }
            else
            {
                if(!UIManager.Menuactive)
                    so_player.setMove(!so_player.IsMove);
            }
        }
    }


    bool CastRay()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null && hit.collider.tag == "NPC")
        {            
            if(so_object.IsEnabled == false)
            {
                hit.collider.gameObject.GetComponent<S_Object>().Interaction();
                so_player.setMove(false);
                return true;
            }            
        }
        else if(hit.collider != null && hit.collider.tag == "Object")
        {
            if (so_object.IsEnabled == false)
            {
                hit.collider.gameObject.GetComponent<S_Object>().Story();
                so_player.setMove(false);
                return true;
            }
        }
        else if(EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }

        return false;
    }
}
