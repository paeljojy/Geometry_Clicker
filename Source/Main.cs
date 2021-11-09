using Godot;
using System;

public class Main : Node
{
	// TODO: make more shapes
	//export(PackedScene) var Hexagon 

	[Export] PackedScene Triangle;
	[Export] PackedScene Circle;
	[Export] PackedScene Pentagon;

	// TODO: get these from system api
	private static float SCREENWIDTH = 1280.0f;
	private static float SCREENHEIGHT = 720.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Randomize();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
	}

	void _on_ShapeSpawnTimer_timeout()
	{
		/*
		// Choose a random location on Path2D.1
		// var mob_spawn_location = get_node("ShapeSpawnLocations/Path")
		// mob_spawn_location.offset = randi() % 2600

		Vector2 randomLocation = new Vector2();
		Random random = new Random();
		randomLocation.x = rand_range(SCREENWIDTH / 6, SCREENWIDTH - (SCREENWIDTH / 6));
		randomLocation.y = rand_range(SCREENHEIGHT / 4, SCREENHEIGHT - (SCREENHEIGHT / 4));

		// Create a Shape instance and add it to the scene.
		var randomShape = randi() % 4;
		switch (randomShape)
		{
		case 0:
			
		Shape shape = Circle.instance();
		//			var shape = MyShape.new()
		$Shapes.add_child(shape);
		shape.scale = Vector2(0.75, 0.75);
		// var vecc : Vector2 = Vector2(23, 33)
		// Set the shapes' position to a random location.
		// shape.position = mob_spawn_location.position
		shape.position = randomLocation;

		// shape.position = vecc
		shape.rotation = randi();
		break;
		case 1:
		var shape = Square.instance();
			$Shapes.add_child(shape);
		shape.scale = Vector2(0.75, 0.75);

		// var vecc : Vector2 = Vector2(23, 33)
		// Set the shapes' position to a random location.
		// shape.position = mob_spawn_location.position
		shape.position = randomLocation;
		// shape.position = vecc
		shape.rotation = randi();
		case 2:
		var shape = Triangle.instance()
			$Shapes.add_child(shape)
		shape.scale = Vector2(0.75, 0.75)

// var vecc : Vector2 = Vector2(23, 33)
// Set the shapes' position to a random location.
// shape.position = mob_spawn_location.position
		shape.position = randomLocation
// shape.position = vecc
		shape.rotation = randi()
		case 3:
		var shape = Pentagon.instance()
			$Shapes.add_child(shape)
		shape.scale = Vector2(0.75, 0.75)

// var vecc : Vector2 = Vector2(23, 33)
// Set the shapes' position to a random location.
// shape.position = mob_spawn_location.position
		shape.position = randomLocation
// shape.position = vecc
		shape.rotation = randi();
		}
// func _process(delta):
//	pass
	 */
	}

}
