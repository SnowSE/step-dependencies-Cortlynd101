Feature: Steps
!This program takes in a file of instructions and runs them in the correct order.

@mytag
Scenario Outline: Create Dependencies
	Given the file path C:\Users\Cortl\source\repos\Dependencies\Step_Dependencies\PracticeFile.txt
	When the line is parsed
	Then <firstChar> is done before <secondChar>
	Examples: 
	| firstChar | secondChar |
	| C         | A          |
	| C         | F          |
	| A         | B          |
	| A         | D          |
	| B         | E          |
	| D         | E          |
	| F         | E          |


Scenario Outline: Find Dependencies
	Given list head
	When checking against all nodes
	Then the <number> step that is done should be <char>
	Examples: 
	| number | char |
	| 1      | C    |
	| 2      | A    |
	| 3      | B    |
	| 4      | D    |
	| 5      | F    |
	| 6      | E    |