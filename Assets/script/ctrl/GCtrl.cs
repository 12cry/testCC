using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DG.Tweening;
using testCC.Assets.script;
using UnityEngine;
namespace testCC.Assets.script {
	public class GCtrl : MonoBehaviour {

		public CardCtrl cardCtrlPrefab;
		public Queue<CardCtrl> cardCtrls = new Queue<CardCtrl> ();
		// public Transform tf1;
		// public Transform tf2;
		Tweener t1;
		void Start () {
			// init ();
		}

		void init () {
			print ("---init");

			string json = File.ReadAllText ("./Assets/Resources/cardBuild.json", Encoding.UTF8);

			List<CardBuild> cardBuildList = JsonConvert.DeserializeObject<List<CardBuild>> (json);
			// List<CardBuild> cardBuildList = JsonUtility.FromJson<List<CardBuild>> (json);
			print (cardBuildList.Count);

			List<Card> cardList = new List<Card> ();
			for (int i = 0; i < cardBuildList.Count; i++) {
				cardList.Insert (Random.Range (i, i + 1), cardBuildList[i]);
			}
			cardList.ForEach (card => {
				CardCtrl newCtrdCtrl = Instantiate<CardCtrl> (cardCtrlPrefab);
				newCtrdCtrl.card = card;
				card.cardCtrl = newCtrdCtrl;
				cardCtrls.Enqueue (newCtrdCtrl);
			});

		}
		public void fapai () {
			init ();
		}

		public void run () {

			print ("---run");
			// print (Screen.width);
			// print (Screen.height);
			// print (Screen.width*0.5f);
			// print (Screen.height*0.5f);
			// t1 = tf1.DOMove (new Vector3 (1, 1, 0), 2).SetAutoKill (false);
			// tf2.DOMove (new Vector3 (1, 1, 0), 2);

			int outCardNum = 2;

			for (int i = 0; i < outCardNum; i++) {
				CardCtrl cardCtrlPrefab = cardCtrls.Dequeue ();
				cardCtrlPrefab.transform.DOMove (new Vector3 (1, i * 5, 0), 2);
			}

		}
		public void reset () {

			print ("---reset");
			print (t1);
			// t1.Rewind (false);

			testJson ();
		}

		void testJson () {
			print ("---testJson");
			// cardBuildList.ForEach (card => {
			// 	print (card.cardName);
			// 	print (card.science);
			// });
			// cardList.Add(cardBuildList);
		}
	}
}