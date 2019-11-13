Feature: EducationTestFeature
		In order to add eductations to profile
		I want to add,update and delete the eductations

@ignore
Scenario:  Add Education tab
	Given click on Education tab
	When Add a new Education
	Then that Education should be displayed on the list

@ignore
Scenario:   Edit Education tab
	Given click on Education tab
	When i click on Education  Edit button
	Then the value should be Edited on my  Education listings

@ignore
Scenario:  Delete Education tab
	Given click on Education tab
	When i click on  Education  Delete button
	Then the value should be Delete on my   Education  listings
