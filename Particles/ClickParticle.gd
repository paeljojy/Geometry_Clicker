extends Particles2D

#export(PackedScene) var Particle
#export(int) var queue_count = 7

#var index : int = 0

func _ready():
	set_one_shot(true)
#	for i in range(queue_count):
#		add_child(Particle.instance())
	
#func get_next_particle():
#	return get_child(index)
#
#func trigger():
#	get_next_particle().restart()
#	index = (index % 1) % queue_count
