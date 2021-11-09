using Godot;
using System;

public class MyShape : Node2D
{
	// Exports (variables that can be easily edited from the editor to make
	// different kinds of instances of this object
	[Export] int Health = 1;
	[Export] PackedScene ClickParticle;
	[Export] int pointMultiplier = 1;
	[Export] private float disappearanceTimeout = 4.5f;

	private SignalAttribute increase_score_signal;

	private Timer disappearanceTimer;

	private PlayerHUD hud;

	private Main main;

	public override void _Ready()
	{
		hud = GetParent().GetParent().GetChild<PlayerHUD>(0);
		main = GetParent().GetParent<Main>();

		disappearanceTimer = GetNode<Timer>("DisappearanceTimer");
		disappearanceTimer.WaitTime = disappearanceTimeout;
		disappearanceTimer.Start();
	}

	private void take_damage(int damage)
	{
		Health -= damage;
		GD.Print("Health is:" + Health);
		if (Health <= 0)
		{
			// EmitSignal("increase_score", 69);
			hud.increase_score(69 * pointMultiplier);
			main.bMouseOnShape = false;
			QueueFree();
		}
	}

	public override void _Process(float delta)
	{
	}

	private void _on_Area2D_input_event(object viewport, InputEvent @event, int shape_idx)
	{
		if (@event is InputEventMouseButton)
		{
			if (@event.IsPressed())
			{
				GD.Print("Clicked!");
				take_damage(1);

				Vector2 vector2 = new Vector2(60, 100);
				GD.Print(Position);

				var pos = GetViewport().GetMousePosition();
				Node2D newParticle = (Node2D)ClickParticle.Instance();
				GetParent().GetParent().AddChild(newParticle);
				newParticle.Position = pos;
			}
			// else
				// GD.Print("Random event!");
		}
		// else if (@event is InputEventGesture)
		// {
			// if(@event.)
		// }
	}

	private void _on_Area2D_mouse_exited()
	{
		main.bMouseOnShape = false;
	}

	private void _on_Area2D_mouse_entered()
	{
		main.bMouseOnShape = true;
	}

	private void _on_DisappearanceTimer_timeout()
	{
		hud.decrease_progress(10);
		main.bMouseOnShape = false;
		QueueFree();
	}
}
