using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Diagramme : MonoBehaviour
{
    [SerializeField] private MentionElement  me_TB, me_B, me_AB, me_P, me_I, me_AR;

    [SerializeField] private TMP_Text mentionScoreTMP;

    [SerializeField] private Colors colors;


    private void IncrementME(MentionElement me)
    {
        me.gameObject.SetActive(true);
        me.Increment();
    }

    private void DecrementME(MentionElement me)
    {
        me.Decrement();
    }

    public void AddMention(Mention mention)
    {
        MentionElement me;

        switch(mention)
        {
            case Mention.TB:
                me = me_TB;
                break;
            case Mention.B:
                me = me_B;
                break;
            case Mention.AB:
                me = me_AB;
                break;
            case Mention.P:
                me = me_P;
                break;
            case Mention.I:
                me = me_I;
                break;
            case Mention.AR:
                me = me_AR;
                break;
            default:
                Debug.Log(":(");
                me = me_TB;
                break;
        }
        IncrementME(me);
    }

    public void RemoveMention(Mention mention)
    {
        MentionElement me;

        switch(mention)
        {
            case Mention.TB:
                me = me_TB;
                break;
            case Mention.B:
                me = me_B;
                break;
            case Mention.AB:
                me = me_AB;
                break;
            case Mention.P:
                me = me_P;
                break;
            case Mention.I:
                me = me_I;
                break;
            case Mention.AR:
                me = me_AR;
                break;
            default:
                Debug.Log(":(");
                me = me_TB;
                break;
        }
        DecrementME(me);
    }

    private float GetScore(Mention medMention, int nbBulletin)
    {
        float pc, qc;
        switch(medMention)
        {
            case Mention.TB:
                pc = 0;
                qc = me_B.Number + me_AB.Number + me_P.Number + me_I.Number + me_AR.Number;
                break;
            case Mention.B:
                pc = me_TB.Number;
                qc = me_AB.Number + me_P.Number + me_I.Number + me_AR.Number;
                break;
            case Mention.AB:
                pc = me_TB.Number + me_B.Number;
                qc = me_P.Number + me_I.Number + me_AR.Number;
                break;
            case Mention.P:
                pc = me_TB.Number + me_B.Number + me_AB.Number;
                qc = me_I.Number + me_AR.Number;
                break;
            case Mention.I:
                pc = me_TB.Number + me_B.Number + me_AB.Number + me_P.Number;
                qc = me_AR.Number;
                break;
            case Mention.AR:
                pc = me_TB.Number + me_B.Number + me_AB.Number + me_P.Number + me_I.Number;
                qc = 0;
                break;
            default:
                pc = 0;
                qc = 0;
                Debug.Log(":(");
                break;
        }
        pc = pc/nbBulletin;
        qc = qc/nbBulletin;
        float score = (1f/2f) * (pc - qc)/(1 - pc - qc);
        return score;
    }

    private Mention GetMedMention(int nbBulletin)
    {
        int numMediane;
        int sum = 0;
        if (nbBulletin % 2 == 0)
        {
            numMediane = nbBulletin/2;
        }
        else
        {
            numMediane = nbBulletin/2 + 1;
        }
        if (me_AR.gameObject.activeSelf)
        {
            sum += me_AR.Number;
            if (sum >= numMediane)
            {
                return Mention.AR;
            }
        }
        if (me_I.gameObject.activeSelf)
        {
            sum += me_I.Number;
            if (sum >= numMediane)
            {
                return Mention.I;
            }
        }
        if (me_P.gameObject.activeSelf)
        {
            sum += me_P.Number;
            if (sum >= numMediane)
            {
                return Mention.P;
            }
        }
        if (me_AB.gameObject.activeSelf)
        {
            sum += me_AB.Number;
            if (sum >= numMediane)
            {
                return Mention.AB;
            }
        }
        if (me_B.gameObject.activeSelf)
        {
            sum += me_B.Number;
            if (sum >= numMediane)
            {
                return Mention.B;
            }
        }
        if (me_TB.gameObject.activeSelf)
        {
            sum += me_TB.Number;
            if (sum >= numMediane)
            {
                return Mention.TB;
            }
        }
        Debug.Log(":(((");
        return Mention.TB;
    }

    private void DisplayScoreMention(Mention mention, float score)
    {
        decimal decimalValue = Math.Round((decimal)score, 4);
        switch(mention)
        {
            case Mention.TB:
                mentionScoreTMP.text = "TB" + "\n" + decimalValue.ToString();
                mentionScoreTMP.color = colors.ColorTB;
                break;
            case Mention.B:
                mentionScoreTMP.text = "B" + "\n" + decimalValue.ToString();
                mentionScoreTMP.color = colors.ColorB;
                break;
            case Mention.AB:
                mentionScoreTMP.text = "AB" + "\n" + decimalValue.ToString();
                mentionScoreTMP.color = colors.ColorAB;
                break;
            case Mention.P:
                mentionScoreTMP.text = "P" + "\n" + decimalValue.ToString();
                mentionScoreTMP.color = colors.ColorP;
                break;
            case Mention.I:
                mentionScoreTMP.text = "I" + "\n" + decimalValue.ToString();
                mentionScoreTMP.color = colors.ColorI;
                break;
            case Mention.AR:
                mentionScoreTMP.text = "AR" + "\n" + decimalValue.ToString();
                mentionScoreTMP.color = colors.ColorAR;
                break;
            default:
                Debug.Log(":(");
                break;
        } 
    }

    public void DoScoreMention(int nbBulletin)
    {
        Mention medMention = GetMedMention(nbBulletin);
        float score = GetScore(medMention, nbBulletin);
        DisplayScoreMention(medMention, score);
    }
}