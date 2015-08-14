Feature: Villager Professions


Scenario: A villager gathers food when being a gatherer
	Given I have a villager
	When he becomes a gatherer
	Then food amount increases over time
