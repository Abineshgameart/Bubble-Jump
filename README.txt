BUBBLE JUMP

A simple vertical scroller game where the player jumps from bubble to bubble, climbing as high as possible.

-------------------------------------------------------------------------
Controls:

A  ->  for moving left
D  ->  for moving right
Space  ->  for Jumping

Note: Jump only when player is touching the ground or bubbles
-------------------------------------------------------------------------

Things Implemented:

(Topics)
1.	Movement and Jump
2.	Bubbles (Platforms)  - (Normal Bubble)
3.	Camera & Scoring
4.	Spawning & Difficulty  -  Object Pooling
5.	Game Loop
6.	Tech Constraints


Things Missed:

1.    Moving Bubble
2.    Procedural spawning with increasing difficulty
3.    For normal bubble instead of popping timing, i used number of jumps to pop (if more that six, it will pop)
4.    Best score on game over.

---------------------------------------------------------------------------


Issues Faced and Solved:

1.   Jump Mechanics
	-    Initially used velocity changes, but the jump did not behave as expected.
	-    Switched to Rigidbody2D.AddForce with ForceMode2D.Impulse for correct jump behavior.

2.   Bubble Collision Detection
	-   Bottom collider failed to detect bubble collisions.
	-   Converted to OnTriggerEnter2D, which worked correctly.

3.   Bubble Detection of BubbleCrasher
	-   Bubble was unable to detect the bubblecrasher collider.
	-   Made bubblecrasher a trigger and handled detection from its side.

---------------------------------------------------------------------------

Need to improve: 

1.    Bubble spawning need some improvement, it spawning multiple bubbles in straight lines sometimes.
2.    Bubble bounciness and player jump, when both have performed at same time, the player is jumping so high.




