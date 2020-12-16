Feature: Amazon login and Search
	Feature functionality by logining with valid credetials
	Then search for products.

@mytag
Scenario: Login and Search
	Given The following page amazon.com.mx
	And I have valid credentials to login
	When I search for Samsung Galaxy S9 64GB
	Then I validate that I have 1 item in the cart
	When I search for Alienware Aw3418DW
	Then I validate that I have 2 items in the cart