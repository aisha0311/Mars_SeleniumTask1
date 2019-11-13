Feature: SkillsTestFeatures
	In order to update my profile 
	As a skilled trader
	I want to add the skills that I know


Scenario: add skill
	Given i click on skill tab in profile page
	When Added a new skill
	Then the skill should be displayed on the list

Scenario: edit skill
	Given i click on skill tab in profile page
	When i click on Edit button
	Then the value should be Edited on my listings

Scenario: remove skill
	Given i click on skill tab in profile page
	When I click on delete button
	Then The value should be deleted on my listings