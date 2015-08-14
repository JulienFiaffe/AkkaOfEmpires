Feature: Resources Gathering

Scenario: A villager gathers food
	Given I have a villager
	When he gathers food
	Then food amount increases over time

Scenario: A villager gathers wood
	Given I have a villager
	When he gathers wood
	Then wood amount increases over time

Scenario: A villager gathers gold
	Given I have a villager
	When he gathers gold
	Then gold amount increases over time

Scenario: A villager gathers stone
	Given I have a villager
	When he gathers stone
	Then stone amount increases over time
