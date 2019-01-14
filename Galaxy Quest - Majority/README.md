# Galaxy Quest
### Problem: [Kattis - Galaxy Quest](https://utah.kattis.com/problems/utah.galaxyquest)
Given a Parallel Universe's galactic diameter *d* and a list of stars coordinates in the galaxy, create an algorithm quicker than Ω(n^2) that returns "No" if half or less than half of the stars are in a single galaxy. If more than half of the stars are in a single galaxy, return the total number of stars in said galaxy. Stars are in the same galaxy if they are less than *d* light years apart from each other. For sample input/output, view the question on Kattis.

### Approach:
1. Because the specs require an algorithm quicker than Ω(n^2), we can't check for every star whether the majority of stars are within *d* light years away. Thus we need to use a Majority Element algorithm.

2. I started by setting up a Planet class that stores its coordinates. In the class I also created a function isInPlanet() that checkes whether 2 planets are within *d* light years of eachother.

3. I then set up a recursive function findMajority(). If there is a galaxy with the majority of the planets in it, the function returns a planet from the galaxy. On the base level the function returns null if it doesn't have an planet, or the planet if there is one.  At every other level it splits the planets list in two and calls the recursive function on each half.
    * If there is a planet returned in one half of the planets list and not the other, then it checks the opposite half for a single planet that is also in that galaxy. If there is, then there is a majority galaxy at that level and a planet from the galaxy is returned.
    * If there is a planet returned in both halves of the list then the function checks the opposite half for a single planet that is also in the galaxy. It checks each half one at a time. If the first half finds a planet in the other halves majority galaxy, the planet is instantly returned without checking the second half. This is because there cannot be two majority galaxies. If no planet is found from either half, null is returned.
  
4. I kept a global variable *total* that, if there is a majority, updates at every recursive call. The variable contains the number of planets in the majority galaxy. This allows me, when findMajority() returns a planet from the majority galaxy, to return *total* and I am done. If no planet is returned from findMajority() then I return "NO" because there is no majority galaxy.


