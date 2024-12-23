using Aestheroids;
using Godot;
using System;

namespace Aestheroids;
public partial class UIManagerUseCaseImpl : Node, UIManagerUseCase
{
	[Export] Label m_ScoreLabel;
	public UIManagerUseCaseImpl Create(GameManagerUseCase gameManagerUseCase)
	{

		gameManagerUseCase.Score.OnValueChanged += OnScoreChanged;

		return this;
	}

	void OnScoreChanged(int oldValue, int newValue)
	{
		m_ScoreLabel.Text = newValue.ToString();
	}
}
