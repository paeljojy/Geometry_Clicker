extends Node2D

export(int) var Health = 1
export(PackedScene) var ClickParticle
export(int) var pointMultiplier = 1

onready var disappearanceTimer = $DisappearanceTimer
onready var hud = get_parent().get_parent().get_child(0)

export(float) var disappearanceTimeout = 4.5

signal increase_score

class_name MyShape

func _init():
	pass

func _ready():
	disappearanceTimer.wait_time = disappearanceTimeout
	disappearanceTimer.start()
	pass # Replace with function body.

func MyShape():
	pass

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass

func _on_TouchScreenButton_pressed():
	take_damage(1)

func take_damage(damage : int):
	Health -= damage
	print("Health is:" + String(Health))
	if (Health <= 0):
#		emit_signal("increase_score", 69)
		hud = get_parent().get_parent().get_child(0)
		hud.increase_score(69 * pointMultiplier)
		queue_free()
		
func _on_Area2D_input_event(viewport, event, shape_idx):
	if event is InputEventMouseButton:
		if event.is_pressed():
			print("Clicked!")
			take_damage(1)
			
			var v = Vector2(60, 100)
			print(position)

			var pos = get_viewport().get_mouse_position()
			var newParticle = ClickParticle.instance()
			get_parent().get_parent().add_child(newParticle)
			newParticle.position = pos
#	else:
#		print("Random event!")
	

func _on_DisappearanceTimer_timeout():
	hud.decrease_progress(10)
	queue_free()
