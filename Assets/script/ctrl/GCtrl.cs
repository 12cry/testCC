using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DG.Tweening;
using Newtonsoft.Json;
using testCC.Assets.script;
using UnityEngine;
using UnityEngine.UI;

namespace testCC.Assets.script {
	public class GCtrl : MonoBehaviour {

		public CardCtrl cardCtrlPrefab;
		public Queue<CardCtrl> remainderCards = new Queue<CardCtrl> ();
		public Queue<CardCtrl> currentCards = new Queue<CardCtrl> ();
		Tweener t1;
		int cardWidth = 100;
		int currentCardLimitNum = 3;
		bool over = false;
		void Start () {
			init ();
		}

		void init () {
			print ("---init");

			string json = File.ReadAllText ("./Assets/Resources/cardBuild.json", Encoding.UTF8);
			List<CardBuild> cardBuildList = JsonConvert.DeserializeObject<List<CardBuild>> (json);

			List<Card> cardList = new List<Card> ();
			for (int i = 0; i < cardBuildList.Count; i++) {
				cardList.Insert (Random.Range (i, i + 1), cardBuildList[i]);
			}
			cardList.ForEach (card => {
				CardCtrl newCtrdCtrl = Instantiate<CardCtrl> (cardCtrlPrefab, cardCtrlPrefab.transform.parent);
				newCtrdCtrl.card = card;
				card.cardCtrl = newCtrdCtrl;
				remainderCards.Enqueue (newCtrdCtrl);
			});
			// run ();
		}

		public void computeCurrentCards () {

			Queue<CardCtrl> oldCurrentCards = new Queue<CardCtrl> ();
			Queue<CardCtrl> newCurrentCards = new Queue<CardCtrl> ();

			for (int i = 0; i < currentCardLimitNum; i++) {
				CardCtrl cardCtrl = currentCards.Dequeue ();
				if (cardCtrl == null) {
					if (over) {
						continue;
					}
					cardCtrl = remainderCards.Dequeue ();
					if (cardCtrl == null) {
						over = true;
						continue;
					}
					Card card = cardCtrl.card;
					Text[] texts = cardCtrl.GetComponentsInChildren<Text> ();
					Dictionary<string, Text> textDic = texts.ToDictionary (key => key.name, text => text);
					textDic["cardName"].text = card.cardName;
					if (card is CardBuild) {
						textDic["costScience"].text = ((CardBuild) card).costScience.ToString ();
					}
					newCurrentCards.Enqueue (cardCtrl);
				} else {
					oldCurrentCards.Enqueue (cardCtrl);
				}
			}
			oldCurrentCards.Concat (newCurrentCards);
			currentCards = oldCurrentCards;

		}
		public void showCurrentCards () {
			CardCtrl cardCtrl;
			int i = 0;
			while ((cardCtrl = currentCards.Dequeue ()) != null) {
				cardCtrl.transform.DOMove (new Vector3 (cardWidth / 2 + i++ * cardWidth, Screen.height - cardWidth / 2, 0), 1);
			}
		}

		public void run () {
			print ("---run");
			print (Screen.width);
			print (Screen.height);

			if (over) {
				print ("---over");
				return;
			}
			computeCurrentCards ();
			showCurrentCards ();

		}
		public void reset () {
			print ("---reset");
			print (t1);
			// t1.Rewind (false);
		}

		public void test1 () {
			print ("---test1");
			init ();
		}

	}
}