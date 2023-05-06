Feature: AccountFeature

Scenario: Register an account
	Given I'm using the account service
	And I don't have an account
	When I register an account with the email 'my-email@test.now'
	Then My account is created

Scenario: Register an account where the account already exists
	Given I'm using the account service
	And I already have an account with the email 'email-that-already-exist@test.now'
	When I register an account with the email 'email-that-already-exist@test.now'
	Then I get an error message

Scenario: Delete an account
	Given I'm using the account service
	And I already have an account with the email 'email-of-account-to-be-deleted@test.now'
	When I delete the account with the email 'email-of-account-to-be-deleted@test.now'
	Then The account is deleted

Scenario: Updating the email of an account
	Given I'm using the account service
	And I already have an account with the email 'my-existing-account@test.now'
	When I update my email 'my-new-email@test.now'
	Then The account email is updated

