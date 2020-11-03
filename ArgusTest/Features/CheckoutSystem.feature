Feature: CheckoutSystem

@UserStory1
Scenario Outline: Amount total is added correctly
         Given I navigate to Argus home page
	     When a group of '<Person>' orders '<Starters>' '<Mains>''<Drinks>' from restaurant 	     
	     Then I should see the "status" as "success"
Examples: 
| Person | Starters | Mains | Drinks |
| 4      | 4        | 7     | 2.50   |

@UserStory2
Scenario Outline: Amount total is updated correctly
         Given I navigate to Argus home page
	     When a group of '<People>' orders '<Starters>' '<Mains>'from restaurant then updates order	     
	     Then I should see the "status" as "success"		 
Examples: 
| People | Starters | Mains | Drinks | 
| 2      | 4        | 7     | 2.50   | 

@UserStory3
Scenario Outline: Amount total is updated correctly after cancellation
         Given I navigate to Argus home page
	     When a group of '<People>' orders '<Starters>' '<Mains>''<Drinks>' then deletes item in order	     
	     Then I should see the "status" as "success"
		 
Examples: 
| People | Starters | Mains | Drinks | 
| 4      | 4        | 7     | 2.50   | 