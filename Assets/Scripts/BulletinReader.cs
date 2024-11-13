using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletinReader : MonoBehaviour
{
    [SerializeField] private Diagramme diagListe1, diagListe2, diagListe3, diagListe4, diagListe5, diagListe6;


    public void AddBulletin(Bulletin bulletin)
    {
        diagListe1.AddMention(bulletin.L1);
        diagListe2.AddMention(bulletin.L2);
        diagListe3.AddMention(bulletin.L3);
        diagListe4.AddMention(bulletin.L4);
        diagListe5.AddMention(bulletin.L5);
        diagListe6.AddMention(bulletin.L6);
    }

    public void RemoveBulletin(Bulletin bulletin)
    {
        diagListe1.RemoveMention(bulletin.L1);
        diagListe2.RemoveMention(bulletin.L2);
        diagListe3.RemoveMention(bulletin.L3);
        diagListe4.RemoveMention(bulletin.L4);
        diagListe5.RemoveMention(bulletin.L5);
        diagListe6.RemoveMention(bulletin.L6);
    }

    public void ComputeMentionScores(int totalBulletin)
    {
        diagListe1.DoScoreMention(totalBulletin);
        diagListe2.DoScoreMention(totalBulletin);
        diagListe3.DoScoreMention(totalBulletin);
        diagListe4.DoScoreMention(totalBulletin);
        diagListe5.DoScoreMention(totalBulletin);
        diagListe6.DoScoreMention(totalBulletin);
    }
}
