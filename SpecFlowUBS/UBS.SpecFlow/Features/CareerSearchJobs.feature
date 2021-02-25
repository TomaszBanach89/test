Feature: Search Jobs

Background: 
	Given Open UBS home page
	Then Verify if there is a menu Careers with submenu as Search jobs
	Then Open menu as Careers and submenu as Search jobs
	Then Verify if opened page contains any header as Search jobs

@Regression
Scenario Outline: Check available locations <location>
	Then Verify available locations as <location> for searching jobs

	Examples: 
	| location             |
	| Americas             |
	| APAC                 |
	| EMEA (excl. UK & CH) |
	| India                |
	| Poland               |
	| Switzerland          |
	| United Kingdom       |

@Regression
Scenario Outline: Check if searching of jobs works as expected
	Then Click <buttonName> for location as <location>
	Given Input <roleName> into job search bar
	Then Input <country> into country search bar
	Then Click search for jobs
	Then Jobs are listed

	
	Examples: 
	| location | buttonName    | roleName | country |
	| Poland   | Professionals | Test     | Poland  |
