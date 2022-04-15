Feature: Steps
!This program takes in a file of instructions and runs them in the correct order.

@mytag
Scenario Outline: Create Dependencies
	Given the file path C:\Users\brebr\Source\Repos\step-dependencies-Cortlyn\Step_Dependencies\PracticeFile.txt
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
	Given the file path C:\Users\brebr\Source\Repos\step-dependencies-Cortlyn\Step_Dependencies\PracticeFile.txt
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

Scenario Outline: Test Individual Letter Speeds
	Given the letter <letter>
	When doing that process
	Then it should take <time> seconds
	Examples: 
	| letter | time |
	| A      | 61   |
	| B      | 62   |
	| C      | 63   |
	| H      | 68   |
	| S      | 79   |
	| Z      | 86   |

Scenario: Running Multiple Processes
	Given the file path C:\Users\brebr\Source\Repos\step-dependencies-Cortlyn\Step_Dependencies\PracticeFile.txt
	When the line is parsed
	When running multiple processes
	Then the total time of the process should be 1018 seconds
	Then the quickest time should be 126 seconds