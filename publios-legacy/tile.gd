extends Panel

var selected = false

func _ready():
	# Crear un StyleBoxFlat único
	var sb = StyleBoxFlat.new()
	sb.corner_radius_top_left = 0
	sb.corner_radius_top_right = 0
	sb.corner_radius_bottom_left = 0
	sb.corner_radius_bottom_right = 0
	sb.set_border_width_all(2)             # ⚡ Forma correcta en Godot 4
	sb.set_border_color_all(Color.BLACK)   # ⚡ Forma correcta
	sb.set_bg_color(Color.RED)             # ⚡ Forma correcta
	self.custom_styles.panel = sb
	
	# Asegurarse de recibir clicks
	mouse_filter = Control.MOUSE_FILTER_STOP

func _gui_input(event):
	if event is InputEventMouseButton and event.pressed and event.button_index == MOUSE_BUTTON_LEFT:
		toggle_selection()
		emit_signal("tile_clicked")  # señal opcional para Main

func toggle_selection():
	selected = !selected
	var style = get_theme_stylebox("panel") as StyleBoxFlat # Yellow or red
	if selected:
		style.bg_color =  Color(1,1,0)
	else:
		style.bg_color = Color(1,0,0)
