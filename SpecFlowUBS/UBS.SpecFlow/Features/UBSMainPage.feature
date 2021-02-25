Feature: UBS Main Page

Background: 
	Given Open UBS home page

@Smoke_UBS_HomePage
Scenario Outline: Verify Menus <menuName> and <subMenuName>
	Then Verify if there is a menu <menuName> with submenu as <subMenuName>

	Examples: 
	| menuName          | subMenuName                      |
	| Wealth Management | Your life goals                  |
	| Wealth Management | Our service                      |
	| Wealth Management | Our approach                     |
	| Wealth Management | About us                         |
	| Wealth Management | Sustainable Investing            |
	| Wealth Management | International banking            |
	| Asset Management  | Products and capabilities        |
	| Asset Management  | Insights                         |
	| Asset Management  | UBS ETFs (Exchange Traded Funds) |
	| Asset Management  | UBS Funds                        |
	| Asset Management  | About us                         |
	| Investment Bank   | What we offer                    |
	| Investment Bank   | About us                         |
	| Investment Bank   | In focus                         |
	| About us          | Our firm                         |
	| About us          | Investor Relations               |
	| About us          | Media                            |
	| About us          | UBS in Society                   |
	| Careers           | Life at UBS                      |
	| Careers           | University students              |
	| Careers           | Recent graduates                 |
	| Careers           | Career Comeback                  |
	| Careers           | Experienced professionals        |
	| Careers           | Meet us                          |
	| Careers           | Search jobs                      |

@Smoke_UBS_HomePage
Scenario Outline: Verify opening of <menuName> -> <subMenuName> and check if it was open 
	Then Verify if there is a menu <menuName> with submenu as <subMenuName>
	Then Open menu as <menuName> and submenu as <subMenuName>
	Then Verify if opened page contains any header as <subMenuName>
	Then Click go back to main page

	Examples: 
	| menuName          | subMenuName                      |
	| Wealth Management | Your life goals                  |
	| Wealth Management | Our service                      |
	| Wealth Management | International banking            |
	| Investment Bank   | What we offer                    |
	| Investment Bank   | In focus                         |
	| About us          | Investor Relations               |
	| About us          | UBS in Society                   |
	| Careers           | Life at UBS                      |
	| Careers           | University students              |
	| Careers           | Recent graduates                 |
	| Careers           | Career Comeback                  |
	| Careers           | Experienced professionals        |
	| Careers           | Search jobs                      |