Comments:

A hand of poker cards is 5 cards, however there are versions of poker where a hand may be made up of a subset of a larger hand. 
For example in Texas Hold-Em each player makes their best 5 card hand out of a possible 7 cards.
For this reason I have attempted to code this library in such a way that it is agnostic to the number of cards in a hand.
In a real development scenario I would first ask a team lead / product manager / product owner for clarification on what actually needs to be implemented before going this far.

For the purposes of brevity I have filled out the FlushTest.cs file to the extent that I would normally test a file. The rest have minimal tests.

The entire solution is written from scratch with nothing but standard libraries.

Assumptions:

The specified rules are all that are required for this form of poker
-As such a hand which contains 2 pairs, which would normally be a 2 pair hand we be classified as a pair hand here, but this means that with 2 pairs
	there is a need to determine which pair is the best pair