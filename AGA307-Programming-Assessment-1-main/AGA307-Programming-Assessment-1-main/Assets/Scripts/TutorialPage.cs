using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class TutorialPage : MonoBehaviour
{
    public Transform tutorialPageHolder; //this holds pages
	public Transform[] pages;

	public int currentPage = 0;
	public TMP_Text pageCounter;

	void Awake()
	{
		pages = new Transform[tutorialPageHolder.childCount];

		for(int i =0; i < pages.Length; i++)
			pages[i] = tutorialPageHolder.GetChild(i);
	}

	private void OnEnable()
	{
		currentPage = 0;
		FlipPage(0);
	}

	public void FlipPage(int flipDirection)
	{
		//change and clamp number
		currentPage += flipDirection;
		currentPage = Mathf.Clamp(currentPage, 0, pages.Length);

		//turn all pages off
		for(int i = 0; i < pages.Length; i++)
			pages[i].gameObject.SetActive(false);

		//turn one we want on
		    pages[currentPage].gameObject.SetActive(true);

		string s = string.Format("{0}/{1}", (currentPage + 1), pages.Length);
		pageCounter.text = s;
	}

}
