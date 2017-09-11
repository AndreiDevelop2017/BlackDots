using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
	//TODO: сделать сохранение счета, использовать TextMeshPro и отдельный Canvas
	private Text _currentText;
	private int _score;

	void OnEnable()
	{
		PlayerSpear.OnGoodMove += IncreaseScore;
		GameManager.OnLoseGame += ResetScore;
	}

	void OnDisable()
	{
		PlayerSpear.OnGoodMove -= IncreaseScore;
		GameManager.OnLoseGame -= ResetScore;
	}

	void Awake()
	{
		_currentText = GetComponent<Text> ();
		_score = 0;
	}

	void IncreaseScore()
	{
		_score++;
		_currentText.text = _score.ToString ();
	}

	void ResetScore()
	{
		_score = 0;
		_currentText.text = _score.ToString ();
	}
}
