Feature:  CertificationTestFeature
		In order to add certifications to profile	
		I want to add,update and delete the certifications

@ignore
Scenario:  Add   Certification
	Given click on  Certification tab
	When Add a new Certification
	Then that  Certification should be displayed on the list

@ignore
Scenario: Edit Certification  tab
	Given click on  Certification tab
	When i click on Certification  Edit button
	Then the value should be Edited on my Certification listings

@ignore
Scenario: Delete Certification  tab
	Given click on  Certification tab
	When i click on  Certification  Delete button
	Then the value should be Delete on my Certification  listings
