using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
public class GCtrl : MonoBehaviour {

	public Transform tf1;
	public Transform tf2;
	Tweener t1;
	void Start () {
		init();
	}

	void init () {
		// CardLibrary cardLibrary = GConfig.instance.cardLibrary;
		// List<Card> brightCardList1 = cardLibrary.BrightCardList1;
	}

	public void run () {

		print ("---run");
		// print (Screen.width);
		// print (Screen.height);
		// print (Screen.width*0.5f);
		// print (Screen.height*0.5f);
		t1 = tf1.DOMove (new Vector3 (1, 1, 0), 2).SetAutoKill (false);
		tf2.DOMove (new Vector3 (1, 1, 0), 2);

	}
	public void reset () {

		print ("---reset");
		print (t1);
		t1.Rewind (false);

	}
}