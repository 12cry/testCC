using System.Collections.Generic;
using Cry.Common;
using UnityEngine;

public class GConfig : Singleton<GConfig> {
    public CardLibrary cardLibrary2;
    public List<Card> brightCardList1;
    public List<CardBuild> darkCardList1;
    public T1 t1;
    public List<T1> t1List;
    public int aa;

    protected override void Awake () {
        base.Awake ();
    }
}