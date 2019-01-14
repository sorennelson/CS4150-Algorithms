# Rumor Mill
### Problem: [Kattis - Rumor Mill](https://utah.kattis.com/problems/utah.rumormill)
Given a complete list of students, pairs of friends, and a list students that each start a rumor, return lists of students in the order that each rumor spread. The rumor is spread each day to every friend of a student that currently knows. If there are students who will not hear from a friend about the rumor, these students are notified last. The returned list should be ordered first by the day the student heard the rumor and then alphabetically. For sample input/outputs, view the question on Kattis. 

### Approach:
1. I created a Vertex class to store the name of the student and a list of the Vertices connected to it (its friends).

2. I wrote a Breadth First Search algorithm that I could call on the Vertex that started the rumor. As I traversed the graph, I stored lists of vertices in a list. The indexes of the outer list were the number of days from when the rumor started to when the students stored at that index heard the rumor. Once I had the students organized into how long it took them to hear the rumor, I passed the list into sortDistances(). 

3. Inside sortDistances() I sorted each inner list of Vertices by the student's names. I then added each sorted list to a single list of all students now sorted by how long it took them to hear the rumor, and then by their name. 

4. Lastly, I ran a loop over each rumor and then returned the sorted lists.
