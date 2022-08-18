# BalioTest
Tech test for Balio Studio application

I unfortunately ran out of time to implement everything request, namely enemies and UI, as well as the ability to reload the weapon (no ammo management present at all).


## Controls:

Movement: WASD (should be compatible with ZQSD on azerty layout)
Jump: Space bar
Interact (pick up weapon): E
Shoot: Left click


## Process:

As i have been recently working on a similar project, on which i was very happy with the camera system and controls, i decided to redo this for the test, to showcase a game feel that i am proud of, and also to save some time on settings tweaking.

I started with the camera first, as my idea was a fairly complex behaviour that i wanted to be sure to finish before anything else.
I then moved on to movement, for the same reasons, and spent as much time on it as necessary to make it entirely enjoyable first, before adding anything else on top. Movement and camera are the center of everything else that the game will have, which makes them both crucial to get right, to avoid taking the risk of expanding on shaky foundations.

For weapons, i got a bit lost on over-engineering at first, and made some decisions that cost me precious time. Namely, i tried making a very generic and scalable PickUp system to allow for weapons and, later, other possible loots or buff pickups. I always try to achieve one simple goal first, before expanding it to a more generic form, but the very limited time made me lose that focus for this system.
Nonetheless, the system does allow for more varied pickups to be added easily, but the lack of time left forced me to unfortunately make some concessions in terms of consistency, especially in regards to my use of interfaces.

I am very pleased with the result, however, for what it does contain, as i find it enjoyable to control and to shoot, and i believe it constitutes a strong MVP to showcase main character controls. I feel confident that, with more time, adding UI elements and juicy healthbars and floating damage texts etc, it could be a very fun prototype!
