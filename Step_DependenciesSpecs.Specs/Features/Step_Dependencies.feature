Feature: Steps
!This program takes in a file of instructions and runs them in the correct order.

@mytag
Scenario Outline: Create Dependencies
	Given the file path C:\Users\Cortl\Source\Repos\step-dependencies-Cortlynd101\Step_Dependencies\PracticeFile.txt
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
	Given the file path C:\Users\Cortl\Source\Repos\step-dependencies-Cortlynd101\Step_Dependencies\PracticeFile.txt
	When the line is parsed
	Given list head
	Then the <number> step that is done should be <char>
	Examples: 
	| number | char |
	| 0	     | C    |
	| 1      | A    |
	| 2      | B    |
	| 3      | D    |
	| 4      | F    |
	| 5      | E    |