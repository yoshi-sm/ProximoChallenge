# ProximoChallenge
Sorter Challenge:
Interesting problem to solve. The problem revolves around sorting strings individually and then sorting the group of strings.
The first problem is that char[] sorting does not follow EOR, so one must transform the strings into a list of single-character strings, and then sort.
Now you have a list of sorted strings that you need to sort and then put back into the original form. The way I solved this was by pairing the original form
and the sorted form into a tuple and then into a list of tuples. It is possible now to sort the list of tuples via the sorted strings and pick the original strings
in whatever order they land, that's the answer.

After that, it's just a matter of creating unit tests, breaking the code, refactoring, repeat.

Bob's Rental Challenge:
The first problem here was to find a way to "store" the table of prices. Understanding that that kind of information should come from a database
I implemented a fake repository to deal with that. The table was stored as a dictionary<int, list<int>> and a method brings back whatever info is needed from the repository.
The table could be crammed into the main class, but that would add extra responsibility to the class, so I preferred to keep it separated into a fake repository.
According to the example given, the price of the day does not depend on the date the car was rented, instead, it depends on the current day. On top of that it 
retains its price bracket throughout the whole process (i.e. if it starts at the 9-15 days bracket, it will stay in the 9-15 bracket even if the month turns).
What it means in terms of processes is that the only thing that may cause price changes is the turning of the month. 

How to solve this? If there is no month turn it is just the number of days times the price bracket of the current month. If there is a month turn just
count the remaining days on the current month and calculate the price, then subtract from the number of days. Rinse and repeat.

The tests were just bracket tests, month turns, and a few edge cases like leap year.


Name: Yoshiyuki S Miranda
Email: yoshismiranda@gmail.com
