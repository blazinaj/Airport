## PART 2

a)	Create the initial airport system using information contained in an input file: Information about airports, airlines, flights and their associated information will now be read from a file. When the program first starts it will read the input file and create the initial airport system using the information in the file. The format of the file is given in the section AMS File Format. 

b)	Store information about the current airport system in a file:  The program should be able to store information about the airport system in a file when requested. This feature is similar to the display airport system feature: instead of outputting the information on the screen the information is sent to a file to be stored. The format of this file will be the same as the format of the input airport system file.

c)	Create flight sections with a layout: In the previous assignment a flight section was created using only the number of seats and columns. In this assignment you will be required to create sections given a layout that identifies window and aisles seats. See the AMS file format section for an example of how the layouts are to be specified.

d)	Associate one-way prices for seats on an airline for flights between an origin and destination: Given an airline, the pricing for all seats in a particular flight class for all airline flights between an origin and destination is the same. For example, the price of an economy seat on any American Airways flight from Denver to Seattle is $300, while an economy seat on any USAircorp flight from Denver to Seattle is $200.

e)	Book a flight using a seating preference

f)	Provide a simple intuitive text-based user interface for the system: The interface will allow a human user to do the following

a)	Create an airport system by using information provided in an input file.

  i)	Change the price associated with seats in a flight section (all seats in a flight section have the same price).
  
  ii)	Query the system for flights with available seats in a given class (e.g., economy, business) that leave from a specified airport 
      and arrive at specified airport on a particular date. The query operation should list all the available flights found and its           prices.
  iii) Change the seat class (e.g., economy) pricing for an origin and destination for a given airline.
  
  iv)	Book a seat given a specific seat on a flight.

  v)	Book a seat on a flight given only a seating preference: The program should allow a user to book a seat on a particular flight           using only a seating preference and a flight class. There will only be two seating preferences: Window and Aisle. This booking           service    will look for an available seat in the flight section with the seating preference. If one is found then the seat is           booked. If one is not found, then the system will book any available seat in the specified section, if any.
  
  vi)	Display details of the airport system.

  vii)	Store information about the airport system in a specified file.

 
```
AMS File Format AMS information will be stored in a file using the following format: 

AMS ::= [list-of-airport-codes] {list-of-airlines} 

list-of-airport-codes ::= comma-separated strings 

list-of-airlines ::= airline-name1[flightinfo-list1], airline-name2[flightinfo-list2], airlinename3[flightinfo-list3], … 

flightinfo-list ::= flightID1|flightdate1|originAirportCode1|destinationAirportCode1[flightsectionlist1], flightID2|flightdate2|originAirportCode2|destinationAirportCode2[flightsection-list2], … 

flightdate ::= year, month, day-of-month, hours, minutes 

flightsection-list ::= sectionclass: seat-price: layout: number-of-rows, … 

sectionclass ::= F, B, E (for first class, business class, economy class) 

layout ::= S, M, W  (where S is a seat layout with 3 columns with an aisle between columns 1 and 2, M is a seat layout with 4 columns with an aisle between columns 2 and 3, and W is a seat layout with 10 columns with aisles between columns 3 and 4, and between columns 7 and 8) 


Example: An airport system with 4 airports, 4 airlines - AMER (in red), UNTD (in green), FRONT, USAIR - and associated flights. 

[DEN, NYC, SEA, LAX]{AMER[AA1|2011, 10, 8, 16, 30|DEN|LAX[E:200:S:4,F:500:S:2], AA2|2011, 8, 9, 7, 30|LAX|DEN[E:200:S:5,F:500:S:3], …], UNTD[UA21|2011, 11, 8, 12, 30|NYC|SEA[E:300:S:6, F:800:S:3], UA12|2011, 8, 9, 7, 30|SEA|DEN[B:700:S:5, F:1200:S:2], …], FRONT[…], USAIR[…]}
```

Extend the program so that it can be used to book cabins on cruise trips as well as seats on flights. The extended program thus supports the building and management of bookings of 2 subsystems: Airline and Cruise subsystems. Write your program to exploit polymorphism and avoid coding the solution as two completely separated solutions. 

Extend your program in the following manner: 

1.	Develop an administrator user interface (UI) that allows a system administrator to do the following: 
a.	Create airports, airlines, and flights with flight sections and seats.
b.	Create cruises, ports, trips, and ships with cabin sections and cabins.
c.	Print the current state of the airline subsystem including information on seats that are available and booked on each flight.
d.	Print the current state of the cruise subsystem including information on cabins that are available and booked on each cruise trip.
