Feature: LanguageTestFeature
	In order to add languages to profile
	I want to add,update and delete the languages

@ignore
Scenario:  Add a language
	Given click on Language tab under Profile page
	When Add a new language
	Then the language should be displayed on my listings

@ignore
Scenario:  Edit the language  tab
	Given click on Language tab under Profile page
	When i click on language  Edit button
	Then the value should be Edited on my  language listings

@ignore
Scenario: Delete the language  tab
	Given click on Language tab under Profile page
	When i click on language  Delete button
	Then the value should be Delete on my  language listings
