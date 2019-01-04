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
		public Queue<CardCtrl> remainderCardCtrls = new Queue<CardCtrl> ();
		public CardCtrl[] currentCardCtrls;
		Tweener t1;
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
				remainderCardCtrls.Enqueue (newCtrdCtrl);
			});

			currentCardCtrls = new CardCtrl[currentCardLimitNum];
			// run ();
		}

		CardCtrl getANewCard () {
			if (remainderCardCtrls.Count == 0) {
				return null;
			}
			CardCtrl cardCtrl = remainderCardCtrls.Dequeue ();
			Card card = cardCtrl.card;
			Text[] texts = cardCtrl.GetComponentsInChildren<Text> ();
			Dictionary<string, Text> textDic = texts.ToDictionary (key => key.name, text => text);
			textDic["cardName"].text = card.cardName;
			if (card is CardBuild) {
				CardBuild cb = (CardBuild) card;
				textDic["costScience"].text = cb.cost.science.ToString ();
			}
			return cardCtrl;
		}
		public void computeCurrentCards () {
			CardCtrl cardCtrl;
			int removeCardNum = 1;
			int index = 0;

			for (int i = 0; i < currentCardLimitNum; i++) {
				cardCtrl = currentCardCtrls[i];
				if (cardCtrl == null) {
					continue;
				}
				if (cardCtrl.card.taked) {
					currentCardCtrls[i] = null;
					continue;
				}
				if (i < removeCardNum) {
					Object.Destroy (cardCtrl.gameObject);
				} else {
					currentCardCtrls[index] = cardCtrl;
					currentCardCtrls[i] = null;
					index++;
				}
			}

			for (int i = index; i < currentCardLimitNum; i++) {
				cardCtrl = getANewCard ();
				if (cardCtrl == null) {
					over = true;
					break;
				}
				currentCardCtrls[i] = cardCtrl;
			}

		}
		public void showCurrentCards () {
			for (int i = 0; i < currentCardCtrls.Length; i++) {
				if (currentCardCtrls[i] == null) {
					break;
				}
				currentCardCtrls[i].card.canAction = false;
				currentCardCtrls[i].card.canTake = true;
				currentCardCtrls[i].transform.DOMove (new Vector3 (Utils.cardWidth / 2 + i * Utils.cardWidth, Screen.height - Utils.cardWidth / 2, 0), 2);

				currentCardCtrls[i].card.takeCiv = 1 + i / 5;
			}
		}

		public void run () {
			print ("---run");
			// print (Screen.width);
			// print (Screen.height);

			if (over) {
				print ("---over");
				return;
			}
			computeCurrentCards ();
			showCurrentCards ();

		}
		public void reset () {
			print ("---reset");
			// t1.Rewind (false);

			// while (remainderCardCtrls.Count != 0) {
			// 	print ("---remainderCardCtrls");
			// 	CardCtrl cardCtrl = remainderCardCtrls.Dequeue ();
			// 	Object.Destroy (cardCtrl.gameObject);
			// }

			// for (int i = 0; i < currentCardLimitNum; i++) {
			// 	if (currentCardCtrls[i] == null) {
			// 		continue;
			// 	}
			// 	Object.Destroy (currentCardCtrls[i].gameObject);
			// }
			over = false;
			init ();
		}

		public void test1 () {
			print ("---test1");
			init ();
		}

	}
}