using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletinDetail : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpBulletinNum;
    [SerializeField] private TMP_Text tmpL1, tmpL2, tmpL3, tmpL4, tmpL5, tmpL6;
    [SerializeField] private Colors colors;
    
    // Start is called before the first frame update
    void Start()
    {
        ResetAllText();
    }

    private void ResetText(TMP_Text tmp)
    {
        tmp.text =" ";
    }

    private void ResetAllText()
    {
        ResetText(tmpBulletinNum);
        ResetText(tmpL1);
        ResetText(tmpL2);
        ResetText(tmpL3);
        ResetText(tmpL4);
        ResetText(tmpL5);
        ResetText(tmpL6);
    }

    private void DisplayMention(TMP_Text tmp, Mention mention)
    {
        switch(mention)
        {
            case Mention.TB:
                tmp.text = "TB";
                tmp.color = colors.ColorTB;
                break;
            case Mention.B:
                tmp.text = "B";
                tmp.color = colors.ColorB;
                break;
            case Mention.AB:
                tmp.text = "AB";
                tmp.color = colors.ColorAB;
                break;
            case Mention.P:
                tmp.text = "P";
                tmp.color = colors.ColorP;
                break;
            case Mention.I:
                tmp.text = "I";
                tmp.color = colors.ColorI;
                break;
            case Mention.AR:
                tmp.text = "AR";
                tmp.color = colors.ColorAR;
                break;
            default:
                Debug.Log(":(");
                tmp.text = "TB";
                tmp.color = colors.ColorTB;
                break;
        }
    }

    public void UpdateNum(int num)
    {
        tmpBulletinNum.text = "Bulletin n°" + num.ToString();
    }

    public void DisplayBulletin(Bulletin bulletin)
    {
        DisplayMention(tmpL1, bulletin.L1);
        DisplayMention(tmpL2, bulletin.L2);
        DisplayMention(tmpL3, bulletin.L3);
        DisplayMention(tmpL4, bulletin.L4);
        DisplayMention(tmpL5, bulletin.L5);
        DisplayMention(tmpL6, bulletin.L6);
    }

}
