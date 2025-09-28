extends CharacterBody2D
@export var speed: float = 200.0  # velocidad de movimiento

func _physics_process(_delta):
	var input_vector = Vector2.ZERO
	
	if Input.is_action_pressed("ui_right"):
		input_vector.x += 1
	if Input.is_action_pressed("ui_left"):
		input_vector.x -= 1
	if Input.is_action_pressed("ui_down"):
		input_vector.y += 1
	if Input.is_action_pressed("ui_up"):
		input_vector.y -= 1

	input_vector = input_vector.normalized()
	velocity = input_vector * speed
	move_and_slide()
	
	# Función de revisión de colisiones
	# MUY INEFICIENTE!!
	for i in range(get_slide_collision_count()):
		var collision = get_slide_collision(i)
		var collider = collision.get_collider()
		if collider.is_in_group("Obstacles"):
			print("Collided with:", collider.name, "!")
