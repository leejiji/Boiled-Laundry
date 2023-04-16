using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class S_Object : MonoBehaviour
{
    [SerializeField] string s_name;
    [SerializeField] bool toDayInter = false;
    [SerializeField] SO_Object so_object;
    [SerializeField] SpriteOutline outline;
    [SerializeField] string eventDay;

    S_DescManager descManager;
    S_StoryManager storyManager;
    string tempDay = "";
    string[] Day = null;
    int obj_count = 1;

    private void Start()
    {
        outline = this.gameObject.GetComponent<SpriteOutline>();
        descManager = GameObject.Find("DescManager").GetComponent<S_DescManager>();
        storyManager = GameObject.Find("DescManager").GetComponent<S_StoryManager>();

        Day = eventDay.Split(',');
    }

    private void Update()
    {
        if (tempDay != so_object.DayCount)
        {
            tempDay = so_object.DayCount;
            toDayInter = false;

            if (eventDay != "")
            {
                for (int i = 0; i < Day.Length; i++)
                {
                    if(Day[i] == so_object.DayCount)
                    {
                        SetterActive(true);
                        break;
                    }
                    else
                    {
                        SetterActive(false);
                        break;
                    }
                        
                }
            }
            else
            {
                SetterActive(true);
            }
        }
    }
    public void Interaction()
    {
        if (tempDay != so_object.DayCount)
        {
            outline.outlineSize = 4;
        }

        if (!toDayInter)
        {
            descManager.startDesc(s_name, this.gameObject.GetComponent<SpriteRenderer>().sprite);
            toDayInter = true;
            outline.outlineSize = 0;
        }        
    }
    
    public void Story()
    {
        if (!toDayInter)
        {
            storyManager.startDesc(s_name, obj_count);
            toDayInter = true;
            obj_count++;
        }
    }

    void SetterActive(bool _active)
    {
        toDayInter = !_active;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = _active;
    }
}
