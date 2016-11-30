using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{

	public Question[] questions;
	private static List<Question> unansweredQuestions;

	private Question currentQuestion;

	void Start ()
	{
		if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
			unansweredQuestions = questions.ToList<Question> ();
		}

		GetRandomQuestion ();
	}

	void GetRandomQuestion ()
	{
		int randomQuestionIndex = Random.Range (0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions [randomQuestionIndex];

		unansweredQuestions.RemoveAt (randomQuestionIndex);
	}

}
