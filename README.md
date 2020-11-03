# ArgusTest
You are testing a checkout system for a restaurant. There is a new endpoint that will calculate the total of the order, and add a 10% service charge on food.

The restaurant only serves starters, mains and drinks, and the set cost for each is:

Starters cost £4.00, 
Mains cost £7.00, 
Drinks cost £2.50


Write tests to cover the following User Story's


User Story's

1. A group of 4 people orders 4 starters, 4 mains and 4 drinks. When the order is sent to the endpoint the total is calculated correctly

2. A group of 2 people order 1 starter and 2 mains. The endpoint can be called and return the correct total. 
They are then joined by 2 more people who order 2 mains, when the updated order is sent to the endpoint the total is calculated correctly.

3. A group of 4 people orders 4 starters, 4 mains and 4 drinks. When the order is sent to the endpoint the total is calculated correctly. 
1 person cancels their order so the order is 3 starters, 3 mains and 3 drinks, when the updated order is sent to the endpoint the total is calculated correctly.

