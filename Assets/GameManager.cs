using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{

	public Question[] questions;
	private static List<Question> unansweredQuestions;

	private Question currentQuestion;

	[SerializeField]
	private Text factText;

	[SerializeField]
	private float timeBetweenQuestions = 1f;

	void Start ()
	{
		if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
			unansweredQuestions = questions.ToList<Question> ();
		}

		SetCurrentQuestion ();
	}

	void SetCurrentQuestion ()
	{
		int randomQuestionIndex = Random.Range (0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions [randomQuestionIndex];

		factText.text = currentQuestion.fact;

		unansweredQuestions.RemoveAt (randomQuestionIndex);
	}

	IEnumerator TransitionToNextQuestion ()
	{
		unansweredQuestions.Remove (currentQuestion);

		yield return new WaitForSeconds (timeBetweenQuestions);

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void UserSelectTrue ()
	{
		if (currentQuestion.isTrue) {
			
		} else {
			
		}

		StartCoroutine (TransitionToNextQuestion ());
	}

	public void UserSelectFalse ()
	{
		if (!currentQuestion.isTrue) {

		} else {

		}

		StartCoroutine (TransitionToNextQuestion ());
	}

}
