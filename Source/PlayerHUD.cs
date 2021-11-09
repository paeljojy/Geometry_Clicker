using Godot;
using System;

public class PlayerHUD : CanvasLayer
{
	private SignalAttribute start_game_signal;
	private int totalScore = 0;
	private int progress = 40;
	private int maxProgress = 100;
	private bool gameInProgress = false;
	private Label GameOverLabelShadow { get; set; }
	private Timer EndGameTimer { get; set; }
	private ProgressBar OurProgressBar { get; set; }
	private Label ScoreShadowLabel { get; set; }

	public override void _Ready()
	{
		// EndGameTimer.Connect("timeout", this, "_on_EndGameTimer_timeout");
		EndGameTimer = GetNode<Timer>("EndGameTimer");
		GameOverLabelShadow = GetNode<Label>("GameOverLabelShadow");
		ScoreShadowLabel = GetNode<Label>("ScoreShadowLabel");
		OurProgressBar = GetNode<ProgressBar>("ProgressBar");
		start_game();
	}

	public void increase_score(int increase)
	{
		if (!gameInProgress)
			return;
		GD.Print("Score increased by: " + increase);
		totalScore += increase;
		GD.Print("New total is: " + totalScore);
		increase_progress(10);
		updateScore();
	}

	private void updateScore()
	{
		ScoreShadowLabel.Text = totalScore.ToString();
		ScoreShadowLabel.GetChild<Label>(0).Text = totalScore.ToString();
	}

	private void increase_progress(int delta)
	{
		if (!gameInProgress)
			return;
		progress += delta;
		if (progress > maxProgress)
		{
			progress = maxProgress;
		}

		updateProgress();
	}

	public void decrease_progress(int delta)
	{
		if (!gameInProgress)
			return;
		progress -= delta;
		updateProgress();
		if (progress <= 0)
			end_game();
	}

	private void end_game()
	{
		gameInProgress = false;
		EndGameTimer.Start();
		GameOverLabelShadow.Visible = true;
		GameOverLabelShadow.GetChild<Label>(0).Visible = true;
	}


	private void _on_EndGameTimer_timeout()
	{
		// Get shapes and destroy them
		var shapes = GetParent().GetChild(2).GetChildren();

		foreach (Node shape in shapes)
		{
			shape.QueueFree();
		}

		// Start a new game
		start_game();
	}

	private void start_game()
	{
		// Stop timer if it was running
		EndGameTimer.Stop();

		// Initialize game over label
		GameOverLabelShadow.Visible = false;
		GameOverLabelShadow.GetChild<Label>(0).Visible = false;

		// Init values
		progress = 40;
		totalScore = 0;

		// Init labels
		updateScore();
		updateProgress();

		gameInProgress = true;
		EmitSignal("start_game_signal");
	}

	private void updateProgress()
	{
		OurProgressBar.Value = progress;
	}

	public override void _Process(float delta)
	{
	}
}
