Feature: Villager Professions

Scenario: A villager recolts food when ordered to gather fruits
	Given I have a villager
	When he becomes a gatherer
	Then he recolts food

Scenario: A villager recolts food when ordered to becoma a shepherd
	Given I have a villager
	When he becomes a shepherd
	Then he recolts food