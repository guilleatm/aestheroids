using Aestheroids;
using Godot;
using System;

namespace Aestheroids;
public partial class UIManager : Node
{
	[Export] Label m_ScoreLabel;
	public UIManager Create(IGameManager gameManagerUseCase)
	{

		gameManagerUseCase.Score.OnValueChanged += OnScoreChanged;

		return this;
	}

	void OnScoreChanged(int oldValue, int newValue)
	{
		m_ScoreLabel.Text = newValue.ToString();
	}
}
