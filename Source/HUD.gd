extends CanvasLayer

signal start_game

var totalScore : int = 0
var progress : int = 40
var maxProgress : int = 100
var gameInProgress : bool = false

func increase_score(increase : int):
	if (!gameInProgress):
		return
	print("Score increased by: ", String(increase))
	totalScore += increase
	print("New total is: ", String(totalScore))
	increase_progress(10)
	updateScore()

func _ready():
	start_game()
	
func updateScore():
#	get_child(0).set_text(String(totalScore))
#	get_child(0).get_child(0).set_text(String(totalScore))
	$ScoreShadowLabel.set_text(String(totalScore))
	$ScoreShadowLabel.get_child(0).set_text(String(totalScore))

func updateProgress():
	$ProgressBar.value = progress

func start_game():
	# Stop timer if it was running
	$EndGameTimer.stop()

	# Initialize game over label
	$GameOverLabelShadow.visible = false
	$GameOverLabelShadow.get_child(0).visible = false

	# Init values
	progress = 40
	totalScore = 0
	
	# Init labels
	updateScore()
	updateProgress()
	
	gameInProgress = true
	emit_signal("start_game")

func end_game():
	gameInProgress = false
	$EndGameTimer.start()
	$GameOverLabelShadow.visible = true
	$GameOverLabelShadow.get_child(0).visible = true

func decrease_progress(delta : int):
	if (!gameInProgress):
		return
	progress -= delta
	updateProgress()
	if (progress <= 0):
		end_game()
		
func increase_progress(delta : int):
	if (!gameInProgress):
		return
	progress += delta
	if (progress > maxProgress):
		progress = maxProgress
	updateProgress()

func _on_EndGameTimer_timeout():
	# Get shapes and destroy them
	var shapes = get_parent().get_child(2).get_children()
	for shape in shapes:
		shape.queue_free()
	start_game()

