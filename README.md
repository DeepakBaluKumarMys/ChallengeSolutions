# Hungry Fish
An evil scientist has developed an injection that induces insatiable hunger in a fish. On giving 
this injection, a fish of size x can eat another fish of smaller size y (y < x) and become a fish of 
size x + y retaining this hunger. An aquarium has a number of fishes of various sizes. The 
scientist introduces an injected fish into this aquarium with an objective that eventually only 1 
fish remains. In order to achieve this, the scientist is allowed only two types of moves: either 
add a normal fish of any size or remove an existing normal fish from the aquarium. 
Given the sizes of other fishes in the aquarium and the size of injected fish, write a program to determine 
the minimum number of moves needed by the scientist to achieve his objective.

*Example*
suppose there are 5 fishes in the aquarium, the injected fish is of size 10 and the 
other fishes are of sizes 9, 20, 25, and 100. To ensure that only 1 fish remains in the aquarium 
the scientist needs to remove the fish of size 100 and add a fish of size 3. So the output is 2. 

Sample Input & Output    
10#9,20,25,100 //2    
3#25,20,100,400,500 //5    
50#25,20,9,100 //0    
