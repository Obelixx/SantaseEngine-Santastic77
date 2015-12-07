# Santastic77
Santase AI Player

### About the Project
- Algorithms:
Basically using sorted sets and sorted dictionaries with custom comparer. It is like taking cards in your hands and first of all - other them. Sorting provides fast access to the most low-point cards and in the same time to the most higher one.

- Ideas:
Basically they are taken from here: http://psellos.com/schnapsen/strategy.html#closingthestock
And added more improvements of choosing mechanics in some situations! (Like not switching J trump, counting points for closing conditions and a lot more.)

- Strategy:
Basically the game consists of 2 stages and 2 different approaches based on witch player is on turn.
    - Opened Stack Stage:
    > When are on turn, the process goes trough 4 stages:
    > - trying to detect Close Conditions - and close the Stock if it is ok.
    > - trying to Change Trump card
    > - try to announce 20or40
    > - play some low non-trump cars
    > - and if nothing goes so far play any card ( from the ordered sets/dictionaries)
    > When we have to answer to the other side is a little bit harder.
    > - checking first, is opponent playing trump card - and try to run low on them
    > - if it is non trump, then try to take with 10 or Ace to get big points.
    > - if we cant we play Low Non-Trump but try to get the hand.
    > - then we try to get it again with Low Trump card
    > - and if all fail - try to avoid giving pints, by giving the lowest possible card
    - Closed Stack Stage: 
    > On Closed Stack the game changes a lot, but we have to think less.
    > When we play first:
    > - we must try to play winning-for-sure cards first.
    > - if this fails - we check again for 20/40 announcements
    > - and then play low - to give little points to the opponent.
    > When we answer to the opponent moves
    > - we check first if it is possible to win the take
    > - if not, we play low.

- In the beginning we used standard Chain of responsibility pattern, but later we removed the anstracts(middle) class, becouse the ai.bgcoder.com - system, did not recognise witch public class with IPlayer in inheritance chanin is the main class. Now it is allmost the same method, but it it a little bit manual implemented in every class.

### Team Members
* _Obelixx - Александър Ангелов_
* _stellaval - Стелла Вълчева_