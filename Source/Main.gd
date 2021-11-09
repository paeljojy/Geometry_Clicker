extends Node

export(PackedScene) var Circle
export(PackedScene) var Square
export(PackedScene) var Triangle
export(PackedScene) var Pentagon

# TODO: make more shapes
#export(PackedScene) var Hexagon 

# TODO: get these from system api
var SCREENWIDTH : float = 1280.0
var SCREENHEIGHT : float = 720.0

var bMouseOverShape : bool = false

func _ready():
	# $StartGameTimerDelegate.start()
	randomize()
	
func new_game():
	pass
	
func _on_ShapeSpawnTimer_timeout():
	# Choose a random location on Path2D.1
	# var mob_spawn_location = get_node("ShapeSpawnLocations/Path")
	# mob_spawn_location.offset = randi() % 2600

	var randomLocation : Vector2 = Vector2()
	randomLocation.x = rand_range(SCREENWIDTH / 6, SCREENWIDTH - (SCREENWIDTH / 6))
	randomLocation.y = rand_range(SCREENHEIGHT / 4, SCREENHEIGHT - (SCREENHEIGHT / 4))

	# Create a Shape instance and add it to the scene.
	var randomShape = randi() % 4
	match (randomShape):
		0:
			var shape = Circle.instance()
#			var shape = MyShape.new()
	
			$Shapes.add_child(shape)
			shape.scale = Vector2(0.75, 0.75)
			# var vecc : Vector2 = Vector2(23, 33)
			# Set the shapes' position to a random location.
			# shape.position = mob_spawn_location.position
			shape.position = randomLocation
			
			# shape.position = vecc
			shape.rotation = randi()
		1:
			var shape = Square.instance()
			$Shapes.add_child(shape)
			shape.scale = Vector2(0.75, 0.75)

			# var vecc : Vector2 = Vector2(23, 33)
			# Set the shapes' position to a random location.
			# shape.position = mob_spawn_location.position
			shape.position = randomLocation
			# shape.position = vecc
			shape.rotation = randi()
		2:
			var shape = Triangle.instance()
			$Shapes.add_child(shape)
			shape.scale = Vector2(0.75, 0.75)

			# var vecc : Vector2 = Vector2(23, 33)
			# Set the shapes' position to a random location.
			# shape.position = mob_spawn_location.position
			shape.position = randomLocation
			# shape.position = vecc
			shape.rotation = randi()
		3:
			var shape = Pentagon.instance()
			$Shapes.add_child(shape)
			shape.scale = Vector2(0.75, 0.75)

			# var vecc : Vector2 = Vector2(23, 33)
			# Set the shapes' position to a random location.
			# shape.position = mob_spawn_location.position
			shape.position = randomLocation
			# shape.position = vecc
			shape.rotation = randi()
# func _process(delta):
#	pass

func _on_StartGameTimerDelegate_timeout():
	$ShapeSpawnTimer.start()

func _on_HUD_start_game():
	$StartGameTimerDelegate.start()

func _on_BackgroundTexture_resized():
	var rect = OS.get_window_safe_area()
	print(String(rect.size.x))
	print(String(rect.size.y))
	SCREENWIDTH = rect.size.x
	SCREENHEIGHT = rect.size.y
	print("Main height: " + String(SCREENHEIGHT))
	print("Main width: " + String(SCREENWIDTH))

func _on_BackgroundTexture_gui_input(event):
	print("missed")
	

func _on_MissArea_input_event(viewport, event, shape_idx):
	if event is InputEventMouseButton:
		if event.is_pressed() && !bMouseOverShape:
			get_child(0).decrease_progress(10)
			
			
