using System;
using System.Diagnostics;
using Godot;

public class Main : Node
{
	// TODO: make more shapes
	//export(PackedScene) var Hexagon 

	[Export] private readonly PackedScene Triangle = null;
	[Export] private readonly PackedScene Square = null;
	[Export] private readonly PackedScene Circle = null;
	[Export] private readonly PackedScene Pentagon = null;

	// TODO: get these from system api
	private static float SCREENWIDTH = 1280.0f;
	private static float SCREENHEIGHT = 720.0f;

	private Node Shapes = null;
	private Timer ShapeSpawnTimer { get; set; }

	public bool bMouseOnShape { get; set; }

	private PlayerHUD HUD = null;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Randomize();
		ShapeSpawnTimer = GetNode<Timer>("ShapeSpawnTimer");
		ShapeSpawnTimer.WaitTime = 1.0f;
		ShapeSpawnTimer.Connect("timeout", this, "on_timeout");
		Shapes = GetNode<Node>("Shapes");
		ShapeSpawnTimer.Start();

		HUD = GetNode<PlayerHUD>("HUD");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
	}

	private void on_timeout()
	{
		GD.Print("MORO");
		// Choose a random location on Path2D.1
		// var mob_spawn_location = get_node("ShapeSpawnLocations/Path")
		// mob_spawn_location.offset = randi() % 2600

		Vector2 randomLocation = new Vector2();
		Random random = new Random();
		float areaX = Math.Abs((SCREENWIDTH / 6.0f) - (SCREENWIDTH - (SCREENWIDTH / 6.0f)));
		float deltaX = (SCREENWIDTH / 6.0f) + (float)random.NextDouble() * areaX;

		float areaY = Math.Abs((SCREENHEIGHT / 4.0f) - (SCREENHEIGHT - (SCREENHEIGHT / 4.0f)));
		float deltaY = (SCREENWIDTH / 6.0f) + (float)random.NextDouble() * areaY;

		randomLocation.x = deltaX;
		randomLocation.y = deltaY;

		// 0.54 * (1280 / 6)
		// 


		// Create a MyShape instance and add it to the scene.
		var randomShape = random.Next() % 4;
		MyShape shape = null;
		switch (randomShape)
		{
			case 0:
				// Spawn new instance of our shape
				// shape = Circle.Instance<MyShape>();
				shape = Circle.Instance<MyShape>();
				Shapes.AddChild(shape);

				// Set custom scale on object basis
				shape.Scale = new Vector2(0.75f, 0.75f);
				break;
			case 1:
				// Spawn new instance of our shape
				shape = Square.Instance<MyShape>();
				Shapes.AddChild(shape);

				// Set custom scale on object basis
				shape.Scale = new Vector2(0.75f, 0.75f);
				break;
			case 2:
				// Spawn new instance of our shape
				shape = Triangle.Instance<MyShape>();
				Shapes.AddChild(shape);

				// Set custom scale on object basis
				shape.Scale = new Vector2(0.75f, 0.75f);
				break;
			case 3:
				// Spawn new instance of our shape
				shape = Pentagon.Instance<MyShape>();
				Shapes.AddChild(shape);

				// Set custom scale on object basis
				shape.Scale = new Vector2(0.75f, 0.75f);
				break;
		}

		// Set the shapes' position to a random location.
		if (shape != null)
		{
			shape.Position = randomLocation;

			shape.Rotation = (float)(random.NextDouble() * random.Next(-180, 180));
		}
	}

	void _on_StartGameTimerDelegate_timeout()
	{
		ShapeSpawnTimer.Start();
	}

	private void _on_MissArea_input_event(object viewport, InputEvent @event, int shape_idx)
	{
		if (@event is InputEventMouseButton mouseEvent)
		{
			if (mouseEvent.IsPressed() && !bMouseOnShape)
			{
				HUD.decrease_progress(10);
			}
		}
	}
}
