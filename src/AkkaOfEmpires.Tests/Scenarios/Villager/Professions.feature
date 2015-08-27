Feature: Villager Professions

Scenario: A villager recolts food when ordered to gather fruits
	Given I have a villager
	When he becomes a gatherer
	Then he recolts food

Scenario: A villager recolts food when ordered to become a shepherd
	Given I have a villager
	When he becomes a shepherd
	Then he recolts food

Scenario: A villager recolts food when ordered to hunt
	Given I have a villager
	When he becomes a hunter
	Then he recolts food

Scenario: A villager recolts food when ordered to farm
	Given I have a villager
	When he becomes a farmer
	Then he recolts food

Scenario: A villager recolts food when ordered to fish
	Given I have a villager
	When he becomes a fisherman
	Then he recolts food

Scenario: A villager recolts wood when ordered to cut trees
	Given I have a villager
	When he becomes a lumberjack
	Then he recolts wood