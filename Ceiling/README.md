# Ceiling
### Problem: [Kattis - Ceiling Function](https://utah.kattis.com/problems/ceiling)
> Given lists of weights, return the number of different tree structures you can create from the lists. Each list is its own tree and all lists have the same number of nodes. The trees must be binary with values less than the root on the left and all other values on the right. For sample input/outputs, view the question on Kattis.

### Approach
1. I created a Node class which holds its weight as well as its current position in the tree. This allowed me to only store a single parent Node while creating the tree. The Node was used for both comparison of weights as well as easy computation of the next position to compare. 

2. With the Node class created, I merely ran a loop on each of the given weights and placed the Node in its correct position in the array.

3. Next, I needed a way to compare each tree structure. Based on the input, I knew the max height and thus the max number of nodes in the tree was 2^k - 2. This allowed me to create empty arrays of length 2^k-2 which made comparison easier once the trees were built. I created two such trees: one for storing the actual Nodes and one that contained a 1 if a node was in that position or a 0 otherwise. The first array was for building the trees and the second for comparing the tree structures.

4. Instead of running a double for loop after creating all the trees, I ran a for loop after I created each tree. This allowed me to just keep the solutions. That is, I could remove all duplicates right away.

5. Once I had all the unique tree structures, I was able to just return the count of the array.

