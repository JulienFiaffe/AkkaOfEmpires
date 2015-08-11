Feature: Resources Gathering

Scenario: A villager gathers food
	Given I have a villager
	When it gathers food
	Then the supervisor food amount is increased
