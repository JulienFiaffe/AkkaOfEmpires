Feature: ResourcesGathering

Scenario: Villager gathers food
	Given I have a villager
	When it gathers food
	Then the food amount is increased
