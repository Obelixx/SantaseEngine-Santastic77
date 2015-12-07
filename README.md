# Santastic77
Santase AI Player

### About the Project
- Аlgorithms:
Basicly using sorted sets and sorted dictionarys with cusotm comarear. It is like taking cards in your hands and furst of all - orther them. Sorting provides fast access to the most low-point cards and in the same time to the most higher one.

- Ideas: 
Basicly they are taken from here: http://psellos.com/schnapsen/strategy.html#closingthestock
And added more improvments in choosing mechanics in some situations! (Like not sitching J trump, counting points for closing conditions and a lot more.)

- Strategy:
Basicly the game consits of 2 stages and 2 fifferent approaches based on witch player is on turn.
	- Opend Stack Stage:
	> When are on turn, the process goes trought 4 stages:
	> - tring to detect Close Contitions - and close the Stock if it is ok.
	> - tring ChangeTrump
	> - try to anounce 20or40
	> - play some low nontrump cars
	> - and if nothing goes so far play any card ( from the orderd sets/dictionarys)
	> When we have to answer to the other side is a little bit harder.
	> - checking first, is oponent playing trump card - and try to run low on them
	> - if it is non trump, then try to take with 10 or Ace to get big points.
	> - if we cant we play Low Non-Trump but try to get the hand.
	> - then we try to get it again with Low Trump card
	> - and if all fail - try to avoid giving pints, by giving thhe lowest possible card
	- Closed Stack Stage:  
	> On Closed Stack the game changes a lot, but we have to think less.
	> When we play first:
	> - we must try to play winning-for-sure cards first.
	> - if this fails - we check again for 20/40 announsments
	> - and then play low - to give little points to the opponent.
	> When we answer to the opponent moves
	> - we check first if it is possible to win the take
	> - if not, we play low.

- In the beggining we used standard Chain of responsibility pattern, but later we removed the anstracts(middle) class, becouse the ai.bgcoder.com - system, did not recognise witch public class with IPlayer in inheritance chanin is the main class. Now it is allmost the same method, but it it a liitle bit mannuali implemented in every class. 

### REPO: https://github.com/Obelixx/SantaseEngine-Santastic77

### Team Members
* _Obelixx - Александър Ангелов_
* _stellaval - Стелла Вълчева_