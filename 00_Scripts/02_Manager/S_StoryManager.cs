using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_StoryManager : MonoBehaviour
{
    [SerializeField] SO_Object so_object;
    [SerializeField] GameObject storyPanal;
    [SerializeField, Header("0 = prev / 1 = next")] GameObject[] g_Button = new GameObject[2];
    [SerializeField] Text descText;

    string s_name = "";
    string s_id;
    string s_count;

    List<Dictionary<string, object>> data_Dialog;
    int i_count = 0;
    int desc_num = 0;

    private void Start()
    {
        data_Dialog = CSVReader.Read("Story_Table");
    }
    public void startDesc(string _name, int count)
    {
        so_object.setEnabled(true);
        storyPanal.SetActive(true);
        i_count = count;
        desc_num = 0;

        g_Button[0].SetActive(false);
        g_Button[1].SetActive(true);

        s_name = _name;

        Buttons(0);
    }
    public void Buttons(int _desc)
    {        
        s_count = i_count < 10 ? s_count = string.Format("0{0}", i_count) : s_count = string.Format("{0}", i_count);

        s_id = string.Format("{0}_{1}", s_name, s_count);

        Debug.Log(s_id);

        desc_num += _desc;

        if (desc_num == 0)
            g_Button[0].SetActive(false);
        else
            g_Button[0].SetActive(true);

        Desc();
    }

    private void Desc()
    {
        for (int i = 0; i < data_Dialog.Count; i++)
        {
            if (data_Dialog[i]["id"] != null)
            {
                if ((string)data_Dialog[i]["id"] == s_id && (string)data_Dialog[i + desc_num]["id"] == s_id)
                {
                    descText.text = (string)data_Dialog[i + desc_num]["desc"];
                    return;
                }
            }
        }
        Desc_Over();
    }

    void Desc_Over()
    {
        so_object.setEnabled(false);
        storyPanal.SetActive(false);

        s_id = "";
        s_count = "";
        s_name = "";
        i_count = 0;
        desc_num = 0;
    }
}
