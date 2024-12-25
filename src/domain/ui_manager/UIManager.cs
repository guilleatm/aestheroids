using Aestheroids;
using Chickensoft.AutoInject;
using Chickensoft.Introspection;
using Godot;
using System;

namespace Aestheroids;
[Meta(typeof(IDependent))]
public partial class UIManager : Node, IUIManager
{
	public event Action OnPlayPressed;

	public override void _Notification(int what) => this.Notify(what);


	[Export] Button m_PlayButton;
	[Export] Label m_ScoreLabel;

	[Dependency]
	public IGameManager m_GameManager => this.DependOn<IGameManager>();

	public UIManager Create()
	{
		m_PlayButton.Pressed += () => OnPlayPressed.Invoke();
		return this;
	}

	public void OnResolved()
	{
		m_GameManager.OnGameOver += OnGameOver;
		m_GameManager.OnGameStarted += OnGameStarted;
		m_GameManager.Score.OnValueChanged += OnScoreChanged;
	}

	void OnScoreChanged(int oldValue, int newValue)
	{
		m_ScoreLabel.Text = newValue.ToString();
	}

	void OnGameStarted()
	{
		m_PlayButton.Visible = false;
	}

	void OnGameOver()
	{
		m_PlayButton.Visible = true;
	}
}
