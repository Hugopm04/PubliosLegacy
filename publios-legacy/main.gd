extends Node2D

var turn = 1
@onready var turn_label = $UI/TurnLabel

#tile prefab
var TileScene = preload("res://Tile.tscn")

# Tile and map size
var tile_size = Vector2(100, 100)
var map_rows = 2
var map_columns = 3

func _ready():
	generate_map()
	update_turn_label()

func generate_map():
	for row in map_rows:
		for col in map_columns:
			var tile_instance = TileScene.instantiate()
			tile_instance.position = Vector2(col, row) * tile_size
			$Map.add_child(tile_instance)

func _on_EndTurnButton_pressed():
	turn += 1
	update_turn_label()

func update_turn_label():
	turn_label.text = "Turn: %d" % turn


func _on_end_turn_button_pressed() -> void:
	pass # Replace with function body.
